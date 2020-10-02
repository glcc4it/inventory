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
    public partial class Services_Record : Form
    {
        public Services_Record()
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

        private void Services_Record_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_repair_order' table. You can move, or remove it, as needed.
            this.tbl_repair_orderTableAdapter.Fill(this.inventory_DBDataSet.tbl_repair_order);

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
                Services_Billing frmtrans = new Services_Billing();
                if (lblSet.Text == "Service")

                    frmtrans.Show();



                frmtrans.txtID.Text = dr.Cells[0].Value.ToString();
                frmtrans.txtAccountID.Text = dr.Cells[1].Value.ToString();
                frmtrans.txtAccountName.Text = dr.Cells[4].Value.ToString();
                frmtrans.txtContactNo.Text = dr.Cells[5].Value.ToString();
                frmtrans.GetSupplierBalance();





            }






            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnaddsupplier_Click(object sender, EventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (Cmb_field.Text == "Jobno")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Servicesid,Job_no,Invoicedate,cus_name,cus_number,Mobile_brand,Mobile_model,Mobile_fault,Other_fault,worker,Estimate,mobile_acccess,Reciveid_by,Description,Market,Out_date,Status,Total_payment,Advance,Balance FROM tbl_repair_order where Job_no like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;


            }


            if (Cmb_field.Text == "CustomerName")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Servicesid,Job_no,Invoicedate,cus_name,cus_number,Mobile_brand,Mobile_model,Mobile_fault,Other_fault,worker,Estimate,mobile_acccess,Reciveid_by,Description,Market,Out_date,Status,Total_payment,Advance,Balance FROM tbl_repair_order where cus_name like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;


            }


            if (Cmb_field.Text == "Mobile")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Servicesid,Job_no,Invoicedate,cus_name,cus_number,Mobile_brand,Mobile_model,Mobile_fault,Other_fault,worker,Estimate,mobile_acccess,Reciveid_by,Description,Market,Out_date,Status,Total_payment,Advance,Balance FROM tbl_repair_order where cus_number like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;


            }

            if (Cmb_field.Text == "Model")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Servicesid,Job_no,Invoicedate,cus_name,cus_number,Mobile_brand,Mobile_model,Mobile_fault,Other_fault,worker,Estimate,mobile_acccess,Reciveid_by,Description,Market,Out_date,Status,Total_payment,Advance,Balance FROM tbl_repair_order where Mobile_model like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;


            }
        }
    }
}
