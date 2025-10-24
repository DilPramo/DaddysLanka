using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Daddysanka.Database
{
    public sealed class DBConnection
    {
        private static readonly Lazy<DBConnection> lazyInstance = new Lazy<DBConnection>(() => new DBConnection());
        private SqlConnection connection;

        private DBConnection()
        {
            string connectionString = "Data Source=DESKTOP-C1MDIVP;Initial Catalog=DaddysLankaDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            connection = new SqlConnection(connectionString);

            // Data Source=DESKTOP-C1MDIVP;Initial Catalog=DaddysLankaDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True
        }

        public static DBConnection Instance
        {
            get
            {
                return lazyInstance.Value;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return connection;
            }
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
