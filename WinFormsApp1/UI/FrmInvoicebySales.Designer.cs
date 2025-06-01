namespace DaddysLanka.UI
{
    partial class FrmInvoicebySales
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
            groupBox1 = new GroupBox();
            btnFilter = new Button();
            cmbTime = new ComboBox();
            label3 = new Label();
            cmbPayment = new ComboBox();
            label2 = new Label();
            dgvISales = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvISales).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1686, 100);
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
            label1.Size = new Size(422, 58);
            label1.TabIndex = 0;
            label1.Text = "Income by Sales";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(1686, 63);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnFilter);
            groupBox1.Controls.Add(cmbTime);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbPayment);
            groupBox1.Controls.Add(label2);
            groupBox1.ForeColor = Color.SteelBlue;
            groupBox1.Location = new Point(12, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(591, 51);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter Options";
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.SkyBlue;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Lucida Sans Typewriter", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(495, 16);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 24);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // cmbTime
            // 
            cmbTime.Font = new Font("MS Reference Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTime.FormattingEnabled = true;
            cmbTime.Items.AddRange(new object[] { "All", "Cash", "Bank" });
            cmbTime.Location = new Point(341, 15);
            cmbTime.Name = "cmbTime";
            cmbTime.Size = new Size(121, 24);
            cmbTime.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Sans Typewriter", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SlateGray;
            label3.Location = new Point(224, 20);
            label3.Name = "label3";
            label3.Size = new Size(111, 15);
            label3.TabIndex = 4;
            label3.Text = "Time Period :";
            // 
            // cmbPayment
            // 
            cmbPayment.Font = new Font("MS Reference Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbPayment.FormattingEnabled = true;
            cmbPayment.Items.AddRange(new object[] { "All", "Cash", "Bank" });
            cmbPayment.Location = new Point(81, 16);
            cmbPayment.Name = "cmbPayment";
            cmbPayment.Size = new Size(121, 24);
            cmbPayment.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Sans Typewriter", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SlateGray;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 0;
            label2.Text = "Payment :";
            // 
            // dgvISales
            // 
            dgvISales.AllowUserToAddRows = false;
            dgvISales.AllowUserToDeleteRows = false;
            dgvISales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvISales.BackgroundColor = Color.White;
            dgvISales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvISales.Dock = DockStyle.Fill;
            dgvISales.Location = new Point(0, 163);
            dgvISales.Name = "dgvISales";
            dgvISales.Size = new Size(1686, 726);
            dgvISales.TabIndex = 3;
            // 
            // FrmInvoicebySales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1686, 889);
            Controls.Add(dgvISales);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInvoicebySales";
            Text = "FrmInvoicebySales";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvISales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private DataGridView dgvISales;
        private GroupBox groupBox1;
        private ComboBox cmbTime;
        private Label label3;
        private ComboBox cmbPayment;
        private Label label2;
        private Button btnFilter;
    }
}