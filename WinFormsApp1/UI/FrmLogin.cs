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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            panel2.Paint += Panel2_Paint;
            lblForgot.MouseEnter += LblForget_MouseEnter;
            lblForgot.MouseLeave += LblForget_MouseLeave;
            lblForgot.Click += LblForget_Click;

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }


        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Color borderColor = Color.LightBlue; // Set your desired color
            int borderWidth = 5; // Set your desired border width

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Adjust rectangle to avoid clipping
                Rectangle rect = panel.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        private void LblForget_MouseEnter(object sender, EventArgs e)
        {
            lblForgot.ForeColor = Color.Blue; // Highlight color
            lblForgot.Font = new Font(lblForgot.Font, FontStyle.Underline); // Optional: underline
            Cursor = Cursors.Hand;
        }

        private void LblForget_MouseLeave(object sender, EventArgs e)
        {
            lblForgot.ForeColor = Color.Red; // Default color
            lblForgot.Font = new Font(lblForgot.Font, FontStyle.Regular);
            Cursor = Cursors.Default;
        }

        private void LblForget_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kindly contact your System Administrator for Password Change.", "Password Assistance", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUName.Text.ToLower().Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT UserID, Username, PasswordHash, Role FROM Users WHERE Username = @Username AND IsActive = 1", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            string role = reader["Role"].ToString();
                            int userId = Convert.ToInt32(reader["UserID"]);

                            if (BCrypt.Net.BCrypt.Verify(password, storedHash))
                            {
                                reader.Close();

                                // Update LastLogin
                                using (var updateCmd = new Microsoft.Data.SqlClient.SqlCommand("UPDATE Users SET LastLogin = @LastLogin WHERE Username = @Username", Daddysanka.Database.DBConnection.Instance.Connection))
                                {
                                    updateCmd.Parameters.AddWithValue("@LastLogin", DateTime.Now);
                                    updateCmd.Parameters.AddWithValue("@Username", username);
                                    updateCmd.ExecuteNonQuery();
                                }

                                // Show dashboard as modal dialog
                                Form dashboard = null;
                                if (role.Equals("Staff", StringComparison.OrdinalIgnoreCase))
                                {
                                    dashboard = new FrmStaffDash(userId);
                                }
                                else if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                                {
                                    dashboard = new WinFormsApp1.FrmAdminDash();
                                }
                                else if (role.Equals("Accountant", StringComparison.OrdinalIgnoreCase))
                                {
                                    dashboard = new FrmAccountantDash();
                                }
                                else
                                {
                                    MessageBox.Show("Unknown User. Access denied.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                this.Hide();
                                dashboard.ShowDialog(); // Modal, blocks until closed
                                this.DialogResult = DialogResult.OK; // Signal to Program.cs to exit
                                this.Close();
                                return;
                            }
                        }
                    }
                }
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }
    }
}
