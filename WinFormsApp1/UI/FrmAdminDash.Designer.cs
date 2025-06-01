namespace WinFormsApp1
{
    partial class FrmAdminDash
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            btnIServices = new Button();
            btnISales = new Button();
            label5 = new Label();
            label4 = new Label();
            btnAdUsers = new Button();
            btnHistory = new Button();
            btnService = new Button();
            btnPatient = new Button();
            btnAdInvoice = new Button();
            btnInvoice = new Button();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label1 = new Label();
            pnlData = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnIServices);
            panel1.Controls.Add(btnISales);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnAdUsers);
            panel1.Controls.Add(btnHistory);
            panel1.Controls.Add(btnService);
            panel1.Controls.Add(btnPatient);
            panel1.Controls.Add(btnAdInvoice);
            panel1.Controls.Add(btnInvoice);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 1001);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.SkyBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Tai Le", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(89, 775);
            button1.Name = "button1";
            button1.Size = new Size(105, 35);
            button1.TabIndex = 14;
            button1.Text = "Options";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnIServices
            // 
            btnIServices.BackColor = Color.Transparent;
            btnIServices.FlatAppearance.BorderSize = 2;
            btnIServices.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            btnIServices.FlatAppearance.MouseOverBackColor = Color.SkyBlue;
            btnIServices.FlatStyle = FlatStyle.Flat;
            btnIServices.Font = new Font("MingLiU-ExtB", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnIServices.ForeColor = Color.White;
            btnIServices.ImageAlign = ContentAlignment.TopCenter;
            btnIServices.Location = new Point(38, 679);
            btnIServices.Name = "btnIServices";
            btnIServices.Size = new Size(164, 61);
            btnIServices.TabIndex = 13;
            btnIServices.Text = "Income by Services";
            btnIServices.TextAlign = ContentAlignment.MiddleRight;
            btnIServices.TextImageRelation = TextImageRelation.ImageAboveText;
            btnIServices.UseVisualStyleBackColor = false;
            btnIServices.Click += btnIServices_Click;
            // 
            // btnISales
            // 
            btnISales.BackColor = Color.Transparent;
            btnISales.FlatAppearance.BorderSize = 2;
            btnISales.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            btnISales.FlatAppearance.MouseOverBackColor = Color.SkyBlue;
            btnISales.FlatStyle = FlatStyle.Flat;
            btnISales.Font = new Font("MingLiU-ExtB", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnISales.ForeColor = Color.White;
            btnISales.ImageAlign = ContentAlignment.TopCenter;
            btnISales.Location = new Point(38, 602);
            btnISales.Name = "btnISales";
            btnISales.Size = new Size(164, 60);
            btnISales.TabIndex = 12;
            btnISales.Text = "Income by sales";
            btnISales.TextAlign = ContentAlignment.MiddleRight;
            btnISales.TextImageRelation = TextImageRelation.ImageAboveText;
            btnISales.UseVisualStyleBackColor = false;
            btnISales.Click += btnISales_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(-2, 570);
            label5.Name = "label5";
            label5.Size = new Size(202, 15);
            label5.TabIndex = 11;
            label5.Text = "---------------------------------------";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(-2, 302);
            label4.Name = "label4";
            label4.Size = new Size(202, 15);
            label4.TabIndex = 10;
            label4.Text = "---------------------------------------";
            // 
            // btnAdUsers
            // 
            btnAdUsers.BackColor = Color.Transparent;
            btnAdUsers.FlatAppearance.BorderSize = 2;
            btnAdUsers.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            btnAdUsers.FlatAppearance.MouseOverBackColor = Color.SkyBlue;
            btnAdUsers.FlatStyle = FlatStyle.Flat;
            btnAdUsers.Font = new Font("MingLiU-ExtB", 21.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAdUsers.ForeColor = Color.White;
            btnAdUsers.ImageAlign = ContentAlignment.TopCenter;
            btnAdUsers.Location = new Point(38, 243);
            btnAdUsers.Name = "btnAdUsers";
            btnAdUsers.Size = new Size(164, 42);
            btnAdUsers.TabIndex = 9;
            btnAdUsers.Text = "Users";
            btnAdUsers.TextAlign = ContentAlignment.MiddleRight;
            btnAdUsers.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdUsers.UseVisualStyleBackColor = false;
            btnAdUsers.Click += btnAdUsers_Click;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.Transparent;
            btnHistory.FlatAppearance.BorderSize = 2;
            btnHistory.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            btnHistory.FlatAppearance.MouseOverBackColor = Color.SkyBlue;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("MingLiU-ExtB", 21.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnHistory.ForeColor = Color.White;
            btnHistory.ImageAlign = ContentAlignment.TopCenter;
            btnHistory.Location = new Point(38, 511);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(164, 42);
            btnHistory.TabIndex = 8;
            btnHistory.Text = "History";
            btnHistory.TextAlign = ContentAlignment.MiddleRight;
            btnHistory.TextImageRelation = TextImageRelation.ImageAboveText;
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnService
            // 
            btnService.BackColor = Color.Transparent;
            btnService.FlatAppearance.BorderSize = 2;
            btnService.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            btnService.FlatAppearance.MouseOverBackColor = Color.SkyBlue;
            btnService.FlatStyle = FlatStyle.Flat;
            btnService.Font = new Font("MingLiU-ExtB", 21.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnService.ForeColor = Color.White;
            btnService.ImageAlign = ContentAlignment.TopCenter;
            btnService.Location = new Point(38, 452);
            btnService.Name = "btnService";
            btnService.Size = new Size(164, 42);
            btnService.TabIndex = 7;
            btnService.Text = "Service";
            btnService.TextAlign = ContentAlignment.MiddleRight;
            btnService.TextImageRelation = TextImageRelation.ImageAboveText;
            btnService.UseVisualStyleBackColor = false;
            btnService.Click += btnService_Click;
            // 
            // btnPatient
            // 
            btnPatient.BackColor = Color.Transparent;
            btnPatient.FlatAppearance.BorderSize = 2;
            btnPatient.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            btnPatient.FlatAppearance.MouseOverBackColor = Color.SkyBlue;
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.Font = new Font("MingLiU-ExtB", 21.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnPatient.ForeColor = Color.White;
            btnPatient.ImageAlign = ContentAlignment.TopCenter;
            btnPatient.Location = new Point(38, 393);
            btnPatient.Name = "btnPatient";
            btnPatient.Size = new Size(164, 42);
            btnPatient.TabIndex = 6;
            btnPatient.Text = "Patients";
            btnPatient.TextAlign = ContentAlignment.MiddleRight;
            btnPatient.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPatient.UseVisualStyleBackColor = false;
            btnPatient.Click += btnPatient_Click;
            // 
            // btnAdInvoice
            // 
            btnAdInvoice.BackColor = Color.Transparent;
            btnAdInvoice.FlatAppearance.BorderSize = 2;
            btnAdInvoice.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            btnAdInvoice.FlatAppearance.MouseOverBackColor = Color.SkyBlue;
            btnAdInvoice.FlatStyle = FlatStyle.Flat;
            btnAdInvoice.Font = new Font("MingLiU-ExtB", 21.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAdInvoice.ForeColor = Color.White;
            btnAdInvoice.ImageAlign = ContentAlignment.TopCenter;
            btnAdInvoice.Location = new Point(38, 334);
            btnAdInvoice.Name = "btnAdInvoice";
            btnAdInvoice.Size = new Size(164, 42);
            btnAdInvoice.TabIndex = 2;
            btnAdInvoice.Text = "Invoice";
            btnAdInvoice.TextAlign = ContentAlignment.MiddleRight;
            btnAdInvoice.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdInvoice.UseVisualStyleBackColor = false;
            btnAdInvoice.Click += btnAdInvoice_Click;
            // 
            // btnInvoice
            // 
            btnInvoice.BackColor = Color.Transparent;
            btnInvoice.FlatAppearance.BorderSize = 2;
            btnInvoice.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            btnInvoice.FlatAppearance.MouseOverBackColor = Color.SkyBlue;
            btnInvoice.FlatStyle = FlatStyle.Flat;
            btnInvoice.Font = new Font("MingLiU-ExtB", 21.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnInvoice.ForeColor = Color.White;
            btnInvoice.ImageAlign = ContentAlignment.TopCenter;
            btnInvoice.Location = new Point(38, 184);
            btnInvoice.Name = "btnInvoice";
            btnInvoice.Size = new Size(164, 42);
            btnInvoice.TabIndex = 2;
            btnInvoice.Text = "Dashboard";
            btnInvoice.TextAlign = ContentAlignment.MiddleRight;
            btnInvoice.TextImageRelation = TextImageRelation.ImageAboveText;
            btnInvoice.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 757);
            label3.Name = "label3";
            label3.Size = new Size(202, 15);
            label3.TabIndex = 2;
            label3.Text = "---------------------------------------";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 152);
            label2.Name = "label2";
            label2.Size = new Size(202, 15);
            label2.TabIndex = 1;
            label2.Text = "---------------------------------------";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = DaddysLanka.Properties.Resources.ChatGPT_Image_May_30__2025__02_45_49_PM;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 149);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGray;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(200, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1704, 100);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("cmr10", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(542, 64);
            label1.TabIndex = 0;
            label1.Text = "Admin Dashboard";
            // 
            // pnlData
            // 
            pnlData.BackColor = Color.White;
            pnlData.Dock = DockStyle.Fill;
            pnlData.Location = new Point(200, 100);
            pnlData.Name = "pnlData";
            pnlData.Size = new Size(1704, 901);
            pnlData.TabIndex = 2;
            pnlData.Paint += pnlData_Paint;
            // 
            // FrmAdminDash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1001);
            Controls.Add(pnlData);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAdminDash";
            ShowIcon = false;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel pnlData;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Button btnInvoice;
        private Button btnAdInvoice;
        private Button btnPatient;
        private Button btnService;
        private Button btnAdUsers;
        private Button btnHistory;
        private Label label5;
        private Label label4;
        private Button btnIServices;
        private Button btnISales;
        private Button button1;
    }
}
