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
            panel2 = new Panel();
            pnlData = new Panel();
            label1 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkBlue;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 1001);
            panel1.TabIndex = 0;
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
            // pnlData
            // 
            pnlData.BackColor = Color.White;
            pnlData.Dock = DockStyle.Fill;
            pnlData.Location = new Point(200, 100);
            pnlData.Name = "pnlData";
            pnlData.Size = new Size(1704, 901);
            pnlData.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Perpetua Titling MT", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 9);
            label1.Name = "label1";
            label1.Size = new Size(675, 75);
            label1.TabIndex = 0;
            label1.Text = "Admin Dashboard";
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
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel pnlData;
        private Label label1;
    }
}
