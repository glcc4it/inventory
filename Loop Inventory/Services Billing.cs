using Microsoft.VisualBasic;
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
    public partial class Services_Billing : Form
    {
        private string str;
        public int num1;
        string Transid = "Trans-";
        public Services_Billing()
        {
            InitializeComponent();
        }



        public void transid()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            SqlCommand cmd = new SqlCommand("select Count(TransactionID) from InvoiceInfo1", ModCommonClasses.con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            ModCommonClasses.con.Close();
            i++;
            txtTransactionNo.Text = Transid + i.ToString();

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Services_Billing_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.InvoiceInfo1' table. You can move, or remove it, as needed.
            this.invoiceInfo1TableAdapter1.Fill(this.inventory_DBDataSet.InvoiceInfo1);
            
           
            transid();


            this.ActiveControl = txtAccountID;
            txtAccountID.Focus();
        }

        private void black_Click(object sender, EventArgs e)
        {
           

            this.Hide();

            Services_Record frmservicesrecord = new Services_Record();
            // or simply use column name instead of index
            // dr.Cells["id"].Value.ToString();
            frmservicesrecord.Show();
            frmservicesrecord.lblSet.Text = "Service";
        }


        public void GetSupplierBalance()
        {
            try
            {
                try
                {
                    num1 = 0;
                    ModCommonClasses.con = new SqlConnection(ModCS.cs);
                    ModCommonClasses.con.Open();
                    string sql = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from ServicesLedgerBook where LedgerNo=@d1 group By LedgerNo";
                    ModCommonClasses.cmd = new SqlCommand(sql, ModCommonClasses.con);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtAccountID.Text);
                    ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (ModCommonClasses.rdr.Read() == true)
                    {
                        num1 = Convert.ToInt32(ModCommonClasses.rdr.GetValue(0));
                    }
                    ModCommonClasses.con.Close();
                    lblBalance.Text = num1.ToString();
                    if (Convert.ToInt32(lblBalance.Text) >= 0)
                    {
                        str = "CR";
                    }
                    else if (Convert.ToInt32(string.CompareOrdinal(lblBalance.Text, "0") < 0) != 0)
                    {
                        str = "DR";
                    }

                    txt_old_bal.Text = num1.ToString();
                    lblBalance.Text = Math.Abs(Convert.ToInt32(lblBalance.Text)).ToString();
                    lblBalance.Text = (lblBalance.Text + " " + str).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "insert into InvoiceInfo1(TransactionID, Date, AccountID, AccountName, Mobile,Status,Outdate,PaymentMode,Oldbalance,Amount,Balance,Remarks) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                ModCommonClasses.cmd = new SqlCommand(cb);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtTransactionNo.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dtpTranactionDate.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txtID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txtAccountName.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txtContactNo.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", cmbStatus.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dtpMobileOutDate.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", cmbPaymentMode.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d9", txt_old_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d10", txt_paid_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d11", txt_dues.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d12", txtRemarks.Text);

                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();




                if (cmbPaymentMode.SelectedIndex == 0)
                {

                    ModFunc.ServicesLedgerBook(dtpTranactionDate.Text, txtAccountID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);

                }


                if (cmbPaymentMode.SelectedIndex == 1 | cmbPaymentMode.SelectedIndex == 2)

                    ModFunc.ServicesLedgerBook(dtpTranactionDate.Text, txtAccountID.Text, "Bank Account", "Payment to " + txtAccountName.Text + "", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);





                if (cmbPaymentMode.SelectedIndex == 0)
                {

                    ModFunc.LedgerSave(dtpTranactionDate.Text, txtAccountID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);
                }


                if (cmbPaymentMode.SelectedIndex == 1 | cmbPaymentMode.SelectedIndex == 2)

                    ModFunc.LedgerSave(dtpTranactionDate.Text, txtAccountID.Text, "Bank Account", "Payment to " + txtAccountName.Text + "", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);






                ModFunc.LogFunc(lblUser.Text, "Added the New Payment Having Transaction No. '" + txtTransactionNo.Text + "'");
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                transid();
                DisplayData2();
                ClearData2();
                btnSave.Enabled = false;
                ModCommonClasses.con.Close();
                this.ActiveControl = txtAccountID;
                txtAccountID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Display Data in DataGridView
        private void DisplayData2()
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "select * from InvoiceInfo1";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            ModCommonClasses.con.Close();
        }
        //Clear Data 
        private void ClearData2()
        {


            txtAccountID.Text = "";
            txtAccountName.Text = "";
            txtContactNo.Text = "";
            cmbPaymentMode.Text = "--- Trans Type---";
            cmbStatus.Text = "--- Select Status---";
            txt_paid_amount.Text = "";
            txtRemarks.Text = "";
            lblBalance.Text = "00";
            txt_old_bal.Text = "";
            txt_dues.Text = "";
        }


        

        private void txtAccountID_TextChanged(object sender, EventArgs e)
        {
            this.ActiveControl = cmbStatus;
            cmbStatus.Focus();
        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentMode.SelectedItem.ToString() == "By Cash")
            {

                this.ActiveControl = txt_paid_amount;
                txt_paid_amount.Focus();

            }



            if (cmbPaymentMode.SelectedItem.ToString() == "By Cheque")
            {

                this.ActiveControl = txt_paid_amount;
                txt_paid_amount.Focus();

            }



            if (cmbPaymentMode.SelectedItem.ToString() == "By Online Transfer")
            {

                this.ActiveControl = txt_paid_amount;
                txt_paid_amount.Focus();

            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem.ToString() == "Resolved")
            {

                this.ActiveControl = cmbPaymentMode;
                cmbPaymentMode.Focus();

            }



            if (cmbStatus.SelectedItem.ToString() == "Unresolved")
            {

                this.ActiveControl = cmbPaymentMode;
                cmbPaymentMode.Focus();

            }



            
        }
    }
}