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
    public partial class FrmHistory : Form
    {
        public FrmHistory()
        {
            InitializeComponent();
            LoadInvoices();
            txtSearch.PlaceholderText = "Enter name, Reg ID or Invoice ID to search";
            cmbFilter.SelectedIndex = 0;

            // Style for dgvInvoice
            dgvInvoice.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dgvInvoice.DefaultCellStyle.ForeColor = Color.Black;
            dgvInvoice.DefaultCellStyle.BackColor = Color.White;

            dgvInvoice.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvInvoice.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInvoice.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            dgvInvoice.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvInvoice.GridColor = Color.LightGray;
            dgvInvoice.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvInvoice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoice.RowTemplate.Height = 30;
            dgvInvoice.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvInvoice.DefaultCellStyle.SelectionForeColor = Color.White;

            // Style for dgvInvoiceDetails
            dgvInvoiceDetails.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dgvInvoiceDetails.DefaultCellStyle.ForeColor = Color.Blue;
            dgvInvoiceDetails.DefaultCellStyle.BackColor = Color.White;

            dgvInvoiceDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvInvoiceDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInvoiceDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;

            dgvInvoiceDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgvInvoiceDetails.GridColor = Color.LightGray;
            dgvInvoiceDetails.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvInvoiceDetails.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvInvoiceDetails.RowTemplate.Height = 40;
            dgvInvoiceDetails.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvInvoiceDetails.DefaultCellStyle.SelectionForeColor = Color.White;

            // Set the DataGridView to read-only
            dgvInvoice.ReadOnly = true;
            dgvInvoiceDetails.ReadOnly = true;

            dgvInvoice.CellClick += dgvInvoice_CellClick;



        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadInvoices()
        {
            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("GetAllInvoicesWithChildName", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvInvoice.DataSource = dt;
                        // Set column headers for clarity
                        dgvInvoice.Columns["DisplayName"].HeaderText = "Patient Name (RegID)";
                        dgvInvoice.Columns["InvoiceID"].HeaderText = "Invoice ID";
                        // Optionally hide ChildName and RegID columns if you only want DisplayName
                        dgvInvoice.Columns["ChildName"].Visible = false;
                        dgvInvoice.Columns["Notes"].Visible = false;
                        dgvInvoice.Columns["RegID"].Visible = false;

                    }
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
        private void LoadInvoiceDetails(int invoiceId)
        {
            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                    @"SELECT d.ServiceID, s.ServiceName, s.ServiceDescription, d.Quantity, d.UnitPrice, d.Discount, d.LineTotal
                      FROM InvoiceDetails d
                      INNER JOIN Services s ON d.ServiceID = s.ServiceID
                      WHERE d.InvoiceID = @InvoiceID",
                    Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                    using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvInvoiceDetails.DataSource = dt;

                        // Set column headers for clarity
                        dgvInvoiceDetails.Columns["LineTotal"].HeaderText = "Total";


                        dgvInvoiceDetails.Columns["ServiceDescription"].Visible = false;
                        dgvInvoiceDetails.Columns["ServiceID"].Visible = false;
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
        private void dgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvInvoice.Rows[e.RowIndex];
                int invoiceId = Convert.ToInt32(row.Cells["InvoiceID"].Value);
                LoadInvoiceDetails(invoiceId);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string filter = cmbFilter.SelectedItem?.ToString() ?? "All";
            DateTime? dateFrom = null, dateTo = null;
            DateTime now = DateTime.Now;

            switch (filter)
            {
                case "This Month":
                    dateFrom = new DateTime(now.Year, now.Month, 1);
                    dateTo = dateFrom.Value.AddMonths(1);
                    break;
                case "Last 3 Months":
                    dateFrom = new DateTime(now.Year, now.Month, 1).AddMonths(-2);
                    dateTo = new DateTime(now.Year, now.Month, 1).AddMonths(1);
                    break;
                case "This Year":
                    dateFrom = new DateTime(now.Year, 1, 1);
                    dateTo = dateFrom.Value.AddYears(1);
                    break;
                    // "All" leaves dateFrom and dateTo as null
            }

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("SearchInvoicesWithFilter", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchText", string.IsNullOrWhiteSpace(searchText) ? (object)DBNull.Value : searchText);
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom.HasValue ? (object)dateFrom.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTo", dateTo.HasValue ? (object)dateTo.Value : DBNull.Value);

                    using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvInvoice.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching invoices: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
