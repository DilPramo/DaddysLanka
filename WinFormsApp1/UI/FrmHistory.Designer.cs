namespace DaddysLanka.UI
{
    partial class FrmHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            cmbFilter = new ComboBox();
            label4 = new Label();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dgvInvoiceDetails = new DataGridView();
            dgvInvoice = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1684, 100);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(394, 58);
            label1.TabIndex = 0;
            label1.Text = "Invoice History";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(cmbFilter);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(txtSearch);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(1684, 54);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // cmbFilter
            // 
            cmbFilter.Font = new Font("Maiandra GD", 15.75F);
            cmbFilter.ForeColor = Color.DarkBlue;
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "All ", "This Month", "Last 3 month", "This Year" });
            cmbFilter.Location = new Point(651, 12);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(189, 33);
            cmbFilter.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Maiandra GD", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(526, 17);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 2;
            label4.Text = "Filter By:";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DodgerBlue;
            btnSearch.FlatAppearance.BorderColor = Color.Yellow;
            btnSearch.FlatAppearance.BorderSize = 5;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            btnSearch.Font = new Font("Microsoft Tai Le", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(408, 8);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(92, 39);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.AliceBlue;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Microsoft YaHei", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.DarkBlue;
            txtSearch.Location = new Point(12, 11);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(372, 35);
            txtSearch.TabIndex = 0;
            // 
            // dgvInvoiceDetails
            // 
            dgvInvoiceDetails.AllowUserToAddRows = false;
            dgvInvoiceDetails.AllowUserToDeleteRows = false;
            dgvInvoiceDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoiceDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoiceDetails.Dock = DockStyle.Bottom;
            dgvInvoiceDetails.Location = new Point(0, 637);
            dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            dgvInvoiceDetails.Size = new Size(1684, 224);
            dgvInvoiceDetails.TabIndex = 3;
            // 
            // dgvInvoice
            // 
            dgvInvoice.AllowUserToAddRows = false;
            dgvInvoice.AllowUserToDeleteRows = false;
            dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoice.Location = new Point(0, 192);
            dgvInvoice.Name = "dgvInvoice";
            dgvInvoice.Size = new Size(1684, 411);
            dgvInvoice.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Tai Le", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 157);
            label2.Name = "label2";
            label2.Size = new Size(131, 30);
            label2.TabIndex = 5;
            label2.Text = "Invoice List";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Tai Le", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 606);
            label3.Name = "label3";
            label3.Size = new Size(168, 30);
            label3.TabIndex = 6;
            label3.Text = "Invoice Details";
            // 
            // FrmHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1684, 861);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvInvoice);
            Controls.Add(dgvInvoiceDetails);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmHistory";
            Text = "FrmHistory";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private DataGridView dgvInvoiceDetails;
        private DataGridView dgvInvoice;
        private Label label2;
        private Label label3;
        private TextBox txtSearch;
        private ComboBox cmbFilter;
        private Label label4;
        private Button btnSearch;
    }
}