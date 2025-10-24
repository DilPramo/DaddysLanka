namespace DaddysLanka.UI
{
    partial class FrmBooking
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            btnClose = new Button();
            label1 = new Label();
            dgvBooking = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtPatient = new TextBox();
            dtpDate = new DateTimePicker();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            label7 = new Label();
            txtNote = new TextBox();
            btnBook = new Button();
            pnlCalendar = new Panel();
            calenderBooking = new MonthCalendar();
            toolTip1 = new ToolTip(components);
            btnReset = new Button();
            btnDelete = new Button();
            groupBox1 = new GroupBox();
            btnFilter = new Button();
            cmbTime = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            cmbStatus = new ComboBox();
            groupBox2 = new GroupBox();
            btnCompleted = new Button();
            btnCancel = new Button();
            btnpending = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooking).BeginInit();
            pnlCalendar.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumBlue;
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1281, 100);
            panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Crimson;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(1247, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(22, 23);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(222, 58);
            label1.TabIndex = 0;
            label1.Text = "Booking";
            // 
            // dgvBooking
            // 
            dgvBooking.AllowUserToAddRows = false;
            dgvBooking.AllowUserToDeleteRows = false;
            dgvBooking.AllowUserToOrderColumns = true;
            dgvBooking.AllowUserToResizeColumns = false;
            dgvBooking.AllowUserToResizeRows = false;
            dgvBooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvBooking.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvBooking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooking.Location = new Point(449, 389);
            dgvBooking.Name = "dgvBooking";
            dgvBooking.Size = new Size(762, 336);
            dgvBooking.TabIndex = 4;
            dgvBooking.CellContentClick += dgvBooking_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkBlue;
            label2.Location = new Point(39, 103);
            label2.Name = "label2";
            label2.Size = new Size(154, 23);
            label2.TabIndex = 5;
            label2.Text = "Book a Session";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 141);
            label3.Name = "label3";
            label3.Size = new Size(114, 19);
            label3.TabIndex = 6;
            label3.Text = "Patient Name :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 198);
            label4.Name = "label4";
            label4.Size = new Size(114, 19);
            label4.TabIndex = 7;
            label4.Text = "Booking Date :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(2, 250);
            label5.Name = "label5";
            label5.Size = new Size(94, 19);
            label5.TabIndex = 8;
            label5.Text = "Start Time :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(2, 283);
            label6.Name = "label6";
            label6.Size = new Size(88, 19);
            label6.TabIndex = 9;
            label6.Text = "End Time :";
            // 
            // txtPatient
            // 
            txtPatient.BorderStyle = BorderStyle.FixedSingle;
            txtPatient.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPatient.Location = new Point(120, 142);
            txtPatient.MaxLength = 32;
            txtPatient.Name = "txtPatient";
            txtPatient.Size = new Size(272, 29);
            txtPatient.TabIndex = 10;
            // 
            // dtpDate
            // 
            dtpDate.CalendarFont = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDate.CalendarTitleBackColor = Color.SkyBlue;
            dtpDate.DropDownAlign = LeftRightAlignment.Right;
            dtpDate.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDate.Location = new Point(120, 194);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(272, 27);
            dtpDate.TabIndex = 11;
            dtpDate.Value = new DateTime(2025, 6, 16, 0, 0, 0, 0);
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // dtpStart
            // 
            dtpStart.CalendarFont = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStart.CustomFormat = "hh:mm tt";
            dtpStart.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(120, 244);
            dtpStart.Name = "dtpStart";
            dtpStart.ShowUpDown = true;
            dtpStart.Size = new Size(272, 27);
            dtpStart.TabIndex = 13;
            dtpStart.Value = new DateTime(2025, 6, 16, 8, 0, 0, 0);
            // 
            // dtpEnd
            // 
            dtpEnd.CalendarFont = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEnd.CustomFormat = "hh:mm tt";
            dtpEnd.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(120, 277);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.ShowUpDown = true;
            dtpEnd.Size = new Size(270, 27);
            dtpEnd.TabIndex = 14;
            dtpEnd.Value = new DateTime(2025, 7, 10, 0, 0, 0, 0);
            dtpEnd.ValueChanged += dtpEnd_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(2, 339);
            label7.Name = "label7";
            label7.Size = new Size(53, 19);
            label7.TabIndex = 15;
            label7.Text = "Note :";
            // 
            // txtNote
            // 
            txtNote.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNote.Location = new Point(120, 329);
            txtNote.MaxLength = 63;
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(272, 84);
            txtNote.TabIndex = 16;
            // 
            // btnBook
            // 
            btnBook.BackColor = Color.ForestGreen;
            btnBook.FlatStyle = FlatStyle.Popup;
            btnBook.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBook.ForeColor = SystemColors.ControlLightLight;
            btnBook.Location = new Point(449, 127);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(101, 36);
            btnBook.TabIndex = 17;
            btnBook.Text = "Book";
            btnBook.UseVisualStyleBackColor = false;
            btnBook.Click += btnBook_Click;
            // 
            // pnlCalendar
            // 
            pnlCalendar.BackColor = SystemColors.ButtonFace;
            pnlCalendar.Controls.Add(calenderBooking);
            pnlCalendar.Location = new Point(30, 434);
            pnlCalendar.Name = "pnlCalendar";
            pnlCalendar.Size = new Size(362, 342);
            pnlCalendar.TabIndex = 18;
            // 
            // calenderBooking
            // 
            calenderBooking.BackColor = SystemColors.HotTrack;
            calenderBooking.CalendarDimensions = new Size(1, 2);
            calenderBooking.Dock = DockStyle.Fill;
            calenderBooking.FirstDayOfWeek = Day.Monday;
            calenderBooking.Font = new Font("Arial Narrow", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            calenderBooking.ForeColor = Color.White;
            calenderBooking.Location = new Point(0, 0);
            calenderBooking.Name = "calenderBooking";
            calenderBooking.TabIndex = 0;
            calenderBooking.TrailingForeColor = Color.White;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Crimson;
            btnReset.FlatStyle = FlatStyle.Popup;
            btnReset.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = SystemColors.ControlLightLight;
            btnReset.Location = new Point(449, 189);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(101, 36);
            btnReset.TabIndex = 19;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = SystemColors.ControlLightLight;
            btnDelete.Location = new Point(449, 250);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(101, 36);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnFilter);
            groupBox1.Controls.Add(cmbTime);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Location = new Point(449, 308);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(507, 64);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter Options";
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.Silver;
            btnFilter.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilter.ForeColor = Color.Black;
            btnFilter.Location = new Point(388, 20);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(101, 29);
            btnFilter.TabIndex = 22;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // cmbTime
            // 
            cmbTime.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTime.FormattingEnabled = true;
            cmbTime.Items.AddRange(new object[] { "This Month", "Last Month", "This Year", "All" });
            cmbTime.Location = new Point(246, 20);
            cmbTime.Name = "cmbTime";
            cmbTime.Size = new Size(121, 28);
            cmbTime.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(201, 27);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 2;
            label9.Text = "Time :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 27);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 1;
            label8.Text = "Status :";
            // 
            // cmbStatus
            // 
            cmbStatus.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "All", "Pending", "Completed", "Cancelled" });
            cmbStatus.Location = new Point(59, 20);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(121, 28);
            cmbStatus.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnCompleted);
            groupBox2.Controls.Add(btnCancel);
            groupBox2.Controls.Add(btnpending);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(577, 127);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(580, 64);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Status Update";
            // 
            // btnCompleted
            // 
            btnCompleted.BackColor = Color.LimeGreen;
            btnCompleted.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCompleted.ForeColor = Color.White;
            btnCompleted.Location = new Point(363, 22);
            btnCompleted.Name = "btnCompleted";
            btnCompleted.Size = new Size(105, 36);
            btnCompleted.TabIndex = 25;
            btnCompleted.Text = "Complete";
            btnCompleted.UseVisualStyleBackColor = false;
            btnCompleted.Click += btnCompleted_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Tomato;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(202, 22);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(101, 36);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnpending
            // 
            btnpending.BackColor = Color.Olive;
            btnpending.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnpending.ForeColor = Color.White;
            btnpending.Location = new Point(41, 22);
            btnpending.Name = "btnpending";
            btnpending.Size = new Size(101, 36);
            btnpending.TabIndex = 23;
            btnpending.Text = "Pending";
            btnpending.UseVisualStyleBackColor = false;
            btnpending.Click += btnpending_Click;
            // 
            // FrmBooking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1281, 788);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnDelete);
            Controls.Add(btnReset);
            Controls.Add(pnlCalendar);
            Controls.Add(btnBook);
            Controls.Add(txtNote);
            Controls.Add(label7);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Controls.Add(dtpDate);
            Controls.Add(txtPatient);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvBooking);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmBooking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "             ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooking).EndInit();
            pnlCalendar.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private DataGridView dgvBooking;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtPatient;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private Label label7;
        private TextBox txtNote;
        private Button btnBook;
        private MonthCalendar monthCalendar1;
        private Panel pnlCalendar;
        private MonthCalendar calenderBooking;
        private ToolTip toolTip1;
        private Button btnReset;
        private Button btnDelete;
        private GroupBox groupBox1;
        private ComboBox cmbStatus;
        private Button btnFilter;
        private ComboBox cmbTime;
        private Label label9;
        private Label label8;
        private GroupBox groupBox2;
        private Button btnCompleted;
        private Button btnCancel;
        private Button btnpending;
        private Button btnClose;
    }
}