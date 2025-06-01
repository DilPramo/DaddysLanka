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
    public partial class FrmInvoicebyService : Form
    {
        public FrmInvoicebyService()
        {
            InitializeComponent();
            StyleDgvIServices();
            LoadInvoiceDetails();
            PopulateTimeFilters();
            PopulateCategories();
        }

        private void dgvIService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadInvoiceDetails()
        {
            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("GetAllInvoiceDetailsWithServiceName2", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvIService.DataSource = dt;

                        // Hide ServiceID column
                        if (dgvIService.Columns.Contains("ServiceID"))
                            dgvIService.Columns["ServiceID"].Visible = false;

                        // Set custom header for ServiceName
                        if (dgvIService.Columns.Contains("ServiceName"))
                            dgvIService.Columns["ServiceName"].HeaderText = "Service Name";

                        // Set custom header and format for InvoiceDate
                        if (dgvIService.Columns.Contains("InvoiceDate"))
                        {
                            dgvIService.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                            dgvIService.Columns["InvoiceDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoice details: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void PopulateTimeFilters()
        {
            cmbTime.Items.Clear();
            cmbTime.Items.Add("All Time");
            cmbTime.Items.Add("This Week");
            cmbTime.Items.Add("This Month");
            cmbTime.Items.Add("Last Month");
            cmbTime.Items.Add("This Quarter");
            cmbTime.Items.Add("Last Quarter");
            cmbTime.Items.Add("This Year");
            cmbTime.Items.Add("Last Year");
            cmbTime.SelectedIndex = 0;
        }
        private void PopulateCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories"); // Default option

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                    @"SELECT DISTINCT s.ServiceName
                      FROM InvoiceDetails d
                      INNER JOIN Services s ON d.ServiceID = s.ServiceID",
                    Daddysanka.Database.DBConnection.Instance.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            cmbCategory.Items.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }

            cmbCategory.SelectedIndex = 0; // Select "All Categories" by default
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string category = cmbCategory.SelectedItem?.ToString();
            string timeFilter = cmbTime.SelectedItem?.ToString();

            DateTime? dateFrom = null, dateTo = null;
            DateTime now = DateTime.Now;

            // Time filter logic
            switch (timeFilter)
            {
                case "This Week":
                    int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;
                    dateFrom = now.Date.AddDays(-1 * diff);
                    dateTo = dateFrom.Value.AddDays(7);
                    break;
                case "This Month":
                    dateFrom = new DateTime(now.Year, now.Month, 1);
                    dateTo = dateFrom.Value.AddMonths(1);
                    break;
                case "Last Month":
                    dateFrom = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
                    dateTo = new DateTime(now.Year, now.Month, 1);
                    break;
                case "This Quarter":
                    int currentQuarter = (now.Month - 1) / 3 + 1;
                    dateFrom = new DateTime(now.Year, (currentQuarter - 1) * 3 + 1, 1);
                    dateTo = dateFrom.Value.AddMonths(3);
                    break;
                case "Last Quarter":
                    int lastQuarter = ((now.Month - 1) / 3);
                    int lastQuarterYear = now.Year;
                    if (lastQuarter == 0)
                    {
                        lastQuarter = 4;
                        lastQuarterYear--;
                    }
                    dateFrom = new DateTime(lastQuarterYear, (lastQuarter - 1) * 3 + 1, 1);
                    dateTo = dateFrom.Value.AddMonths(3);
                    break;
                case "This Year":
                    dateFrom = new DateTime(now.Year, 1, 1);
                    dateTo = dateFrom.Value.AddYears(1);
                    break;
                case "Last Year":
                    dateFrom = new DateTime(now.Year - 1, 1, 1);
                    dateTo = new DateTime(now.Year, 1, 1);
                    break;
                    // "All Time" or any other: leave dateFrom and dateTo as null
            }

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("FilterInvoiceDetailsByServiceAndDate", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Only pass ServiceName if not "All Categories"
                    if (!string.IsNullOrWhiteSpace(category) && category != "All Categories")
                        cmd.Parameters.AddWithValue("@ServiceName", category);
                    else
                        cmd.Parameters.AddWithValue("@ServiceName", DBNull.Value);

                    // Only pass dates if set
                    if (dateFrom.HasValue)
                        cmd.Parameters.AddWithValue("@DateFrom", dateFrom.Value);
                    else
                        cmd.Parameters.AddWithValue("@DateFrom", DBNull.Value);

                    if (dateTo.HasValue)
                        cmd.Parameters.AddWithValue("@DateTo", dateTo.Value);
                    else
                        cmd.Parameters.AddWithValue("@DateTo", DBNull.Value);

                    using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvIService.DataSource = dt;

                        // Hide ServiceID column
                        if (dgvIService.Columns.Contains("ServiceID"))
                            dgvIService.Columns["ServiceID"].Visible = false;

                        // Set custom header for ServiceName
                        if (dgvIService.Columns.Contains("ServiceName"))
                            dgvIService.Columns["ServiceName"].HeaderText = "Service Name";

                        // Set custom header and format for InvoiceDate
                        if (dgvIService.Columns.Contains("InvoiceDate"))
                        {
                            dgvIService.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                            dgvIService.Columns["InvoiceDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering invoice details: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }
        private void StyleDgvIServices()
        {
            // Set Font and Style
            dgvIService.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dgvIService.DefaultCellStyle.ForeColor = Color.Black;
            dgvIService.DefaultCellStyle.BackColor = Color.White;

            // Column Header Style
            dgvIService.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvIService.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIService.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            // Row Styles
            dgvIService.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            // Gridlines and Borders
            dgvIService.GridColor = Color.LightGray;
            dgvIService.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Text Alignment
            dgvIService.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Row Height
            dgvIService.RowTemplate.Height = 30;

            // Selection Colors
            dgvIService.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvIService.DefaultCellStyle.SelectionForeColor = Color.White;
        }

    }
}
