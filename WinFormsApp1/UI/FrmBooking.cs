using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaddysLanka.UI
{
    public partial class FrmBooking : Form
    {
        private int? selectedBookingId = null;
        public FrmBooking()
        {
            // Initialize ToolTip
            toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };

            InitializeComponent();

            // Update pending statuses on form load
            UpdatePendingStatuses();

            // Load bookings into the DataGridView and calendar
            LoadBookings();

            toolTip1.SetToolTip(calenderBooking, "Select a date to view or book appointments.");

            // Subscribe to the events in the Form_Load or InitializeComponent method
            calenderBooking.DateSelected += calenderBooking_DateSelected;
            //calenderBooking.MouseMove += calenderBooking_MouseMove;

            dgvBooking.CellClick += dgvBooking_CellClick;

            cmbStatus.SelectedIndex = 0;
            cmbTime.SelectedIndex = 3;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtPatient.Text) ||
                dtpDate.Value.Date < DateTime.Now.Date ||
                dtpStart.Value.TimeOfDay < TimeSpan.FromHours(8) ||
                dtpEnd.Value.TimeOfDay > TimeSpan.FromHours(17) ||
                dtpStart.Value.TimeOfDay >= dtpEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Please ensure all fields are filled correctly and the booking time is within working hours (8 AM to 5 PM).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Open database connection
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                using (var cmd = new SqlCommand("sp_InsertBooking", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@PatientName", txtPatient.Text.Trim());
                    cmd.Parameters.AddWithValue("@BookingDate", dtpDate.Value.Date);
                    cmd.Parameters.AddWithValue("@StartTime", dtpStart.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@EndTime", dtpEnd.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@Description", txtNote.Text.Trim());

                    // Execute stored procedure
                    var result = cmd.ExecuteScalar();
                    if (result != null && (int)result == 1)
                    {
                        MessageBox.Show("Booking successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBookings();
                    }
                    else
                    {
                        MessageBox.Show("Booking time overlaps with an existing booking or is outside working hours.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while booking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close database connection
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private DataTable bookings;
        private void LoadBookings()
        {
            try
            {
                // Open database connection
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                using (var cmd = new SqlCommand("SELECT BookingID, PatientName, BookingDate, StartTime, EndTime, Description, Status, CreatedAt FROM Bookings", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        // Create a new DataTable and fill it with data
                        bookings = new DataTable();
                        adapter.Fill(bookings);

                        // Bind data to dgvBooking
                        dgvBooking.DataSource = bookings;

                        // Set column headers
                        dgvBooking.Columns["BookingID"].HeaderText = "Booking ID";
                        dgvBooking.Columns["PatientName"].HeaderText = "Patient Name";
                        dgvBooking.Columns["BookingDate"].HeaderText = "Booking Date";
                        dgvBooking.Columns["StartTime"].HeaderText = "Start Time";
                        dgvBooking.Columns["EndTime"].HeaderText = "End Time";
                        dgvBooking.Columns["Description"].HeaderText = "Note";
                        dgvBooking.Columns["Status"].HeaderText = "Status";
                        dgvBooking.Columns["CreatedAt"].HeaderText = "Created At";

                        // Hide BookingID column
                        dgvBooking.Columns["BookingID"].Visible = false;

                        // Format BookingDate, StartTime, EndTime, and CreatedAt columns
                        dgvBooking.Columns["BookingDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                        dgvBooking.Columns["StartTime"].DefaultCellStyle.Format = "hh\\:mm";
                        dgvBooking.Columns["EndTime"].DefaultCellStyle.Format = "hh\\:mm";
                        dgvBooking.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                        // Adjust column widths to fill the DataGridView
                        dgvBooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                        dgvBooking.Columns["BookingID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Adjust to fit content

                        dgvBooking.Columns["PatientName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Fill remaining space
                        dgvBooking.Columns["BookingDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvBooking.Columns["StartTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvBooking.Columns["EndTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvBooking.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvBooking.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvBooking.Columns["CreatedAt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        // Apply custom design
                        dgvBooking.DefaultCellStyle.Font = new Font("Tahoma", 10);
                        dgvBooking.DefaultCellStyle.ForeColor = Color.Black;
                        dgvBooking.DefaultCellStyle.BackColor = Color.White;
                        dgvBooking.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                        dgvBooking.DefaultCellStyle.SelectionForeColor = Color.White;

                        dgvBooking.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
                        dgvBooking.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgvBooking.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;

                        dgvBooking.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
                        dgvBooking.GridColor = Color.LightGray;
                        dgvBooking.CellBorderStyle = DataGridViewCellBorderStyle.Single;

                        // Set row height
                        dgvBooking.RowTemplate.Height = 40;

                        // Set the DataGridView to read-only
                        dgvBooking.ReadOnly = true;

                        // Highlight booked dates in the calendar
                        HighlightBookedDates(bookings);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close database connection
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void HighlightBookedDates(DataTable bookings)
        {
            try
            {
                // Clear previous highlights
                calenderBooking.BoldedDates = new DateTime[0];

                // Add booked dates to the calendar
                List<DateTime> boldedDates = new List<DateTime>();
                foreach (DataRow row in bookings.Rows)
                {
                    if (DateTime.TryParse(row["BookingDate"].ToString(), out DateTime bookedDate))
                    {
                        boldedDates.Add(bookedDate);

                        // Highlight the date
                        calenderBooking.AddBoldedDate(bookedDate);

                        // Set tooltip for the date
                        if (bookedDate.Date == calenderBooking.SelectionStart.Date)
                        {
                            string tooltipText = $"Booking: {row["PatientName"]}, {row["StartTime"]} - {row["EndTime"]}";
                            toolTip1.SetToolTip(calenderBooking, tooltipText);
                        }
                    }
                }

                // Apply all bolded dates at once
                calenderBooking.BoldedDates = boldedDates.ToArray();

                // Refresh the calendar to apply changes
                calenderBooking.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error highlighting booked dates: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calenderBooking_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Assuming 'bookings' is a DataTable with columns: BookingDate, Name, StartTime, EndTime
            var selectedDate = e.Start;
            var bookedRecords = bookings.AsEnumerable()
                .Where(row => DateTime.Parse(row["BookingDate"].ToString()).Date == selectedDate.Date)
                .Select(row => new
                {
                    Name = row["PatientName"].ToString(),
                    StartTime = DateTime.Parse(row["StartTime"].ToString()).ToShortTimeString(),
                    EndTime = DateTime.Parse(row["EndTime"].ToString()).ToShortTimeString()
                });

            if (bookedRecords.Any())
            {
                // Build tooltip text with booking details
                string tooltipText = "Booked Records:\n";
                foreach (var record in bookedRecords)
                {
                    tooltipText += $"{record.Name}: {record.StartTime} - {record.EndTime}\n";
                }

                toolTip1.SetToolTip(calenderBooking, tooltipText.TrimEnd());
            }
            else
            {
                toolTip1.SetToolTip(calenderBooking, "No bookings for this date.");
            }
        }

        private void calenderBooking_MouseMove(object sender, MouseEventArgs e)
        {
            var hitTestInfo = calenderBooking.HitTest(e.X, e.Y);
            if (hitTestInfo.HitArea == MonthCalendar.HitArea.Date)
            {
                DateTime hitDate = hitTestInfo.Time;

                var bookedRecords = bookings.AsEnumerable()
                    .Where(row => DateTime.TryParse(row["BookingDate"]?.ToString(), out var bookingDate) && bookingDate.Date == hitDate.Date)
                    .Select(row => new
                    {
                        Name = row["PatientName"]?.ToString(),
                        StartTime = DateTime.TryParse(row["StartTime"]?.ToString(), out var startTime) ? startTime.ToShortTimeString() : "N/A",
                        EndTime = DateTime.TryParse(row["EndTime"]?.ToString(), out var endTime) ? endTime.ToShortTimeString() : "N/A"
                    });

                if (bookedRecords.Any())
                {
                    string tooltipText = "Booked Records:\n";
                    foreach (var record in bookedRecords)
                    {
                        tooltipText += $"{record.Name}: {record.StartTime} - {record.EndTime}\n";
                    }

                    toolTip1.Show(tooltipText.TrimEnd(), calenderBooking, e.Location);
                }
                else
                {
                    toolTip1.Hide(calenderBooking);
                }
            }
            else
            {
                toolTip1.Hide(calenderBooking);
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset patient name and note fields
            txtPatient.Clear();
            txtNote.Clear();

            // Reset date to today
            dtpDate.Value = DateTime.Now.Date;

            // Reset start and end time to default working hours (e.g., 8:00 AM and 9:00 AM)
            dtpStart.Value = DateTime.Today.AddHours(8);
            dtpEnd.Value = DateTime.Today.AddHours(9);
        }

        private void UpdatePendingStatuses()
        {
            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                // Call a stored procedure to update pending statuses
                using (var cmd = new SqlCommand("sp_UpdatePendingBookingStatuses", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Now", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating booking statuses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void dgvBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvBooking.Rows[e.RowIndex].IsNewRow)
            {
                var row = dgvBooking.Rows[e.RowIndex];
                if (row.Cells["BookingID"].Value != null && int.TryParse(row.Cells["BookingID"].Value.ToString(), out int id))
                {
                    selectedBookingId = id;
                }
                else
                {
                    selectedBookingId = null;
                }
            }
            else
            {
                selectedBookingId = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == null)
            {
                MessageBox.Show("Please select a booking to delete.", "Delete Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete the selected booking?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new SqlCommand("DELETE FROM Bookings WHERE BookingID = @BookingID", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.Parameters.AddWithValue("@BookingID", selectedBookingId.Value);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        ShowTemporarySuccess("Booking deleted successfully.");
                        LoadBookings();
                        selectedBookingId = null;
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. Booking not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting booking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }
        private void ShowTemporarySuccess(string message)
        {
            // Show the tooltip near the center of the form for 2 seconds
            toolTip1.Show(message, this, this.Width / 2, this.Height / 2, 2000);
        }

        private void btnpending_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == null)
            {
                MessageBox.Show("Please select a booking to set as Pending.", "Set Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new SqlCommand("UPDATE Bookings SET Status = 'Pending' WHERE BookingID = @BookingID", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.Parameters.AddWithValue("@BookingID", selectedBookingId.Value);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        ShowTemporarySuccess("Booking status set to Pending.");
                        LoadBookings();
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Booking not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating booking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == null)
            {
                MessageBox.Show("Please select a booking to cancel.", "Cancel Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to cancel the selected booking?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new SqlCommand("UPDATE Bookings SET Status = 'Cancelled' WHERE BookingID = @BookingID", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.Parameters.AddWithValue("@BookingID", selectedBookingId.Value);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        ShowTemporarySuccess("Booking marked as Cancelled.");
                        LoadBookings();
                    }
                    else
                    {
                        MessageBox.Show("Cancel failed. Booking not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling booking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == null)
            {
                MessageBox.Show("Please select a booking to mark as complete.", " Session Finished", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to mark the selected booking as Completed?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();
                using (var cmd = new SqlCommand("UPDATE Bookings SET Status = 'Completed' WHERE BookingID = @BookingID", Daddysanka.Database.DBConnection.Instance.Connection))
                {
                    cmd.Parameters.AddWithValue("@BookingID", selectedBookingId.Value);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        ShowTemporarySuccess("Booking marked as Completed.");
                        LoadBookings();
                    }
                    else
                    {
                        MessageBox.Show("Complete failed. Booking not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error completing booking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedStatus = cmbStatus.SelectedItem?.ToString() ?? "Pending";
            string selectedTime = cmbTime.SelectedItem?.ToString() ?? "This Month";

            // Build date range based on selectedTime
            DateTime now = DateTime.Now;
            DateTime? dateFrom = null, dateTo = null;

            switch (selectedTime)
            {
                case "This Month":
                    dateFrom = new DateTime(now.Year, now.Month, 1);
                    dateTo = dateFrom.Value.AddMonths(1);
                    break;
                case "Last month":
                    dateFrom = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
                    dateTo = new DateTime(now.Year, now.Month, 1);
                    break;
                case "This Year":
                    dateFrom = new DateTime(now.Year, 1, 1);
                    dateTo = dateFrom.Value.AddYears(1);
                    break;
                case "All":
                    dateFrom = null;
                    dateTo = null;
                    break;
            }

            try
            {
                Daddysanka.Database.DBConnection.Instance.OpenConnection();

                var sql = new StringBuilder("SELECT BookingID, PatientName, BookingDate, StartTime, EndTime, Description, Status, CreatedAt FROM Bookings WHERE 1=1");

                var cmd = new SqlCommand();
                cmd.Connection = Daddysanka.Database.DBConnection.Instance.Connection;

                // Filter by status if not "All"
                if (!string.IsNullOrWhiteSpace(selectedStatus) && selectedStatus != "All")
                {
                    sql.Append(" AND Status = @Status");
                    cmd.Parameters.AddWithValue("@Status", selectedStatus);
                }

                // Filter by date range if not "All"
                if (dateFrom.HasValue && dateTo.HasValue)
                {
                    sql.Append(" AND BookingDate >= @DateFrom AND BookingDate < @DateTo");
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@DateTo", dateTo.Value.Date);
                }

                cmd.CommandText = sql.ToString();

                using (var adapter = new SqlDataAdapter(cmd))
                {
                    bookings = new DataTable();
                    adapter.Fill(bookings);
                    dgvBooking.DataSource = bookings;
                    // Optionally, re-apply formatting and highlighting if needed
                    HighlightBookedDates(bookings);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering bookings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Daddysanka.Database.DBConnection.Instance.CloseConnection();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBooking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
