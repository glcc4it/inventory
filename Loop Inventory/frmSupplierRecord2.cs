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
    public partial class frmSupplierRecord2 : Form
    {
        public frmSupplierRecord2()
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

        private void frmSupplierRecord2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.inventory_DBDataSet.Supplier);


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
                Purchase_Return frmReturn = new Purchase_Return();
                // or simply use column name instead of index
                // dr.Cells["id"].Value.ToString();
                if (lblSet.Text == "PurchaseReturn")

                    frmReturn.Show();
                
                frmReturn.txtSupplierID.Text = dr.Cells[1].Value.ToString();
                frmReturn.txtSupplierName.Text = dr.Cells[3].Value.ToString();
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
                SqlDataAdapter sda = new SqlDataAdapter("SELECT SupplierID, Date, Name, OpeningBalance, OpeningBalanceType, Address, EmailID,Phoneno,Mobileno,Creditperiod,AccountName,Branch,AccountNumber,Remarks,Pricinglevel FROM Supplier where SupplierID like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;


            }


            if (Cmb_field.Text == "SupplierName")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT SupplierID, Date, Name, OpeningBalance, OpeningBalanceType, Address, EmailID,Phoneno,Mobileno,Creditperiod,AccountName,Branch,AccountNumber,Remarks,Pricinglevel FROM Supplier where Name like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;


            }

            if (Cmb_field.Text == "Mobile")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT SupplierID, Date, [Name], OpeningBalance, OpeningBalanceType, Address, EmailID,Phoneno,Mobileno,Creditperiod,AccountName,Branch,AccountNumber,Remarks,Pricinglevel FROM Supplier where Mobileno like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;


            }
        }
    }
}
