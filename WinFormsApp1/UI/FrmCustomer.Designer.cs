namespace Daddysanka.UI
{
    partial class FrmCustomer
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
            dgvCustomers = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            cmbFilter = new ComboBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1668, 100);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(590, 58);
            label1.TabIndex = 0;
            label1.Text = "Customer Management";
            label1.Click += label1_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AllowUserToResizeRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.LightCyan;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(499, 170);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.Size = new Size(1157, 682);
            dgvCustomers.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("SimSun-ExtG", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Blue;
            txtSearch.Location = new Point(499, 120);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(443, 31);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DeepSkyBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Baskerville Old Face", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(977, 120);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(81, 31);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbFilter
            // 
            cmbFilter.BackColor = SystemColors.InactiveCaption;
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(1221, 120);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(173, 33);
            cmbFilter.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("STIXSizeOneSym", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1140, 122);
            label2.Name = "label2";
            label2.Size = new Size(75, 26);
            label2.TabIndex = 5;
            label2.Text = "Filter by:";
            // 
            // FrmCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1668, 864);
            Controls.Add(label2);
            Controls.Add(cmbFilter);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvCustomers);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCustomer";
            Text = "FrmCustomer";
            Load += FrmCustomer_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView dgvCustomers;
        private TextBox txtSearch;
        private Button btnSearch;
        private ComboBox cmbFilter;
        private Label label2;
    }
}