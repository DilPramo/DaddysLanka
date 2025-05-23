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
    }
}
