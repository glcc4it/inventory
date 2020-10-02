using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loop_Inventory
{
    public partial class frmTrialBalance : Form
    {
        public frmTrialBalance()
        {
            InitializeComponent();
        }


       

        private void btnReset_Click(object sender, EventArgs e)
        {
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
