namespace DaddysLanka.UI
{
    partial class FrmOptions
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
            groupBox1 = new GroupBox();
            btnBackup = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            groupBox2 = new GroupBox();
            BtnRestore = new Button();
            label3 = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnBackup);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.FlatStyle = FlatStyle.Popup;
            groupBox1.Font = new Font("MS Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(12, 105);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(373, 127);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Manual Backup";
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.LightSkyBlue;
            btnBackup.FlatAppearance.BorderColor = Color.White;
            btnBackup.FlatAppearance.BorderSize = 2;
            btnBackup.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.ForeColor = Color.White;
            btnBackup.Location = new Point(251, 84);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(105, 32);
            btnBackup.TabIndex = 2;
            btnBackup.Text = "Backup";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(160, 29);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 32);
            textBox1.TabIndex = 1;
            textBox1.Text = "D:\\";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(27, 38);
            label2.Name = "label2";
            label2.Size = new Size(127, 16);
            label2.TabIndex = 0;
            label2.Text = "Save Location :";
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1688, 72);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(213, 61);
            label1.TabIndex = 0;
            label1.Text = "Options";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(BtnRestore);
            groupBox2.Controls.Add(label3);
            groupBox2.FlatStyle = FlatStyle.Popup;
            groupBox2.Font = new Font("MS Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(12, 265);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(373, 142);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Manual Restore";
            // 
            // BtnRestore
            // 
            BtnRestore.BackColor = Color.LightSkyBlue;
            BtnRestore.FlatAppearance.BorderColor = Color.White;
            BtnRestore.FlatAppearance.BorderSize = 2;
            BtnRestore.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            BtnRestore.FlatStyle = FlatStyle.Flat;
            BtnRestore.ForeColor = Color.White;
            BtnRestore.Location = new Point(112, 94);
            BtnRestore.Name = "BtnRestore";
            BtnRestore.Size = new Size(126, 42);
            BtnRestore.TabIndex = 2;
            BtnRestore.Text = "Restore";
            BtnRestore.UseVisualStyleBackColor = false;
            BtnRestore.Click += BtnRestore_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(27, 34);
            label3.Name = "label3";
            label3.Size = new Size(279, 16);
            label3.TabIndex = 0;
            label3.Text = "Click Backup and Select Bckup file";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Tai Le", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(27, 63);
            label4.Name = "label4";
            label4.Size = new Size(288, 16);
            label4.TabIndex = 3;
            label4.Text = "default ::D:\\DaddysankaBackup_20250531_105016.bak";
            // 
            // FrmOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(1688, 862);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmOptions";
            Text = "FrmOptions";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button btnBackup;
        private GroupBox groupBox2;
        private Button BtnRestore;
        private Label label3;
        private Label label4;
    }
}