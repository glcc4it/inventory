using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loop_Inventory
{
    public partial class Service_Ledger_Report : Form
    {
        public Service_Ledger_Report()
        {
            InitializeComponent();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Service_Ledger_Report_Load(object sender, EventArgs e)
        {
            
        }

        private void btnfetch_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Inventory_DBDataSet.ServicesLedgerBook' table. You can move, or remove it, as needed.
            this.ServicesLedgerBookTableAdapter.Fill(this.Inventory_DBDataSet.ServicesLedgerBook,dateTimePicker1.Text,dateTimePicker2.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
