using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DaddysLanka.helpers
{
    public static class BackupHelper
    {
        private static readonly string BackupFolder = @"D:\path_to_backup\";
        private static readonly string BackupPrefix = "DaddysankaBackup_";
        private static readonly string BackupExtension = ".bak";
        private static readonly int MaxBackups = 4;
        private static readonly int BackupIntervalDays = 6;

        // Path to store last backup date
        private static readonly string LastBackupInfoFile = Path.Combine(BackupFolder, "DaddysankaBackup.info");

        // Database name (must match your actual database)
        private static readonly string DatabaseName = "DaddysLankaDB";

        public static void RunAutomaticBackup()
        {
            try
            {
                DateTime lastBackup = GetLastBackupDate();
                if ((DateTime.Now - lastBackup).TotalDays >= BackupIntervalDays)
                {
                    CreateBackup();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Automatic backup failed: " + ex.Message, "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CreateBackup()
        {
            try
            {
                if (!Directory.Exists(BackupFolder))
                    Directory.CreateDirectory(BackupFolder);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string backupFile = Path.Combine(BackupFolder, $"{BackupPrefix}{timestamp}{BackupExtension}");



                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                try
                {
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("BackupDaddysLankaDatabase", Daddysanka.Database.DBConnection.Instance.Connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BackupFile", backupFile);
                        cmd.CommandTimeout = 600; // 10 minutes, adjust as needed
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    Daddysanka.Database.DBConnection.Instance.CloseConnection();
                }

                // Save last backup date
                File.WriteAllText(LastBackupInfoFile, DateTime.Now.ToString("o"));

                // Clean up old backups
                CleanupOldBackups();

                MessageBox.Show("Backup created successfully at: " + backupFile, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Backup failed: " + ex.Message, "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static DateTime GetLastBackupDate()
        {
            if (File.Exists(LastBackupInfoFile))
            {
                string content = File.ReadAllText(LastBackupInfoFile);
                if (DateTime.TryParse(content, out DateTime lastBackup))
                    return lastBackup;
            }
            return DateTime.MinValue;
        }

        private static void CleanupOldBackups()
        {
            var backupFiles = Directory.GetFiles(BackupFolder, $"{BackupPrefix}*{BackupExtension}")
                .Select(f => new FileInfo(f))
                .OrderByDescending(f => f.CreationTime)
                .ToList();

            for (int i = MaxBackups; i < backupFiles.Count; i++)
            {
                try
                {
                    backupFiles[i].Delete();
                }
                catch
                {
                    // Ignore errors
                }
            }
        }
        public static void RestoreBackup(string backupFilePath)
        {
            try
            {
                if (!File.Exists(backupFilePath))
                {
                    MessageBox.Show("Backup file not found.", "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show(
                    "Restoring will log out all users and overwrite the current database. Continue?",
                    "Confirm Restore",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                string databaseName = "DaddysLankaDB";
                string dataFile = $@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQL22\MSSQL\DATA\{databaseName}.mdf";
                string logFile = $@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQL22\MSSQL\DATA\{databaseName}_log.ldf";
                string logicalNameData = null;
                string logicalNameLog = null;

                // Get logical file names from the backup
                using (var conn = new Microsoft.Data.SqlClient.SqlConnection(Daddysanka.Database.DBConnection.Instance.Connection.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                        $"RESTORE FILELISTONLY FROM DISK = N'{backupFilePath}'", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                                logicalNameData = reader["LogicalName"].ToString();
                            if (reader.Read())
                                logicalNameLog = reader["LogicalName"].ToString();
                        }
                    }
                }

                if (logicalNameData == null || logicalNameLog == null)
                {
                    MessageBox.Show("Could not determine logical file names from backup.", "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Build restore SQL
                string restoreSql = $@"
        ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
        RESTORE DATABASE [{databaseName}] FROM DISK = N'{backupFilePath}'
        WITH REPLACE,
        MOVE N'{logicalNameData}' TO N'{dataFile}',
        MOVE N'{logicalNameLog}' TO N'{logFile}';
        ALTER DATABASE [{databaseName}] SET MULTI_USER;
        ";

                // Close all connections before restore
                Daddysanka.Database.DBConnection.Instance.CloseConnection();

                // Perform restore
                using (var conn = new Microsoft.Data.SqlClient.SqlConnection(Daddysanka.Database.DBConnection.Instance.Connection.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(restoreSql, conn))
                    {
                        cmd.CommandTimeout = 600;
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Database restored successfully. The application will now close. Please restart.", "Restore Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Exit application after restore
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Restore failed: " + ex.Message, "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
