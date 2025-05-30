namespace DaddysLanka.UI
{
    partial class FrmServices
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
            btnDeactivate = new Button();
            btnActivate = new Button();
            btnRefresh = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvService = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvService).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.MediumBlue;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1684, 100);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 36F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(532, 58);
            label1.TabIndex = 0;
            label1.Text = "Service Management";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(btnSearch);
            panel2.Dock = DockStyle.Top;
            panel2.Font = new Font("Maiandra GD", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(1684, 60);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDeactivate);
            groupBox1.Controls.Add(btnActivate);
            groupBox1.Location = new Point(689, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(285, 57);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Status";
            // 
            // btnDeactivate
            // 
            btnDeactivate.BackColor = Color.LightSkyBlue;
            btnDeactivate.FlatAppearance.BorderSize = 0;
            btnDeactivate.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnDeactivate.FlatAppearance.MouseOverBackColor = Color.Red;
            btnDeactivate.FlatStyle = FlatStyle.Popup;
            btnDeactivate.Font = new Font("Microsoft YaHei", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeactivate.ForeColor = Color.White;
            btnDeactivate.Location = new Point(163, 22);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(100, 31);
            btnDeactivate.TabIndex = 5;
            btnDeactivate.Text = "Deactivate";
            btnDeactivate.UseVisualStyleBackColor = false;
            btnDeactivate.Click += btnDeactivate_Click;
            // 
            // btnActivate
            // 
            btnActivate.BackColor = Color.LightSkyBlue;
            btnActivate.FlatAppearance.BorderSize = 0;
            btnActivate.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnActivate.FlatAppearance.MouseOverBackColor = Color.Red;
            btnActivate.FlatStyle = FlatStyle.Popup;
            btnActivate.Font = new Font("Microsoft YaHei", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActivate.ForeColor = Color.White;
            btnActivate.Location = new Point(23, 21);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(100, 31);
            btnActivate.TabIndex = 4;
            btnActivate.Text = "Activate";
            btnActivate.UseVisualStyleBackColor = false;
            btnActivate.Click += btnActivate_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.MediumTurquoise;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Popup;
            btnRefresh.Font = new Font("Microsoft YaHei", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(477, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 32);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.Azure;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(12, 20);
            txtSearch.MaxLength = 16;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(261, 32);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DodgerBlue;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.Font = new Font("Microsoft YaHei", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(279, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 32);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvService
            // 
            dgvService.AllowUserToDeleteRows = false;
            dgvService.AllowUserToResizeColumns = false;
            dgvService.AllowUserToResizeRows = false;
            dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvService.Dock = DockStyle.Fill;
            dgvService.Location = new Point(0, 160);
            dgvService.Name = "dgvService";
            dgvService.Size = new Size(1684, 701);
            dgvService.TabIndex = 2;
            dgvService.CellContentClick += dgvService_CellContentClick;
            // 
            // FrmServices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 861);
            Controls.Add(dgvService);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmServices";
            Text = "FrmServices";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvService).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private DataGridView dgvService;
        private Button btnSearch;
        private TextBox txtSearch;
        private Button btnRefresh;
        private GroupBox groupBox1;
        private Button btnDeactivate;
        private Button btnActivate;
    }
}