using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loop_Inventory
{
    public partial class Billing_Record : Form
    {
        public Billing_Record()
        {
            InitializeComponent();
        }

        private void Billing_Record_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.InvoiceInfo1' table. You can move, or remove it, as needed.
            this.invoiceInfo1TableAdapter.Fill(this.inventory_DBDataSet.InvoiceInfo1);

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnfetch_Click(object sender, EventArgs e)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            SqlDataAdapter sdf = new SqlDataAdapter("select * from InvoiceInfo1 where Date between '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "'", ModCommonClasses.con);
            DataTable sd = new DataTable();
            sdf.Fill(sd);
            dgw.DataSource = sd;


            int sum = 0;
            for (int i = 0; i < dgw.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgw.Rows[i].Cells[11].Value);
            }

            label14.Text = sum.ToString();
        }
    }
}
