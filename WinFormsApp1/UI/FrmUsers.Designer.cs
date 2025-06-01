namespace Daddysanka.UI
{
    partial class FrmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsers));
            panel1 = new Panel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnSearch = new Button();
            label1 = new Label();
            dgvUsers = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            txtUName = new TextBox();
            txtPassword = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cmbRole = new ComboBox();
            btnInsert = new Button();
            btnClear = new Button();
            groupBox1 = new GroupBox();
            btnDeactivate = new Button();
            btnActivate = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1684, 122);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.AliceBlue;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.Black;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(1538, 40);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 44);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.AliceBlue;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.Black;
            btnUpdate.Image = (Image)resources.GetObject("btnUpdate.Image");
            btnUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpdate.Location = new Point(1392, 40);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 44);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.TextAlign = ContentAlignment.MiddleRight;
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.WhiteSmoke;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(1246, 40);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 44);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.TextAlign = ContentAlignment.MiddleRight;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(26, 19);
            label1.Name = "label1";
            label1.Size = new Size(590, 86);
            label1.TabIndex = 0;
            label1.Text = "User Management";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeColumns = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = SystemColors.ButtonHighlight;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Left;
            dgvUsers.GridColor = SystemColors.MenuHighlight;
            dgvUsers.Location = new Point(0, 122);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(1218, 739);
            dgvUsers.TabIndex = 1;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1270, 158);
            label2.Name = "label2";
            label2.Size = new Size(330, 50);
            label2.TabIndex = 2;
            label2.Text = "Enter User Details:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(1276, 228);
            label3.Name = "label3";
            label3.Size = new Size(121, 32);
            label3.TabIndex = 3;
            label3.Text = "Username";
            // 
            // txtUName
            // 
            txtUName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUName.ForeColor = Color.DimGray;
            txtUName.Location = new Point(1285, 273);
            txtUName.MaxLength = 64;
            txtUName.Name = "txtUName";
            txtUName.Size = new Size(353, 39);
            txtUName.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.DimGray;
            txtPassword.Location = new Point(1285, 399);
            txtPassword.MaxLength = 64;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(353, 35);
            txtPassword.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(1276, 364);
            label4.Name = "label4";
            label4.Size = new Size(111, 32);
            label4.TabIndex = 5;
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(1276, 500);
            label5.Name = "label5";
            label5.Size = new Size(60, 32);
            label5.TabIndex = 7;
            label5.Text = "Role";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRole.ForeColor = Color.DimGray;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Staff", "Accountant" });
            cmbRole.Location = new Point(1285, 550);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(353, 40);
            cmbRole.TabIndex = 8;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.RoyalBlue;
            btnInsert.FlatAppearance.BorderSize = 0;
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Arial Narrow", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInsert.ForeColor = Color.White;
            btnInsert.ImageAlign = ContentAlignment.MiddleLeft;
            btnInsert.Location = new Point(1246, 645);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(187, 64);
            btnInsert.TabIndex = 4;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += button4_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.RoyalBlue;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Narrow", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.ImageAlign = ContentAlignment.MiddleLeft;
            btnClear.Location = new Point(1471, 645);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(187, 64);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDeactivate);
            groupBox1.Controls.Add(btnActivate);
            groupBox1.Font = new Font("MS Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.MenuHighlight;
            groupBox1.Location = new Point(1246, 757);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(426, 83);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Status";
            // 
            // btnDeactivate
            // 
            btnDeactivate.BackColor = Color.RoyalBlue;
            btnDeactivate.FlatAppearance.BorderSize = 0;
            btnDeactivate.FlatStyle = FlatStyle.Flat;
            btnDeactivate.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeactivate.ForeColor = Color.White;
            btnDeactivate.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeactivate.Location = new Point(240, 32);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(152, 40);
            btnDeactivate.TabIndex = 12;
            btnDeactivate.Text = "Deactivate";
            btnDeactivate.UseVisualStyleBackColor = false;
            btnDeactivate.Click += btnDeactivate_Click;
            // 
            // btnActivate
            // 
            btnActivate.BackColor = Color.RoyalBlue;
            btnActivate.FlatAppearance.BorderSize = 0;
            btnActivate.FlatStyle = FlatStyle.Flat;
            btnActivate.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActivate.ForeColor = Color.White;
            btnActivate.ImageAlign = ContentAlignment.MiddleLeft;
            btnActivate.Location = new Point(39, 32);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(148, 40);
            btnActivate.TabIndex = 11;
            btnActivate.Text = "Activate";
            btnActivate.UseVisualStyleBackColor = false;
            btnActivate.Click += btnActivate_Click;
            // 
            // FrmUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1684, 861);
            Controls.Add(groupBox1);
            Controls.Add(btnClear);
            Controls.Add(btnInsert);
            Controls.Add(cmbRole);
            Controls.Add(label5);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtUName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvUsers);
            Controls.Add(panel1);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmUsers";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvUsers;
        private Label label1;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnSearch;
        private Label label2;
        private Label label3;
        private TextBox txtUName;
        private TextBox txtPassword;
        private Label label4;
        private Label label5;
        private ComboBox cmbRole;
        private Button btnInsert;
        private Button btnClear;
        private GroupBox groupBox1;
        private Button btnActivate;
        private Button btnDeactivate;
    }
}