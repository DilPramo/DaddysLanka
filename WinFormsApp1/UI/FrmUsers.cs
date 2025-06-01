using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Daddysanka.Database;
using Microsoft.Data.SqlClient;

namespace Daddysanka.UI
{
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();

            LoadUsers();
            txtPassword.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Text = "At least 8 chars, upper, lower, number";
            txtPassword.GotFocus += RemovePasswordPlaceholder;
            txtPassword.LostFocus += SetPasswordPlaceholder;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;



        }
        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            // Ensure there is a selected row
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // Get the first selected row
                DataGridViewRow row = dgvUsers.SelectedRows[0];

                // Set the username textbox with the Username from the selected row
                txtUName.Text = row.Cells["Username"].Value?.ToString();

                // For security, do not display the password hash. Show placeholder instead.
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.ForeColor = Color.Gray;
                txtPassword.Text = "";

                // Set the role combobox to the Role from the selected row
                string role = row.Cells["Role"].Value?.ToString();
                if (!string.IsNullOrEmpty(role))
                {
                    cmbRole.SelectedItem = role;
                }
                else
                {
                    cmbRole.SelectedIndex = -1;
                }
            }
        }





        private void RemovePasswordPlaceholder(object sender, EventArgs e)
        {
            if (txtPassword.ForeColor == Color.Gray)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;

            }
        }

        private void SetPasswordPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.ForeColor = Color.Gray;
                txtPassword.Text = "At least 8 chars, upper, lower, number";
            }
        }


        private bool IsPasswordValid(string password)
        {
            if (password.Length < 8)
                return false;
            if (!password.Any(char.IsUpper))
                return false;
            if (!password.Any(char.IsLower))
                return false;
            if (!password.Any(char.IsDigit))
                return false;
            return true;
        }

        private void LoadUsers()
        {
            try
            {
                DBConnection.Instance.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT UserID, Username, Role, IsActive, DateCreated, LastLogin FROM Users", DBConnection.Instance.Connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvUsers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
            finally
            {
                DBConnection.Instance.CloseConnection();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string username = txtUName.Text.ToLower().Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please enter username, password, and select a role.");
                return;
            }

            if (!IsPasswordValid(password))
            {
                MessageBox.Show("Password must be at least 8 characters and include uppercase, lowercase, and numbers.");
                return;
            }

            string hashedPassword = Daddysanka.helpers.PasswordHelper.HashPassword(password);

            try
            {
                DBConnection.Instance.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("InsertUser", DBConnection.Instance.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@Role", role);

                    // Add a parameter to capture the return value
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();
                    int result = (int)returnParameter.Value;

                    if (result == 1)
                    {
                        MessageBox.Show("User inserted successfully.");
                        clearFields();
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.");
                    }
                    else
                    {
                        MessageBox.Show("User insertion failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting user: " + ex.Message);
            }
            finally
            {
                DBConnection.Instance.CloseConnection();
                LoadUsers(); // Refresh the DataGridView after insertion
            }
        }

        private void clearFields()
        {
            cmbRole.SelectedIndex = -1;      // Clears the ComboBox selection
            txtUName.Clear();                // Clears the username TextBox
            txtPassword.Clear();             // Clears the password TextBox 
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = -1;      // Clears the ComboBox selection
            txtUName.Clear();                // Clears the username TextBox
            txtPassword.Clear();             // Clears the password TextBox
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search text from the username textbox
            string searchText = txtUName.Text.Trim();

            try
            {
                // Open the database connection
                DBConnection.Instance.OpenConnection();

                // Prepare the stored procedure command
                using (SqlCommand cmd = new SqlCommand("SearchUsers", DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add the search parameter to the command
                    cmd.Parameters.AddWithValue("@Username", searchText);

                    // Use a data adapter to fill the results into a DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the search results to the DataGridView
                        dgvUsers.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("Error searching users: " + ex.Message);
            }
            finally
            {
                // Always close the database connection
                DBConnection.Instance.CloseConnection();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ensure a user is selected
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }

            // Get selected user ID
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);

            // Get updated values from controls
            string username = txtUName.Text.ToLower().Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please enter username and select a role.");
                return;
            }

            // Only hash and update password if a new valid password is entered
            string hashedPassword = null;
            if (!string.IsNullOrWhiteSpace(password) && password != "At least 8 chars, upper, lower, number")
            {
                if (!IsPasswordValid(password))
                {
                    MessageBox.Show("Password must be at least 8 characters and include uppercase, lowercase, and numbers.");
                    return;
                }
                hashedPassword = Daddysanka.helpers.PasswordHelper.HashPassword(password);
            }

            try
            {
                // Open DB connection
                DBConnection.Instance.OpenConnection();

                // Prepare stored procedure command
                using (SqlCommand cmd = new SqlCommand("UpdateUser", DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Role", role);

                    // Add password parameter (nullable)
                    if (hashedPassword != null)
                        cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    else
                        cmd.Parameters.AddWithValue("@PasswordHash", DBNull.Value);

                    // Capture return value
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();
                    int result = (int)returnParameter.Value;

                    if (result == 1)
                    {
                        MessageBox.Show("User updated successfully.");
                        clearFields();
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.");
                    }
                    else
                    {
                        MessageBox.Show("User update failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
            finally
            {
                DBConnection.Instance.CloseConnection();
                LoadUsers(); // Refresh the DataGridView after update
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure a user is selected
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            // Get selected user ID and role
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            string role = dgvUsers.SelectedRows[0].Cells["Role"].Value?.ToString();

            // Confirm deletion
            var confirm = MessageBox.Show(
                role == "Staff"
                    ? "This staff user will be disabled. Continue?"
                    : "This user will be permanently deleted. Continue?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // Open DB connection
                DBConnection.Instance.OpenConnection();

                // Prepare stored procedure command
                using (SqlCommand cmd = new SqlCommand("DeleteUser", DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Role", role);

                    // Capture return value
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();
                    int result = (int)returnParameter.Value;

                    if (result == 2)
                    {
                        MessageBox.Show("Staff user has been disabled (IsActive = 0).");
                    }
                    else if (result == 1)
                    {
                        MessageBox.Show("User deleted permanently.");
                    }
                    else
                    {
                        MessageBox.Show("Delete operation failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message);
            }
            finally
            {
                DBConnection.Instance.CloseConnection();
                LoadUsers(); // Refresh the DataGridView after delete
                clearFields();
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            // Ensure a user is selected
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to activate.");
                return;
            }

            // Get selected user ID and IsActive status
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            bool isActive = Convert.ToBoolean(dgvUsers.SelectedRows[0].Cells["IsActive"].Value);

            // If already active, show a message and return
            if (isActive)
            {
                MessageBox.Show("User is already active.");
                return;
            }

            try
            {
                DBConnection.Instance.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("ActivateUser", DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    // Output parameter for result
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    int result = (int)returnParameter.Value;

                    if (result == 1)
                    {
                        MessageBox.Show("User activated successfully.");
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("User is already active.");
                    }
                    else
                    {
                        MessageBox.Show("Activation failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error activating user: " + ex.Message);
            }
            finally
            {
                DBConnection.Instance.CloseConnection();
                LoadUsers(); // Refresh the DataGridView after activation
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            // Ensure a user is selected
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to deactivate.");
                return;
            }

            // Get selected user ID and IsActive status
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            bool isActive = Convert.ToBoolean(dgvUsers.SelectedRows[0].Cells["IsActive"].Value);

            // If already inactive, show a message and return
            if (!isActive)
            {
                MessageBox.Show("User is already inactive.");
                return;
            }

            try
            {
                DBConnection.Instance.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("DeactivateUser", DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    // Output parameter for result
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    int result = (int)returnParameter.Value;

                    if (result == 1)
                    {
                        MessageBox.Show("User deactivated successfully.");
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("User is already inactive.");
                    }
                    else
                    {
                        MessageBox.Show("Deactivation failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deactivating user: " + ex.Message);
            }
            finally
            {
                DBConnection.Instance.CloseConnection();
                LoadUsers(); // Refresh the DataGridView after deactivation
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
