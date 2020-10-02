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
    public partial class frmCustomerRecord2 : Form
    {
        public frmCustomerRecord2()
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

        private void frmCustomerRecord2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.inventory_DBDataSet.Customer);


            Cmb_field.SelectedIndex = 0;
            this.ActiveControl = txt_search;
            txt_search.Focus();

        }

        private void dgw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgw.SelectedRows[0];
                this.Hide();
                Sale_Return frmReturn = new Sale_Return();
                // or simply use column name instead of index
                // dr.Cells["id"].Value.ToString();
                if (lblSet.Text == "SaleReturn")

                    frmReturn.Show();

                frmReturn.txtCus_ID.Text = dr.Cells[0].Value.ToString();
                frmReturn.txtCustomerID.Text = dr.Cells[1].Value.ToString();
                frmReturn.txtCustomerName.Text = dr.Cells[3].Value.ToString();
                frmReturn.txtmobile.Text = dr.Cells[9].Value.ToString();

                frmReturn.GetSupplierBalance();











            }






            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (Cmb_field.Text == "ID")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,CustomerID,Date,Name,OpeningBalance,OpeningBalanceType,Address,EmailID,Phoneno,Mobileno,Creditperiod,AccountName,Branch,AccountNumber,Remarks,Pricinglevel FROM Customer where CustomerID like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;


            }



            if (Cmb_field.Text == "CustomerName")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,CustomerID,Date,Name,OpeningBalance,OpeningBalanceType,Address,EmailID,Phoneno,Mobileno,Creditperiod,AccountName,Branch,AccountNumber,Remarks,Pricinglevel FROM Customer where Name like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;


            }

            if (Cmb_field.Text == "Mobile")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,CustomerID,Date,Name,OpeningBalance,OpeningBalanceType,Address,EmailID,Phoneno,Mobileno,Creditperiod,AccountName,Branch,AccountNumber,Remarks,Pricinglevel FROM Customer where Mobileno like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;


            }
        }

        private void btnaddsupplier_Click(object sender, EventArgs e)
        {

        }
    }
}
