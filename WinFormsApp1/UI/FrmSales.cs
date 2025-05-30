using DaddysLanka.Printing;
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
    public partial class FrmSales : Form
    {
        private DataTable allCustomers;
        private System.Windows.Forms.Timer filterTimer = new System.Windows.Forms.Timer();
        private string lastFilterText = "";
        private DataTable servicesTable;
        private DataTable tempInvoiceDetails;

        private void InitializeTempInvoiceDetails()
        {
            tempInvoiceDetails = new DataTable();
            tempInvoiceDetails.Columns.Add("ServiceID", typeof(int));
            tempInvoiceDetails.Columns.Add("Quantity", typeof(int));
            tempInvoiceDetails.Columns.Add("UnitPrice", typeof(decimal));
            tempInvoiceDetails.Columns.Add("Discount", typeof(decimal));
            tempInvoiceDetails.Columns.Add("LineTotal", typeof(decimal));
        }


        public FrmSales()
        {
            InitializeComponent();
            LoadCustomersToCombo();
            cmbCustomer.TextUpdate += cmbCustomer_TextUpdate;

            filterTimer.Interval = 300; // milliseconds  
            filterTimer.Tick += FilterTimer_Tick;

            dgvInvoice.CurrentCellDirtyStateChanged += dgvInvoice_CurrentCellDirtyStateChanged;

            dgvInvoice.CellPainting += dgvInvoice_CellPainting;



            LoadServices();
            SetupInvoiceGrid();
            InitializeTempInvoiceDetails();

            // Set Font and Style
            dgvInvoice.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dgvInvoice.DefaultCellStyle.ForeColor = Color.Blue;
            dgvInvoice.DefaultCellStyle.BackColor = Color.White;

            // Column Header Style
            dgvInvoice.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dgvInvoice.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInvoice.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;

            // Row Styles
            dgvInvoice.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control;

            // Gridlines and Borders
            dgvInvoice.GridColor = Color.LightBlue;
            dgvInvoice.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Row Height
            dgvInvoice.RowTemplate.Height = 40;

            // Selection Colors
            dgvInvoice.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvInvoice.DefaultCellStyle.SelectionForeColor = Color.White;

            // Column Sizing
            dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvInvoice.Columns["ServiceID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Service column takes remaining space

            // Adjust other columns to fit content
            foreach (DataGridViewColumn col in dgvInvoice.Columns)
            {
                if (col.Name != "ServiceID")
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }


        private void LoadServices()
        {
            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                    "SELECT ServiceID, ServiceName, ServiceDescription, ServicePrice FROM Services WHERE IsActive = 1",
                    Daddysanka.Database.DBConnection.Instance.Connection))
                using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    servicesTable = new DataTable();
                    adapter.Fill(servicesTable);
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

        private void SetupInvoiceGrid()
        {
            // Service ComboBox column (set Fill here)
            var serviceCol = new DataGridViewComboBoxColumn
            {
                Name = "ServiceID",
                HeaderText = "Service",
                DataPropertyName = "ServiceID",
                DisplayMember = "ServiceName",
                ValueMember = "ServiceID",
                DataSource = servicesTable,
                Width = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Set Fill here
            };
            dgvInvoice.Columns.Add(serviceCol);

            // Quantity
            var qtyCol = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Qty",
                DataPropertyName = "Quantity",
                Width = 60,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvInvoice.Columns.Add(qtyCol);

            // Unit Price (readonly)
            var unitPriceCol = new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Unit Price",
                DataPropertyName = "UnitPrice",
                ReadOnly = true,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvInvoice.Columns.Add(unitPriceCol);

            // Discount (%) (user input)
            var discountPercentCol = new DataGridViewTextBoxColumn
            {
                Name = "DiscountPercent",
                HeaderText = "Discount (%)",
                DataPropertyName = "DiscountPercent",
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvInvoice.Columns.Add(discountPercentCol);

            // Discount Value (readonly)
            var discountValueCol = new DataGridViewTextBoxColumn
            {
                Name = "DiscountValue",
                HeaderText = "Discount Value",
                DataPropertyName = "DiscountValue",
                ReadOnly = true,
                Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvInvoice.Columns.Add(discountValueCol);

            // Line Total (readonly)
            var lineTotalCol = new DataGridViewTextBoxColumn
            {
                Name = "LineTotal",
                HeaderText = "Total",
                DataPropertyName = "LineTotal",
                ReadOnly = true,
                Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvInvoice.Columns.Add(lineTotalCol);

            dgvInvoice.AllowUserToAddRows = true;
            dgvInvoice.AllowUserToDeleteRows = true;
            dgvInvoice.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvInvoice.CellValueChanged += dgvInvoice_CellValueChanged;
            dgvInvoice.EditingControlShowing += dgvInvoice_EditingControlShowing;
        }

        private void dgvInvoice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvInvoice.Rows[e.RowIndex];

            // Set UnitPrice when ServiceID changes
            if (dgvInvoice.Columns[e.ColumnIndex].Name == "ServiceID")
            {
                if (row.Cells["ServiceID"].Value != null)
                {
                    int serviceId = Convert.ToInt32(row.Cells["ServiceID"].Value);
                    var serviceRow = servicesTable.AsEnumerable().FirstOrDefault(r => r.Field<int>("ServiceID") == serviceId);
                    if (serviceRow != null)
                        row.Cells["UnitPrice"].Value = serviceRow.Field<decimal>("ServicePrice");


                    // Set default quantity to 1 if empty or zero
                    var quantityCell = row.Cells["Quantity"];
                    if (quantityCell.Value == null || string.IsNullOrWhiteSpace(quantityCell.Value.ToString()) || quantityCell.Value.ToString() == "0")
                    {
                        quantityCell.Value = 1;
                    }

                }
            }

            // Calculate DiscountValue and LineTotal
            if (dgvInvoice.Columns[e.ColumnIndex].Name == "Quantity" ||
                dgvInvoice.Columns[e.ColumnIndex].Name == "DiscountPercent" ||
                dgvInvoice.Columns[e.ColumnIndex].Name == "ServiceID")
            {
                int quantity = 1;
                decimal unitPrice = 0, discountPercent = 0;

                int.TryParse(row.Cells["Quantity"].Value?.ToString(), out quantity);
                decimal.TryParse(row.Cells["UnitPrice"].Value?.ToString(), out unitPrice);
                decimal.TryParse(row.Cells["DiscountPercent"].Value?.ToString(), out discountPercent);

                decimal discountValue = Math.Round((unitPrice * quantity) * (discountPercent / 100), 2);
                row.Cells["DiscountValue"].Value = discountValue;

                decimal lineTotal = (unitPrice * quantity) - discountValue;
                row.Cells["LineTotal"].Value = lineTotal;
            }

            UpdateFinalTotal();
        }

        private void dgvInvoice_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvInvoice.CurrentCell.ColumnIndex == dgvInvoice.Columns["Quantity"].Index ||
                dgvInvoice.CurrentCell.ColumnIndex == dgvInvoice.Columns["DiscountPercent"].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= Numeric_KeyPress;
                    tb.KeyPress += Numeric_KeyPress;
                }
            }
            // Set ComboBox background color to match row color
            if (dgvInvoice.CurrentCell.ColumnIndex == dgvInvoice.Columns["ServiceID"].Index)
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    int rowIndex = dgvInvoice.CurrentCell.RowIndex;
                    Color backColor = (rowIndex % 2 == 0)
                        ? dgvInvoice.DefaultCellStyle.BackColor
                        : dgvInvoice.AlternatingRowsDefaultCellStyle.BackColor;
                    cb.BackColor = backColor;
                    cb.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        private void SyncInvoiceGridToTempTable()
        {
            tempInvoiceDetails.Clear();
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["ServiceID"].Value == null) continue;

                int serviceId = Convert.ToInt32(row.Cells["ServiceID"].Value);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 1);
                decimal unitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value ?? 0);
                decimal discount = Convert.ToDecimal(row.Cells["DiscountValue"].Value ?? 0);
                decimal lineTotal = Convert.ToDecimal(row.Cells["LineTotal"].Value ?? 0);

                tempInvoiceDetails.Rows.Add(serviceId, quantity, unitPrice, discount, lineTotal);
            }
        }


        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, control chars, and one dot for decimals
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            // Only one decimal point
            TextBox tb = sender as TextBox;
            if (e.KeyChar == '.' && tb != null && tb.Text.Contains('.'))
                e.Handled = true;
        }



        private void FrmSales_Load(object sender, EventArgs e)
        {
        }

        private void LoadCustomersToCombo()
        {
            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand("GetCustomerList", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        allCustomers = new DataTable();
                        adapter.Fill(allCustomers);

                        cmbCustomer.DataSource = allCustomers.Copy();
                        cmbCustomer.DisplayMember = "DisplayName";
                        cmbCustomer.ValueMember = "RegID";
                        cmbCustomer.SelectedIndex = -1;

                        cmbCustomer.DropDownStyle = ComboBoxStyle.DropDown;
                    }
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

        private void cmbCustomer_TextUpdate(object sender, EventArgs e)
        {
            filterTimer.Stop();
            filterTimer.Start();
        }

        private void FilterTimer_Tick(object sender, EventArgs e)
        {
            filterTimer.Stop();

            string filterText = cmbCustomer.Text.Trim().ToLower();

            if (allCustomers == null)
                return;

            if (filterText == lastFilterText)
                return;

            lastFilterText = filterText;

            DataTable filteredTable;
            if (string.IsNullOrEmpty(filterText))
            {
                filteredTable = allCustomers.Copy();
            }
            else
            {
                var rows = allCustomers.AsEnumerable()
                    .Where(row => row.Field<string>("DisplayName").ToLower().Contains(filterText))
                    .ToArray();

                filteredTable = allCustomers.Clone();
                foreach (var row in rows)
                    filteredTable.ImportRow(row);
            }

            // Save current text  
            string currentText = cmbCustomer.Text;

            cmbCustomer.DataSource = filteredTable;
            cmbCustomer.DisplayMember = "DisplayName";
            cmbCustomer.ValueMember = "RegID";
            cmbCustomer.DroppedDown = true;
            cmbCustomer.Text = currentText;
            cmbCustomer.SelectionStart = cmbCustomer.Text.Length;
            cmbCustomer.SelectionLength = 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Validate customer selection and invoice rows
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }
            if (cmbPaynent.SelectedItem == null || string.IsNullOrWhiteSpace(cmbPaynent.Text))
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }
            SyncInvoiceGridToTempTable();
            if (tempInvoiceDetails.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one service.");
                return;
            }

            string regId = cmbCustomer.SelectedValue.ToString();
            decimal totalAmount = tempInvoiceDetails.AsEnumerable().Sum(r => r.Field<decimal>("LineTotal"));
            string paymentMethod = cmbPaynent.Text.Trim();
            string notes = ""; // Or get from UI

            // Build confirmation message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please confirm the invoice details:");
            sb.AppendLine();
            sb.AppendLine($"Customer      : {cmbCustomer.Text}");
            sb.AppendLine($"Payment Method: {paymentMethod}");
            sb.AppendLine($"Total Amount  : {totalAmount:C}");
            sb.AppendLine();
            sb.AppendLine("Services:");
            sb.AppendLine("-------------------------------------------------------------");
            sb.AppendLine("Service Name           Qty   Unit Price   Discount   Line Total");
            sb.AppendLine("-------------------------------------------------------------");

            foreach (DataRow dr in tempInvoiceDetails.Rows)
            {
                var serviceName = servicesTable.AsEnumerable()
                    .FirstOrDefault(r => r.Field<int>("ServiceID") == (int)dr["ServiceID"])
                    ?.Field<string>("ServiceName") ?? "Unknown";
                string qty = dr["Quantity"].ToString();
                string unit = string.Format("{0:N2}", dr["UnitPrice"]);
                string discount = string.Format("{0:N2}", dr["Discount"]);
                string lineTotal = string.Format("{0:N2}", dr["LineTotal"]);

                sb.AppendLine($"{serviceName,-20} {qty,3}   {unit,10}   {discount,8}   {lineTotal,10}");
            }
            sb.AppendLine("-------------------------------------------------------------");


            var result = MessageBox.Show(sb.ToString(), "Confirm Invoice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK)
                return;

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var tran = Daddysanka.Database.DBConnection.Instance.Connection.BeginTransaction())
                {
                    // Insert Invoice
                    int invoiceId;
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                        @"INSERT INTO Invoice (RegID, TotalAmount, PaymentMethod, Notes) 
                  VALUES (@RegID, @TotalAmount, @PaymentMethod, @Notes);
                  SELECT SCOPE_IDENTITY();",
                        Daddysanka.Database.DBConnection.Instance.Connection, tran))
                    {
                        cmd.Parameters.AddWithValue("@RegID", regId);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                        cmd.Parameters.AddWithValue("@Notes", notes);
                        invoiceId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Insert InvoiceDetails
                    foreach (DataRow dr in tempInvoiceDetails.Rows)
                    {
                        using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                            @"INSERT INTO InvoiceDetails (InvoiceID, ServiceID, Quantity, UnitPrice, Discount)
                      VALUES (@InvoiceID, @ServiceID, @Quantity, @UnitPrice, @Discount)",
                            Daddysanka.Database.DBConnection.Instance.Connection, tran))
                        {
                            cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                            cmd.Parameters.AddWithValue("@ServiceID", dr["ServiceID"]);
                            cmd.Parameters.AddWithValue("@Quantity", dr["Quantity"]);
                            cmd.Parameters.AddWithValue("@UnitPrice", dr["UnitPrice"]);
                            cmd.Parameters.AddWithValue("@Discount", dr["Discount"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    MessageBox.Show("Invoice saved successfully.");
                    InvoicePrintHelper.PrintInvoice(
                        cmbCustomer.Text,
                        cmbPaynent.Text,
                        totalAmount,
                        tempInvoiceDetails,
                        servicesTable,
                        notes
                    );

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving invoice: " + ex.Message);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }
        private void dgvInvoice_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInvoice.IsCurrentCellDirty && dgvInvoice.CurrentCell is DataGridViewComboBoxCell)
            {
                dgvInvoice.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dgvInvoice_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvInvoice.Columns["ServiceID"].Index && e.RowIndex >= 0)
            {
                // Use the same color as the alternating row or default row
                Color backColor = (e.RowIndex % 2 == 0)
                    ? dgvInvoice.DefaultCellStyle.BackColor
                    : dgvInvoice.AlternatingRowsDefaultCellStyle.BackColor;

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset customer ComboBox
            cmbCustomer.SelectedIndex = -1;
            cmbCustomer.Text = string.Empty;

            // Reset payment ComboBox
            cmbPaynent.SelectedIndex = -1;
            cmbPaynent.Text = string.Empty;

            // Reset all DateTimePickers on the form
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is DateTimePicker dtp)
                    dtp.Value = DateTime.Now;
            }

            // Clear DataGridView rows
            dgvInvoice.Rows.Clear();

            // Optionally, clear any temporary invoice details
            tempInvoiceDetails?.Clear();

            UpdateFinalTotal();

        }
        private void UpdateFinalTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["LineTotal"].Value != null && decimal.TryParse(row.Cells["LineTotal"].Value.ToString(), out decimal lineTotal))
                {
                    total += lineTotal;
                }
            }
            lblTotal.Text = $"{total:N2}";
        }

        private void dgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
