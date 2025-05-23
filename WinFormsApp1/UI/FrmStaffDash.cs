using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FrmStaffDash : Form
    {
        private int _userId;
        public FrmStaffDash(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void FrmStaffDash_Load(object sender, EventArgs e)
        {

        }
    }
}
