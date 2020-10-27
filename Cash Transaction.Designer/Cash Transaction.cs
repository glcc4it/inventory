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
    public partial class Cash_Transaction : Form
    {
       
        private string str;
        public int num1;
        string Transid = "Trans-";
        DataTable dt = new DataTable();

        bool drag = false;
        Point start_point = new Point(0, 0);
        public Cash_Transaction()
        {
            InitializeComponent();
        }


        public void transid()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            SqlCommand cmd = new SqlCommand("select Count(TransactionID) from Payment", ModCommonClasses.con);
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

      

        

        private void black_Click(object sender, EventArgs e)
        {
            ModCS.Accounttype = cmbAccountType.Text;
            
            this.Hide();

            frmSupplierRecord1 frmsupplierrecord = new frmSupplierRecord1();
            // or simply use column name instead of index
            // dr.Cells["id"].Value.ToString();
            frmsupplierrecord.Show();
            frmsupplierrecord.lblSet.Text = "Payment";
        }

        private void Cash_Transaction_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.Payment' table. You can move, or remove it, as needed.
            this.paymentTableAdapter.Fill(this.inventory_DBDataSet.Payment);
            
           
            
            transid();

            this.ActiveControl = txtAccountID;
            txtAccountID.Focus();

            Mehroon.Visible = false;
            green.Visible = false;
            black.Visible = false;
            
            DisplayData();
            ClearData();


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
                    string sql = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where LedgerNo=@d1 group By LedgerNo";
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
                string cb = "insert into Payment(TransactionID, Date, PaymentMode, AccountID, Oldbalance,Amount,Balanceamount,PaymentModeDetails) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                ModCommonClasses.cmd = new SqlCommand(cb);
               
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtTransactionNo.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dtpTranactionDate.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", cmbPaymentMode.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txtID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txt_old_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txt_paid_amount.Text);
               
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txt_dues.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txtPaymentModeDetails.Text);
                
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();




                if (cmbPaymentMode.SelectedIndex == 0)
                {

                    ModFunc.SupplierLedgerSaveInvoice(dtpTranactionDate.Text, txtAccountID.Text, "Cash Account", "Payment to", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);
                   
                }


                if (cmbPaymentMode.SelectedIndex == 1 | cmbPaymentMode.SelectedIndex == 2)

                    ModFunc.SupplierLedgerSaveInvoice(dtpTranactionDate.Text, txtAccountID.Text, "Bank Account", "Payment to " + txtAccountName.Text + "", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);




                
                if (cmbPaymentMode.SelectedIndex == 0)
                {

                    ModFunc.LedgerSave(dtpTranactionDate.Text, txtAccountID.Text, "Cash Account", "Payment to", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);
                }


                if (cmbPaymentMode.SelectedIndex == 1 | cmbPaymentMode.SelectedIndex == 2)

                    ModFunc.LedgerSave(dtpTranactionDate.Text, txtAccountID.Text, "Bank Account", "Payment to " + txtAccountName.Text + "", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);

               
                
                
                
        
                ModFunc.LogFunc(lblUser.Text, "Added the New Payment Having Transaction No. '" + txtTransactionNo.Text + "'");
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                transid();
                DisplayData();
                ClearData();
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
        private void DisplayData()
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "select * from Payment";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            ModCommonClasses.con.Close();
        }
        //Clear Data 
        private void ClearData()
        {

            
            txtAccountID.Text = "";
            txtAccountName.Text = "";
            txtContactNo.Text = "";
            cmbPaymentMode.Text = "--- Trans Type---";
            cmbAccountType.Text = "--- Select Account Type---";
            txt_paid_amount.Text = "";
            txtPaymentModeDetails.Text = "";
            lblBalance.Text = "00";
            

        }

        private void txt_paid_amount_TextChanged(object sender, EventArgs e)
        {
            int value1 = 0;
            int value2 = 0;
            int result = 0;

            if (int.TryParse(txt_old_bal.Text, out value1) & int.TryParse(txt_paid_amount.Text, out value2))
            {
                result = value1 - value2;
                txt_dues.Text = result.ToString();
            }
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

       

        





        public void GetSupplierBalance1()
        {
            try
            {
                try
                {
                    num1 = 0;
                    ModCommonClasses.con = new SqlConnection(ModCS.cs);
                    ModCommonClasses.con.Open();
                    string sql = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from CustomerLedgerBook where LedgerNo=@d1 group By LedgerNo";
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

        private void txtAccountID_TextChanged(object sender, EventArgs e)
        {
            this.ActiveControl = cmbPaymentMode;
            cmbPaymentMode.Focus();
        }

        private void cmbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountType.SelectedItem.ToString() == "Supplier")
            {
                Mehroon.Visible = false;
                green.Visible = false;
                black.Visible = true;

                btnSave2.Visible = true;
                btnSave1.Visible = false;



                txtAccountID.Text = "";
                txtAccountName.Text = "";
                txtContactNo.Text = "";

                lblBalance.Text = "00";


            }



            if (cmbAccountType.SelectedItem.ToString() == "Customer")
            {
                Mehroon.Visible = true;
                green.Visible = false;
                black.Visible = false;

                btnSave2.Visible = false;
                btnSave1.Visible = true;
                
                txtAccountID.Text = "";
                txtAccountName.Text = "";
                txtContactNo.Text = "";

                lblBalance.Text = "00";

            }




            if (cmbAccountType.SelectedItem.ToString() == "Services")
            {
                black.Visible = false;
                Mehroon.Visible = false;
                green.Visible = true;


                btnSave.Visible = false;
                btnSave1.Visible = false;
                btnSave2.Visible = true;


                txtAccountID.Text = "";
                txtAccountName.Text = "";
                txtContactNo.Text = "";

                lblBalance.Text = "00";


            }

        }

        private void Mehroon_Click(object sender, EventArgs e)
        {
            ModCS.Accounttype = cmbAccountType.Text;

            this.Hide();

            frmCustomerRecord1 frmcustomerrecord = new frmCustomerRecord1();
            // or simply use column name instead of index
            // dr.Cells["id"].Value.ToString();
            frmcustomerrecord.Show();
            frmcustomerrecord.lblSet.Text = "Sale";

            
        }

        private void green_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
           
            
            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "insert into Payment(TransactionID, Date, PaymentMode, AccountID, Oldbalance,Amount,Balanceamount,PaymentModeDetails) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                ModCommonClasses.cmd = new SqlCommand(cb);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtTransactionNo.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dtpTranactionDate.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", cmbPaymentMode.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txtID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txt_old_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txt_paid_amount.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txt_dues.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txtPaymentModeDetails.Text);

                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();




                if (cmbPaymentMode.SelectedIndex == 0)
                {

                    ModFunc.CustomerLedgerSaveInvoice(dtpTranactionDate.Text, txtAccountID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);

                }


                if (cmbPaymentMode.SelectedIndex == 1 | cmbPaymentMode.SelectedIndex == 2)

                    ModFunc.CustomerLedgerSaveInvoice(dtpTranactionDate.Text, txtAccountID.Text, "Bank Account", "Payment to " + txtAccountName.Text + "", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);





                if (cmbPaymentMode.SelectedIndex == 0)
                {

                    ModFunc.LedgerSave(dtpTranactionDate.Text, txtAccountID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);
                }


                if (cmbPaymentMode.SelectedIndex == 1 | cmbPaymentMode.SelectedIndex == 2)

                    ModFunc.LedgerSave(dtpTranactionDate.Text, txtAccountID.Text, "Bank Account", "Payment to " + txtAccountName.Text + "", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);






                ModFunc.LogFunc(lblUser.Text, "Added the New Payment Having Transaction No. '" + txtTransactionNo.Text + "'");
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                transid();
                DisplayData1();
                ClearData1();
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
        private void DisplayData1()
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "select * from Payment";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            ModCommonClasses.con.Close();
        }
        //Clear Data 
        private void ClearData1()
        {


            txtAccountID.Text = "";
            txtAccountName.Text = "";
            txtContactNo.Text = "";
            cmbPaymentMode.Text = "--- Trans Type---";
            cmbAccountType.Text = "--- Select Account Type---";
            txt_paid_amount.Text = "";
            txtPaymentModeDetails.Text = "";
            lblBalance.Text = "00";


            Mehroon.Visible = false;
            green.Visible = false;
            black.Visible = false;


        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }


        

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "insert into Payment(TransactionID, Date, PaymentMode, AccountID, Oldbalance,Amount,Balanceamount,PaymentModeDetails) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                ModCommonClasses.cmd = new SqlCommand(cb);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtTransactionNo.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dtpTranactionDate.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", cmbPaymentMode.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txtID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txt_old_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txt_paid_amount.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txt_dues.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txtPaymentModeDetails.Text);

                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();




                if (cmbPaymentMode.SelectedIndex == 0)
                {

                    ModFunc.SupplierLedgerSaveInvoice(dtpTranactionDate.Text, txtAccountID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);

                }


                if (cmbPaymentMode.SelectedIndex == 1 | cmbPaymentMode.SelectedIndex == 2)

                    ModFunc.SupplierLedgerSaveInvoice(dtpTranactionDate.Text, txtAccountID.Text, "Bank Account", "Payment to " + txtAccountName.Text + "", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);





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

            ModCommonClasses.cmd.CommandText = "select * from Payment";
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
            cmbAccountType.Text = "--- Select Account Type---";
            txt_paid_amount.Text = "";
            txtPaymentModeDetails.Text = "";
            lblBalance.Text = "00";
        }
    }
    
}
    

        

    