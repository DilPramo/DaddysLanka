namespace DaddysLanka.UI
{
    partial class FrmSales
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
            cmbCustomer = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            cmbPaynent = new ComboBox();
            dgvInvoice = new DataGridView();
            btnPrint = new Button();
            btnClear = new Button();
            label4 = new Label();
            lblTotal = new Label();
            panel1.SuspendLayout();
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
            panel1.Size = new Size(1684, 72);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 36F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(205, 58);
            label1.TabIndex = 0;
            label1.Text = "Invoice";
            // 
            // cmbCustomer
            // 
            cmbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCustomer.Font = new Font("Yu Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(250, 153);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(391, 39);
            cmbCustomer.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Display", 20.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 153);
            label2.Name = "label2";
            label2.Size = new Size(196, 39);
            label2.TabIndex = 2;
            label2.Text = "Child or Patient :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Display", 20.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 237);
            label3.Name = "label3";
            label3.Size = new Size(210, 39);
            label3.TabIndex = 3;
            label3.Text = "Payment Method :";
            // 
            // cmbPaynent
            // 
            cmbPaynent.BackColor = Color.White;
            cmbPaynent.Font = new Font("Yu Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbPaynent.FormattingEnabled = true;
            cmbPaynent.Items.AddRange(new object[] { "Bank", "Cash" });
            cmbPaynent.Location = new Point(250, 237);
            cmbPaynent.Name = "cmbPaynent";
            cmbPaynent.Size = new Size(193, 39);
            cmbPaynent.TabIndex = 4;
            // 
            // dgvInvoice
            // 
            dgvInvoice.AllowUserToDeleteRows = false;
            dgvInvoice.AllowUserToResizeColumns = false;
            dgvInvoice.AllowUserToResizeRows = false;
            dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoice.BackgroundColor = Color.White;
            dgvInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoice.Location = new Point(0, 312);
            dgvInvoice.Name = "dgvInvoice";
            dgvInvoice.Size = new Size(1684, 469);
            dgvInvoice.TabIndex = 5;
            dgvInvoice.CellContentClick += dgvInvoice_CellContentClick;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.Aqua;
            btnPrint.FlatAppearance.BorderColor = Color.Black;
            btnPrint.FlatAppearance.BorderSize = 5;
            btnPrint.FlatStyle = FlatStyle.Popup;
            btnPrint.Font = new Font("Microsoft New Tai Lue", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(1555, 802);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(96, 47);
            btnPrint.TabIndex = 6;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.LightSteelBlue;
            btnClear.FlatAppearance.BorderColor = Color.White;
            btnClear.FlatAppearance.BorderSize = 5;
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Font = new Font("Microsoft New Tai Lue", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(1387, 802);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(93, 47);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Nirmala UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(1512, 196);
            label4.Name = "label4";
            label4.Size = new Size(125, 32);
            label4.TabIndex = 8;
            label4.Text = "Total (LKR)";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = SystemColors.AppWorkspace;
            lblTotal.Font = new Font("Nirmala UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.Snow;
            lblTotal.Location = new Point(1520, 237);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(78, 40);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmSales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 861);
            Controls.Add(lblTotal);
            Controls.Add(label4);
            Controls.Add(btnClear);
            Controls.Add(btnPrint);
            Controls.Add(dgvInvoice);
            Controls.Add(cmbPaynent);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbCustomer);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmSales";
            Text = "FrmSales";
            Load += FrmSales_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox cmbCustomer;
        private Label label2;
        private Label label3;
        private ComboBox cmbPaynent;
        private DataGridView dgvInvoice;
        private Button btnPrint;
        private Button btnClear;
        private Label label4;
        private Label lblTotal;
    }
}