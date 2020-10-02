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
    public partial class Stock_Report : Form
    {
        public Stock_Report()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Stock_Report_Load(object sender, EventArgs e)
        {
            

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Inventory_DBDataSet.Temp_Stock1' table. You can move, or remove it, as needed.
            this.Temp_Stock1TableAdapter.Fill(this.Inventory_DBDataSet.Temp_Stock1,dateTimePicker1.Text,dateTimePicker2.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
