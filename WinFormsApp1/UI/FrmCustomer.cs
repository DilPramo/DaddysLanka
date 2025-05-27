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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("All");
            cmbFilter.Items.Add("Active");
            cmbFilter.Items.Add("Inactive");
            cmbFilter.SelectedIndex = 0;
            dgvCustomers.CellClick += dgvCustomers_CellClick;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void LoadCustomers()
        {
            try
            {
                // Open your DB connection (adjust namespace/class as needed)
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                    @"SELECT RegID, ChildFirstName, ChildLastName, GuardianName, DateOfBirth, Address, PhoneNumber, Email, EmergencyContact, DateRegistered, IsActive 
              FROM CustomerDetails",
                    Daddysanka.Database.DBConnection.Instance.Connection))
                using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCustomers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            // Set Font and Style
            dgvCustomers.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dgvCustomers.DefaultCellStyle.ForeColor = Color.Black;
            dgvCustomers.DefaultCellStyle.BackColor = Color.White;

            // Column Header Style
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            // Row Styles
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Gridlines and Borders
            dgvCustomers.GridColor = Color.LightGray;
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Text Alignment
            dgvCustomers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Row Height
            dgvCustomers.RowTemplate.Height = 30;

            // Selection Colors
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.White;

            LoadCustomers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search text from the input box
            string searchText = txtSearch.Text.Trim();

            // Initialize variables for stored procedure parameters
            string regId = null;
            string childFirstName = null;
            string childLastName = null;

            // If the search text is not empty, assign it to all three fields for flexible search
            if (!string.IsNullOrEmpty(searchText))
            {
                regId = searchText;
                childFirstName = searchText;
                childLastName = searchText;
            }

            // Determine the IsActive filter based on cmbFilter selection
            bool? isActive = null;
            if (cmbFilter.SelectedItem?.ToString() == "Active")
                isActive = true;
            else if (cmbFilter.SelectedItem?.ToString() == "Inactive")
                isActive = false;

            try
            {
                // Open the database connection
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                // Create a command to execute the stored procedure
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("SearchCustomers", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the stored procedure
                    cmd.Parameters.AddWithValue("@RegID", (object)regId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ChildFirstName", (object)childFirstName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ChildLastName", (object)childLastName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object?)isActive ?? DBNull.Value);

                    // Use a data adapter to fill the results into a DataTable
                    using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the search results to the DataGridView
                        dgvCustomers.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("Error searching customers: " + ex.Message);
            }
            finally
            {
                // Always close the database connection
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty; // Clear search text to avoid confusion

            // Ensure a customer is selected in the DataGridView
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to activate.");
                return;
            }

            // Get the selected customer's RegID and IsActive status
            string regId = dgvCustomers.SelectedRows[0].Cells["RegID"].Value?.ToString();
            bool isActive = Convert.ToBoolean(dgvCustomers.SelectedRows[0].Cells["IsActive"].Value);

            // If already active, show a message and return
            if (isActive)
            {
                MessageBox.Show("Customer is already active.");
                return;
            }

            try
            {
                // Open the database connection
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                // Prepare the stored procedure command
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("ActivateCustomer", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add the RegID parameter
                    cmd.Parameters.AddWithValue("@RegID", regId);

                    // Add a parameter to capture the return value
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.Output;

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();

                    // Get the return value
                    int result = (int)returnParameter.Value;

                    // Show appropriate message based on result
                    if (result == 1)
                    {
                        MessageBox.Show("Customer activated successfully.");
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Customer is already active.");
                    }
                    else
                    {
                        MessageBox.Show("Activation failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("Error activating customer: " + ex.Message);
            }
            finally
            {
                // Always close the database connection
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
                btnSearch_Click(null, null); // Refresh using current search/filter
                btnClear_Click(null, null); // Clear input fields after activation

            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty; // Clear search text to avoid confusion
            // Ensure a customer is selected in the DataGridView
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to deactivate.");
                return;
            }

            // Get the selected customer's RegID and IsActive status
            string regId = dgvCustomers.SelectedRows[0].Cells["RegID"].Value?.ToString();
            bool isActive = Convert.ToBoolean(dgvCustomers.SelectedRows[0].Cells["IsActive"].Value);

            // If already inactive, show a message and return
            if (!isActive)
            {
                MessageBox.Show("Customer is already inactive.");
                return;
            }

            try
            {
                // Open the database connection
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                // Prepare the stored procedure command
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("DeactivateCustomer", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add the RegID parameter
                    cmd.Parameters.AddWithValue("@RegID", regId);

                    // Add a parameter to capture the return value
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", System.Data.SqlDbType.Int);
                    returnParameter.Direction = System.Data.ParameterDirection.Output;

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();

                    // Get the return value
                    int result = (int)returnParameter.Value;

                    // Show appropriate message based on result
                    if (result == 1)
                    {
                        MessageBox.Show("Customer deactivated successfully.");
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Customer is already inactive.");
                    }
                    else
                    {
                        MessageBox.Show("Deactivation failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("Error deactivating customer: " + ex.Message);
            }
            finally
            {
                // Always close the database connection
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
                btnSearch_Click(null, null); // Refresh using current search/filter

            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtRegNo.Text) ||
                string.IsNullOrWhiteSpace(txtGaurdian.Text) ||
                string.IsNullOrWhiteSpace(txtEmergency.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Registration No, Guardian Name, Emergency Contact, and Contact No are required.");
                return;
            }

            // Prepare values, converting names to lower case as required
            string regId = txtRegNo.Text.Trim();
            string childFirstName = txtFName.Text.Trim().ToLower();
            string childLastName = txtLname.Text.Trim().ToLower();
            string guardianName = txtGaurdian.Text.Trim();
            DateTime dob = dtpDOB.Value.Date;
            string address = txtAddress.Text.Trim();
            string phoneNumber = txtContact.Text.Trim();
            string email = txtEmail.Text.Trim();
            string emergencyContact = txtEmergency.Text.Trim();
            DateTime dateRegistered = DateTime.Now.Date; // Only the date part, no time
            bool isActive = true; // Default to active

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("InsertCustomerDetails", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RegID", regId);
                    cmd.Parameters.AddWithValue("@ChildFirstName", childFirstName);
                    cmd.Parameters.AddWithValue("@ChildLastName", childLastName);
                    cmd.Parameters.AddWithValue("@GuardianName", guardianName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dob);
                    cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmergencyContact", emergencyContact);
                    cmd.Parameters.AddWithValue("@DateRegistered", dateRegistered);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    // Output parameter to get the result of the operation
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", System.Data.SqlDbType.Int);
                    returnParameter.Direction = System.Data.ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    int result = (int)returnParameter.Value;

                    if (result == 1)
                    {
                        MessageBox.Show("Customer inserted successfully.");
                        btnSearch_Click(null, null); // Refresh grid with current filter/search
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Registration No already exists.");
                    }
                    else
                    {
                        MessageBox.Show("Insert failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting customer: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all input fields
            txtRegNo.Clear();
            txtFName.Clear();
            txtLname.Clear();
            txtGaurdian.Clear();
            dtpDOB.Value = DateTime.Now; // Reset to current date
            txtAddress.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtEmergency.Clear();
            // Optionally, reset the DataGridView selection
            dgvCustomers.ClearSelection();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Ensure a customer is selected in the DataGridView
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtRegNo.Text) ||
                string.IsNullOrWhiteSpace(txtGaurdian.Text) ||
                string.IsNullOrWhiteSpace(txtEmergency.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Registration No, Guardian Name, Emergency Contact, and Contact No are required.");
                return;
            }

            // Prepare values, converting names to lower case as required
            string regId = txtRegNo.Text.Trim();
            string childFirstName = txtFName.Text.Trim().ToLower();
            string childLastName = txtLname.Text.Trim().ToLower();
            string guardianName = txtGaurdian.Text.Trim();
            DateTime dob = dtpDOB.Value.Date;
            string address = txtAddress.Text.Trim();
            string phoneNumber = txtContact.Text.Trim();
            string email = txtEmail.Text.Trim();
            string emergencyContact = txtEmergency.Text.Trim();
            DateTime dateRegistered = DateTime.Now.Date; // Only the date part, no time

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("UpdateCustomerDetails", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RegID", regId);
                    cmd.Parameters.AddWithValue("@ChildFirstName", childFirstName);
                    cmd.Parameters.AddWithValue("@ChildLastName", childLastName);
                    cmd.Parameters.AddWithValue("@GuardianName", guardianName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dob);
                    cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmergencyContact", emergencyContact);
                    cmd.Parameters.AddWithValue("@DateRegistered", dateRegistered);

                    // Output parameter to get the result of the operation
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", System.Data.SqlDbType.Int);
                    returnParameter.Direction = System.Data.ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    int result = (int)returnParameter.Value;

                    if (result == 1)
                    {
                        MessageBox.Show("Customer updated successfully.");
                        btnSearch_Click(null, null); // Refresh grid with current filter/search
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Customer not found.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
                btnClear_Click(null, null); // Clear input fields after update
            }
        }
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header and out-of-range clicks
            if (e.RowIndex < 0 || dgvCustomers.Rows[e.RowIndex].IsNewRow)
                return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

            txtRegNo.Text = row.Cells["RegID"].Value?.ToString();
            txtFName.Text = row.Cells["ChildFirstName"].Value?.ToString();
            txtLname.Text = row.Cells["ChildLastName"].Value?.ToString();
            txtGaurdian.Text = row.Cells["GuardianName"].Value?.ToString();
            dtpDOB.Value = row.Cells["DateOfBirth"].Value != null && row.Cells["DateOfBirth"].Value != DBNull.Value
                ? Convert.ToDateTime(row.Cells["DateOfBirth"].Value)
                : DateTime.Now;
            txtAddress.Text = row.Cells["Address"].Value?.ToString();
            txtContact.Text = row.Cells["PhoneNumber"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtEmergency.Text = row.Cells["EmergencyContact"].Value?.ToString();
        }
    }
}
