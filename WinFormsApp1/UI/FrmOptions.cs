using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaddysLanka.helpers;

namespace DaddysLanka.UI
{
    public partial class FrmOptions : Form
    {
        // Declare the OpenFileDialog instance as a private field  
        private OpenFileDialog ofd;

        public FrmOptions()
        {
            InitializeComponent();
            // Initialize the OpenFileDialog instance  
            ofd = new OpenFileDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            BackupHelper.CreateBackup();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Backup File";
            ofd.Filter = "Backup Files (*.bak)|*.bak";
            ofd.InitialDirectory = @"D:\"; // Or wherever your backups are stored  
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Call your restore method with the selected file  
                DaddysLanka.helpers.BackupHelper.RestoreBackup(ofd.FileName);
            }
        }
    }
}
