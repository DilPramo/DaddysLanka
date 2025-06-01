namespace DaddysLanka.UI
{
    partial class FrmInvoicebyService
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
            cmbCategory = new ComboBox();
            label2 = new Label();
            dgvIService = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIService).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1670, 100);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(471, 58);
            label1.TabIndex = 0;
            label1.Text = "Income by Service";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(1670, 63);
            panel2.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnFilter);
            groupBox1.Controls.Add(cmbTime);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbCategory);
            groupBox1.Controls.Add(label2);
            groupBox1.ForeColor = Color.SteelBlue;
            groupBox1.Location = new Point(12, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(894, 51);
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
            btnFilter.Location = new Point(793, 18);
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
            cmbTime.Location = new Point(639, 17);
            cmbTime.Name = "cmbTime";
            cmbTime.Size = new Size(121, 24);
            cmbTime.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Sans Typewriter", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SlateGray;
            label3.Location = new Point(522, 22);
            label3.Name = "label3";
            label3.Size = new Size(111, 15);
            label3.TabIndex = 4;
            label3.Text = "Time Period :";
            // 
            // cmbCategory
            // 
            cmbCategory.Font = new Font("MS Reference Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "All", "Cash", "Bank" });
            cmbCategory.Location = new Point(93, 16);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(387, 24);
            cmbCategory.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Sans Typewriter", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SlateGray;
            label2.Location = new Point(0, 21);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 0;
            label2.Text = "Category :";
            // 
            // dgvIService
            // 
            dgvIService.AllowUserToAddRows = false;
            dgvIService.AllowUserToDeleteRows = false;
            dgvIService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIService.BackgroundColor = Color.White;
            dgvIService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIService.Dock = DockStyle.Fill;
            dgvIService.GridColor = Color.White;
            dgvIService.Location = new Point(0, 163);
            dgvIService.Name = "dgvIService";
            dgvIService.Size = new Size(1670, 687);
            dgvIService.TabIndex = 4;
            dgvIService.CellContentClick += dgvIService_CellContentClick;
            // 
            // FrmInvoicebyService
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1670, 850);
            Controls.Add(dgvIService);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInvoicebyService";
            Text = "FrmInvoicebyService";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIService).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private GroupBox groupBox1;
        private Button btnFilter;
        private ComboBox cmbTime;
        private Label label3;
        private ComboBox cmbCategory;
        private Label label2;
        private DataGridView dgvIService;
    }
}