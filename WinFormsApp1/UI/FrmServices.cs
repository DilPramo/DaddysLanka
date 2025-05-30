using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaddysLanka.UI
{
    public partial class FrmServices : Form
    {
        public FrmServices()
        {
            InitializeComponent();

            // Placeholder for txtSearch
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "enter the keyword to search";
            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "enter the keyword to search")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };
            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "enter the keyword to search";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            // Set Font and Style
            dgvService.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dgvService.DefaultCellStyle.ForeColor = Color.Black;
            dgvService.DefaultCellStyle.BackColor = Color.White;

            // Column Header Style
            dgvService.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dgvService.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvService.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            // Row Styles
            dgvService.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Gridlines and Borders
            dgvService.GridColor = Color.LightGray;
            dgvService.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Row Height
            dgvService.RowTemplate.Height = 40;

            // Selection Colors
            dgvService.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvService.DefaultCellStyle.SelectionForeColor = Color.White;

            LoadServices();
            dgvService.RowValidating += dgvService_RowValidating;
            dgvService.RowValidated += dgvService_RowValidated;
            


        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadServices()
        {
            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                    @"SELECT ServiceID, ServiceName, ServiceDescription, ServiceDuration, ServicePrice, IsActive FROM Services",
                    Daddysanka.Database.DBConnection.Instance.Connection))
                using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvService.DataSource = dt;

                    // Hide the ServiceID column
                    if (dgvService.Columns.Contains("ServiceID"))
                        dgvService.Columns["ServiceID"].Visible = false;

                    // Set custom headers
                    dgvService.Columns["ServiceName"].HeaderText = "Service Name";
                    dgvService.Columns["ServiceDescription"].HeaderText = "Description";
                    dgvService.Columns["ServiceDuration"].HeaderText = "Duration (Hours)";
                    dgvService.Columns["ServicePrice"].HeaderText = "Price (LKR)";
                    dgvService.Columns["IsActive"].HeaderText = "Active";

                    // Autosize columns
                    dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvService.Columns["ServiceDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading services: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }
        private void dgvService_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvService.CurrentRow == null || dgvService.CurrentRow.IsNewRow)
                return;

            var row = dgvService.Rows[e.RowIndex];
            // Skip if row is not dirty (optional, for performance)
            if (!row.IsNewRow && !row.Cells.Cast<DataGridViewCell>().Any(c => c.IsInEditMode))
            {
                // You may want to track changes with a flag or DataTable events for more advanced scenarios
            }

            // Get values from the row
            string serviceName = row.Cells["ServiceName"].Value?.ToString();
            string serviceDescription = row.Cells["ServiceDescription"].Value?.ToString();
            int? serviceDuration = row.Cells["ServiceDuration"].Value as int?;
            decimal? servicePrice = row.Cells["ServicePrice"].Value as decimal?;
            bool isActive;
            if (row.Cells["IsActive"].Value == null || row.Cells["IsActive"].Value == DBNull.Value || string.IsNullOrWhiteSpace(row.Cells["IsActive"].Value.ToString()))
            {
                isActive = true; // Default to true (1)
                row.Cells["IsActive"].Value = true; // Optionally update the cell visually
            }
            else
            {
                isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);
            }
            // Validate required fields
            if (string.IsNullOrWhiteSpace(serviceName) || servicePrice == null)
                return;

            // Check if this is an update or insert
            object serviceIdObj = row.Cells["ServiceID"].Value;
            bool isUpdate = serviceIdObj != null && serviceIdObj != DBNull.Value;

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                if (isUpdate)
                {
                    // Update existing service
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                        @"UPDATE Services SET ServiceName=@ServiceName, ServiceDescription=@ServiceDescription, 
                          ServiceDuration=@ServiceDuration, ServicePrice=@ServicePrice, IsActive=@IsActive 
                          WHERE ServiceID=@ServiceID",
                        Daddysanka.Database.DBConnection.Instance.Connection))
                    {
                        cmd.Parameters.AddWithValue("@ServiceName", serviceName);
                        cmd.Parameters.AddWithValue("@ServiceDescription", (object)serviceDescription ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ServiceDuration", (object)serviceDuration ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ServicePrice", servicePrice);
                        cmd.Parameters.AddWithValue("@IsActive", isActive);
                        cmd.Parameters.AddWithValue("@ServiceID", serviceIdObj);

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Insert new service
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                        @"INSERT INTO Services (ServiceName, ServiceDescription, ServiceDuration, ServicePrice, IsActive)
                          VALUES (@ServiceName, @ServiceDescription, @ServiceDuration, @ServicePrice, @IsActive);
                          SELECT SCOPE_IDENTITY();",
                        Daddysanka.Database.DBConnection.Instance.Connection))
                    {
                        cmd.Parameters.AddWithValue("@ServiceName", serviceName);
                        cmd.Parameters.AddWithValue("@ServiceDescription", (object)serviceDescription ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ServiceDuration", (object)serviceDuration ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ServicePrice", servicePrice);
                        cmd.Parameters.AddWithValue("@IsActive", isActive);

                        // Get the new ServiceID and update the grid
                        var newId = cmd.ExecuteScalar();
                        row.Cells["ServiceID"].Value = Convert.ToInt32(newId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving service: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }


        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvService_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvService.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            string serviceName = row.Cells["ServiceName"].Value?.ToString();
            string serviceDescription = row.Cells["ServiceDescription"].Value?.ToString();
            var serviceDurationObj = row.Cells["ServiceDuration"].Value;
            var servicePriceObj = row.Cells["ServicePrice"].Value;

            // Only check for required fields (except Active & duration)
            if (string.IsNullOrWhiteSpace(serviceName) ||
                string.IsNullOrWhiteSpace(serviceDescription) ||
                servicePriceObj == null || string.IsNullOrWhiteSpace(servicePriceObj.ToString()))
            {
                row.ErrorText = "Please fill all required fields before leaving the row.";
                MessageBox.Show("Please fill all required fields (except Active) before leaving the row.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                row.ErrorText = string.Empty;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "enter the keyword to search")
                keyword = string.Empty;

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("SearchServices", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", (object)keyword ?? DBNull.Value);

                    using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvService.DataSource = dt;

                        // Hide the ServiceID column
                        if (dgvService.Columns.Contains("ServiceID"))
                            dgvService.Columns["ServiceID"].Visible = false;

                        // Set custom headers
                        dgvService.Columns["ServiceName"].HeaderText = "Service Name";
                        dgvService.Columns["ServiceDescription"].HeaderText = "Description";
                        dgvService.Columns["ServiceDuration"].HeaderText = "Duration (Hours)";
                        dgvService.Columns["ServicePrice"].HeaderText = "Price (LKR)";
                        dgvService.Columns["IsActive"].HeaderText = "Active";

                        // Autosize columns
                        dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dgvService.Columns["ServiceDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching services: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            txtSearch.Text = "";
            txtSearch.ForeColor = Color.Black;


            LoadServices();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            // Ensure a service is selected
            if (dgvService.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service to activate.");
                return;
            }

            var selectedRow = dgvService.SelectedRows[0];
            var serviceIdObj = selectedRow.Cells["ServiceID"].Value;
            if (serviceIdObj == null || serviceIdObj == DBNull.Value)
            {
                MessageBox.Show("Invalid service selection.");
                return;
            }

            bool isActive = false;
            if (selectedRow.Cells["IsActive"].Value != null && selectedRow.Cells["IsActive"].Value != DBNull.Value)
                isActive = Convert.ToBoolean(selectedRow.Cells["IsActive"].Value);

            if (isActive)
            {
                MessageBox.Show("Service is already active.");
                return;
            }

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("ActivateService", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServiceID", serviceIdObj);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", System.Data.SqlDbType.Int);
                    returnParameter.Direction = System.Data.ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    int result = (int)returnParameter.Value;

                    if (result == 1)
                    {
                        MessageBox.Show("Service activated successfully.");
                        LoadServices();
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Service is already active.");
                    }
                    else
                    {
                        MessageBox.Show("Activation failed. Service not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error activating service: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            // Ensure a service is selected
            if (dgvService.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service to deactivate.");
                return;
            }

            var selectedRow = dgvService.SelectedRows[0];
            var serviceIdObj = selectedRow.Cells["ServiceID"].Value;
            if (serviceIdObj == null || serviceIdObj == DBNull.Value)
            {
                MessageBox.Show("Invalid service selection.");
                return;
            }

            bool isActive = false;
            if (selectedRow.Cells["IsActive"].Value != null && selectedRow.Cells["IsActive"].Value != DBNull.Value)
                isActive = Convert.ToBoolean(selectedRow.Cells["IsActive"].Value);

            if (!isActive)
            {
                MessageBox.Show("Service is already inactive.");
                return;
            }

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("DeactivateService", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServiceID", serviceIdObj);

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", System.Data.SqlDbType.Int);
                    returnParameter.Direction = System.Data.ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    int result = (int)returnParameter.Value;

                    if (result == 1)
                    {
                        MessageBox.Show("Service deactivated successfully.");
                        LoadServices();
                    }
                    else if (result == 0)
                    {
                        MessageBox.Show("Service is already inactive.");
                    }
                    else
                    {
                        MessageBox.Show("Deactivation failed. Service not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deactivating service: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }
    }
}
