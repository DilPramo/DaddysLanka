using DaddysLanka.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daddysanka.UI
{
    public partial class FrmAccountantDash : Form
    {
        public FrmAccountantDash()
        {
            InitializeComponent();
        }

        private void FrmAccountantDash_Load(object sender, EventArgs e)
        {

        }

        private void btnIHistory_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmHistory as a child form
            var historyForm = new FrmHistory
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(historyForm);
            historyForm.Show();
        }

        private void btnInSale_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmHistory as a child form
            var invoicebySalesForm = new FrmInvoicebySales
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(invoicebySalesForm);
            invoicebySalesForm.Show();
        }

        private void btnInService_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            pnlData.Controls.Clear();

            // Create and configure FrmHistory as a child form
            var invoicebyServiceForm = new FrmInvoicebyService
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlData.Controls.Add(invoicebyServiceForm);
            invoicebyServiceForm.Show();
        }
    }
}
