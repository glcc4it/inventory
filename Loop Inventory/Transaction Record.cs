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
    public partial class Transaction_Record : Form
    {
        public Transaction_Record()
        {
            InitializeComponent();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Transaction_Record_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'inventory_DBDataSet.Payment' table. You can move, or remove it, as needed.
            this.paymentTableAdapter.Fill(this.inventory_DBDataSet.Payment);
            

           

        }

       

        private void btnfetch_Click(object sender, EventArgs e)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            SqlDataAdapter sdf = new SqlDataAdapter("select * from Payment where Date between '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "'", ModCommonClasses.con);
            DataTable sd = new DataTable();
            sdf.Fill(sd);
            dgw.DataSource = sd;


            int sum = 0;
            for (int i = 0; i < dgw.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgw.Rows[i].Cells[7].Value);
            }

            label14.Text = sum.ToString();
        }
    }
}
