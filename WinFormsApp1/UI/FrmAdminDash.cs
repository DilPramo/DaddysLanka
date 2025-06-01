using DaddysLanka.UI;

namespace WinFormsApp1
{
    public partial class FrmAdminDash : Form
    {
        public FrmAdminDash()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pnlData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdInvoice_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmSales as a child form
            var salesForm = new FrmSales
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(salesForm);
            salesForm.Show();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmCustomer as a child form
            var customerForm = new Daddysanka.UI.FrmCustomer
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(customerForm);
            customerForm.Show();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmServices as a child form
            var servicesForm = new DaddysLanka.UI.FrmServices
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(servicesForm);
            servicesForm.Show();
        }

        private void btnAdUsers_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmUsers as a child form
            var usersForm = new Daddysanka.UI.FrmUsers
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(usersForm);
            usersForm.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmHistory as a child form
            var historyForm = new DaddysLanka.UI.FrmHistory
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(historyForm);
            historyForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnISales_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmInvoicebySales as a child form
            var salesForm = new DaddysLanka.UI.FrmInvoicebySales
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(salesForm);
            salesForm.Show();
        }

        private void btnIServices_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmInvoicebyService as a child form
            var serviceForm = new DaddysLanka.UI.FrmInvoicebyService
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(serviceForm);
            serviceForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmInvoicebyService as a child form
            var optionsForm = new DaddysLanka.UI.FrmOptions
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(optionsForm);
            optionsForm.Show();
        }
    }
}

