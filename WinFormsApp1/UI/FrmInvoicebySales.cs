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
    public partial class FrmInvoicebySales : Form
    {
        public FrmInvoicebySales()
        {
            InitializeComponent();
            StyleDgvISales();
            LoadInvoices();
            cmbPayment.SelectedIndex = 0;
           PopulateTimeFilters();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadInvoices()
        {
            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT * FROM Invoice", Daddysanka.Database.DBConnection.Instance.Connection))
                using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvISales.DataSource = dt;

                    // Hide RegID and Notes columns if they exist
                    if (dgvISales.Columns.Contains("RegID"))
                        dgvISales.Columns["RegID"].Visible = false;
                    if (dgvISales.Columns.Contains("Notes"))
                        dgvISales.Columns["Notes"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoices: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void StyleDgvISales()
        {
            // Set Font and Style
            dgvISales.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dgvISales.DefaultCellStyle.ForeColor = Color.Black;
            dgvISales.DefaultCellStyle.BackColor = Color.White;

            // Column Header Style
            dgvISales.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvISales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvISales.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            // Row Styles
            dgvISales.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Gridlines and Borders
            dgvISales.GridColor = Color.LightGray;
            dgvISales.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Text Alignment
            dgvISales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Row Height
            dgvISales.RowTemplate.Height = 30;

            // Selection Colors
            dgvISales.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvISales.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string paymentMethod = cmbPayment.SelectedItem?.ToString();
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
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand())
                {
                    cmd.Connection = Daddysanka.Database.DBConnection.Instance.Connection;

                    // Build SQL dynamically for filtering
                    var sql = new StringBuilder("SELECT * FROM Invoice WHERE 1=1");

                    if (!string.IsNullOrWhiteSpace(paymentMethod) && paymentMethod != "All")
                    {
                        sql.Append(" AND PaymentMethod = @PaymentMethod");
                        cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    }
                    if (dateFrom.HasValue && dateTo.HasValue)
                    {
                        sql.Append(" AND InvoiceDate >= @DateFrom AND InvoiceDate < @DateTo");
                        cmd.Parameters.AddWithValue("@DateFrom", dateFrom.Value);
                        cmd.Parameters.AddWithValue("@DateTo", dateTo.Value);
                    }

                    cmd.CommandText = sql.ToString();

                    using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvISales.DataSource = dt;

                        // Hide RegID and Notes columns if they exist
                        if (dgvISales.Columns.Contains("RegID"))
                            dgvISales.Columns["RegID"].Visible = false;
                        if (dgvISales.Columns.Contains("Notes"))
                            dgvISales.Columns["Notes"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering invoices: " + ex.Message);
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
    }
}
