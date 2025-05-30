using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daddysanka.UI
{
    public partial class FrmStaffDash : Form
    {
        private int _userId;
        private Form currentChildForm;

        public FrmStaffDash(int userId)
        {
            InitializeComponent();
            _userId = userId;
            SetLoggedInUserName();

            cmbLogout.SelectedIndexChanged += cmbLogout_SelectedIndexChanged;
            this.Load += FrmStaffDash_Load;

        }

        private void FrmStaffDash_Load(object sender, EventArgs e)
        {
            cmbLogout.SelectedIndex = 0;
            LoadSalesForm(); // Load the sales form when the dashboard loads
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        // C#
        private void cmbLogout_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLogout.SelectedItem?.ToString() == "Logout")
            {
                // Show login form again
                var loginForm = new FrmLogin();
                this.Hide();
                loginForm.ShowDialog();
                this.Close();
            }
        }
        private void SetLoggedInUserName()
        {
            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                    "SELECT Username FROM Users WHERE UserID = @UserID",
                    Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", _userId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        lblUser.Text = result.ToString();
                    }
                    else
                    {
                        lblUser.Text = "Unknown User";
                    }
                }
            }
            catch (Exception ex)
            {
                lblUser.Text = "Error";
                MessageBox.Show("Error loading user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void LoadSalesForm()
        {
            // Close previous child form if any
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            currentChildForm = new DaddysLanka.UI.FrmSales();
            currentChildForm.TopLevel = false;
            currentChildForm.FormBorderStyle = FormBorderStyle.None;
            currentChildForm.Dock = DockStyle.Fill;
            pnlLoad.Controls.Clear();
            pnlLoad.Controls.Add(currentChildForm);
            currentChildForm.Show();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            LoadSalesForm(); // Load the sales form when the button is clicked
        }

        private void LoadCustomerForm()
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            currentChildForm = new Daddysanka.UI.FrmCustomer();
            currentChildForm.TopLevel = false;
            currentChildForm.FormBorderStyle = FormBorderStyle.None;
            currentChildForm.Dock = DockStyle.Fill;
            pnlLoad.Controls.Clear();
            pnlLoad.Controls.Add(currentChildForm);
            currentChildForm.Show();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            LoadCustomerForm();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            currentChildForm = new DaddysLanka.UI.FrmServices();
            currentChildForm.TopLevel = false;
            currentChildForm.FormBorderStyle = FormBorderStyle.None;
            currentChildForm.Dock = DockStyle.Fill;
            pnlLoad.Controls.Clear();
            pnlLoad.Controls.Add(currentChildForm);
            currentChildForm.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            currentChildForm = new DaddysLanka.UI.FrmHistory();
            currentChildForm.TopLevel = false;
            currentChildForm.FormBorderStyle = FormBorderStyle.None;
            currentChildForm.Dock = DockStyle.Fill;
            pnlLoad.Controls.Clear();
            pnlLoad.Controls.Add(currentChildForm);
            currentChildForm.Show();
        }
    }
}
