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
            btnActivate = new Button();
            btnDeactivate = new Button();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label4 = new Label();
            txtRegNo = new TextBox();
            label5 = new Label();
            txtFName = new TextBox();
            label6 = new Label();
            txtLname = new TextBox();
            label7 = new Label();
            txtGaurdian = new TextBox();
            label8 = new Label();
            dtpDOB = new DateTimePicker();
            label9 = new Label();
            txtAddress = new TextBox();
            label10 = new Label();
            txtContact = new TextBox();
            label11 = new Label();
            txtEmail = new TextBox();
            label12 = new Label();
            txtEmergency = new TextBox();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            groupBox1.SuspendLayout();
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
            cmbFilter.Location = new Point(1173, 120);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(173, 33);
            cmbFilter.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("STIXSizeOneSym", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1092, 122);
            label2.Name = "label2";
            label2.Size = new Size(75, 26);
            label2.TabIndex = 5;
            label2.Text = "Filter by:";
            // 
            // btnActivate
            // 
            btnActivate.BackColor = Color.LightSkyBlue;
            btnActivate.Font = new Font("MS PGothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActivate.ForeColor = Color.White;
            btnActivate.Location = new Point(6, 22);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(99, 31);
            btnActivate.TabIndex = 6;
            btnActivate.Text = "Activate";
            btnActivate.UseVisualStyleBackColor = false;
            btnActivate.Click += btnActivate_Click;
            // 
            // btnDeactivate
            // 
            btnDeactivate.BackColor = Color.LightSkyBlue;
            btnDeactivate.Font = new Font("MS PGothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeactivate.ForeColor = Color.White;
            btnDeactivate.Location = new Point(111, 22);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(99, 31);
            btnDeactivate.TabIndex = 7;
            btnDeactivate.Text = "Deactivate";
            btnDeactivate.UseVisualStyleBackColor = false;
            btnDeactivate.Click += btnDeactivate_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnActivate);
            groupBox1.Controls.Add(btnDeactivate);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.ForeColor = Color.Red;
            groupBox1.Location = new Point(1397, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(217, 59);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Delete";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Poor Richard", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.MenuHighlight;
            label3.Location = new Point(98, 116);
            label3.Name = "label3";
            label3.Size = new Size(187, 41);
            label3.TabIndex = 6;
            label3.Text = "Enter Details";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Papyrus", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.CadetBlue;
            label4.Location = new Point(12, 170);
            label4.Name = "label4";
            label4.Size = new Size(129, 25);
            label4.TabIndex = 7;
            label4.Text = "Registration No.";
            // 
            // txtRegNo
            // 
            txtRegNo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegNo.ForeColor = Color.Blue;
            txtRegNo.Location = new Point(39, 198);
            txtRegNo.MaxLength = 50;
            txtRegNo.Name = "txtRegNo";
            txtRegNo.Size = new Size(317, 27);
            txtRegNo.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Papyrus", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.CadetBlue;
            label5.Location = new Point(12, 238);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 9;
            label5.Text = "First Name";
            // 
            // txtFName
            // 
            txtFName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFName.ForeColor = Color.Blue;
            txtFName.Location = new Point(39, 266);
            txtFName.MaxLength = 50;
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(317, 27);
            txtFName.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Papyrus", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.CadetBlue;
            label6.Location = new Point(12, 306);
            label6.Name = "label6";
            label6.Size = new Size(89, 25);
            label6.TabIndex = 11;
            label6.Text = "Last Name";
            // 
            // txtLname
            // 
            txtLname.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLname.ForeColor = Color.Blue;
            txtLname.Location = new Point(39, 334);
            txtLname.MaxLength = 50;
            txtLname.Name = "txtLname";
            txtLname.Size = new Size(317, 27);
            txtLname.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Papyrus", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.CadetBlue;
            label7.Location = new Point(12, 374);
            label7.Name = "label7";
            label7.Size = new Size(121, 25);
            label7.TabIndex = 13;
            label7.Text = "Gaurdian Name";
            // 
            // txtGaurdian
            // 
            txtGaurdian.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGaurdian.ForeColor = Color.Blue;
            txtGaurdian.Location = new Point(39, 402);
            txtGaurdian.MaxLength = 100;
            txtGaurdian.Name = "txtGaurdian";
            txtGaurdian.Size = new Size(317, 27);
            txtGaurdian.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Papyrus", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.CadetBlue;
            label8.Location = new Point(12, 441);
            label8.Name = "label8";
            label8.Size = new Size(110, 25);
            label8.TabIndex = 15;
            label8.Text = "Date of Birth";
            // 
            // dtpDOB
            // 
            dtpDOB.CustomFormat = "dd - MM - yyyy";
            dtpDOB.Font = new Font("Rockwell", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.Location = new Point(39, 469);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.ShowUpDown = true;
            dtpDOB.Size = new Size(317, 26);
            dtpDOB.TabIndex = 16;
            dtpDOB.Value = new DateTime(2025, 5, 26, 0, 0, 0, 0);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Papyrus", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.CadetBlue;
            label9.Location = new Point(12, 513);
            label9.Name = "label9";
            label9.Size = new Size(73, 25);
            label9.TabIndex = 17;
            label9.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.ForeColor = Color.Blue;
            txtAddress.Location = new Point(39, 541);
            txtAddress.MaxLength = 255;
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(317, 23);
            txtAddress.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Papyrus", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.CadetBlue;
            label10.Location = new Point(12, 582);
            label10.Name = "label10";
            label10.Size = new Size(104, 25);
            label10.TabIndex = 19;
            label10.Text = "Contact No.";
            label10.Click += label10_Click;
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContact.ForeColor = Color.Blue;
            txtContact.Location = new Point(39, 610);
            txtContact.MaxLength = 20;
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(317, 27);
            txtContact.TabIndex = 20;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Papyrus", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.CadetBlue;
            label11.Location = new Point(12, 650);
            label11.Name = "label11";
            label11.Size = new Size(51, 25);
            label11.TabIndex = 21;
            label11.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.Blue;
            txtEmail.Location = new Point(39, 678);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(317, 27);
            txtEmail.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Papyrus", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.CadetBlue;
            label12.Location = new Point(12, 717);
            label12.Name = "label12";
            label12.Size = new Size(154, 25);
            label12.TabIndex = 23;
            label12.Text = "Emergency Contact";
            // 
            // txtEmergency
            // 
            txtEmergency.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmergency.ForeColor = Color.Blue;
            txtEmergency.Location = new Point(39, 745);
            txtEmergency.MaxLength = 100;
            txtEmergency.Name = "txtEmergency";
            txtEmergency.Size = new Size(317, 27);
            txtEmergency.TabIndex = 24;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.DodgerBlue;
            btnInsert.FlatAppearance.BorderColor = Color.Blue;
            btnInsert.Font = new Font("MS PGothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(6, 809);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(127, 43);
            btnInsert.TabIndex = 25;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DodgerBlue;
            btnUpdate.FlatAppearance.BorderColor = Color.Blue;
            btnUpdate.FlatAppearance.BorderSize = 2;
            btnUpdate.Font = new Font("MS PGothic", 15.75F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(164, 809);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(129, 43);
            btnUpdate.TabIndex = 26;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DodgerBlue;
            btnClear.FlatAppearance.BorderColor = Color.Blue;
            btnClear.Font = new Font("MS PGothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(321, 809);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(132, 43);
            btnClear.TabIndex = 27;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // FrmCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1668, 864);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(txtEmergency);
            Controls.Add(label12);
            Controls.Add(txtEmail);
            Controls.Add(label11);
            Controls.Add(txtContact);
            Controls.Add(label10);
            Controls.Add(txtAddress);
            Controls.Add(label9);
            Controls.Add(dtpDOB);
            Controls.Add(label8);
            Controls.Add(txtGaurdian);
            Controls.Add(label7);
            Controls.Add(txtLname);
            Controls.Add(label6);
            Controls.Add(txtFName);
            Controls.Add(label5);
            Controls.Add(txtRegNo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(groupBox1);
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
            groupBox1.ResumeLayout(false);
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
        private Button btnActivate;
        private Button btnDeactivate;
        private GroupBox groupBox1;
        private Label label3;
        private Label label4;
        private TextBox txtRegNo;
        private Label label5;
        private TextBox txtFName;
        private Label label6;
        private TextBox txtLname;
        private Label label7;
        private TextBox txtGaurdian;
        private Label label8;
        private DateTimePicker dtpDOB;
        private Label label9;
        private TextBox txtAddress;
        private Label label10;
        private TextBox txtContact;
        private Label label11;
        private TextBox txtEmail;
        private Label label12;
        private TextBox txtEmergency;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnClear;
    }
}