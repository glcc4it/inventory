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
       
        DataTable dt = new DataTable();

        bool drag = false;
        Point start_point = new Point(0, 0);
        public Cash_Transaction()
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
        private void DisplayData()
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "select * from tbl_transaction";
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
           txtTransactionNo.Text="";
            dtpTranactionDate.Value = System.DateTime.Now;
            cmbAccountType.SelectedIndex = 0;
            txtAccountID.Text = "";
            txtAccountName.Text = "";
            txtContactNo.Text = "";
            cmbPaymentMode.SelectedIndex = 0;
            comboDiscounttype.SelectedIndex = 0;
            textBox1.Text = "";
            comboCurrencyType.SelectedIndex = 0;
            txtPaymentModeDetails.Text = "";
            txtTotalAmountafterdis.Text = "";
            txtNotes.Text = "";
            lblBalance.Text = "0";

        }

        private void Cash_Transaction_Load(object sender, EventArgs e)
        {
            
            
           
            
            

            this.ActiveControl = txtAccountID;
            txtAccountID.Focus();

            Mehroon.Visible = false;
           
            black.Visible = false;


            comboDiscounttype.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "SELECT *FROM tbl_discount";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {


                comboDiscounttype.Items.Add(dr["DiscountName"].ToString());

            }


            ModCommonClasses.con.Close();




            comboCurrencyType.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd1 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd1.CommandType = CommandType.Text;

            ModCommonClasses.cmd1.CommandText = "SELECT *FROM tbl_Currency";
            ModCommonClasses.cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(ModCommonClasses.cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {


                comboCurrencyType.Items.Add(dr1["Name"].ToString());

            }


            ModCommonClasses.con.Close();




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
                
                black.Visible = true;

                
               



                txtAccountID.Text = "";
                txtAccountName.Text = "";
                txtContactNo.Text = "";

                lblBalance.Text = "00";


            }



            if (cmbAccountType.SelectedItem.ToString() == "Customer")
            {
                Mehroon.Visible = true;
               
                black.Visible = false;

               
              
                
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


        

       
        

        private void add2_Click(object sender, EventArgs e)
        {
            Currency_Master ss = new Currency_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void add1_Click(object sender, EventArgs e)
        {
            DiscountMaster ss = new DiscountMaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void Cash_Transaction_Activated(object sender, EventArgs e)
        {
            comboDiscounttype.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "SELECT *FROM tbl_discount";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {


                comboDiscounttype.Items.Add(dr["DiscountName"].ToString());

            }


            ModCommonClasses.con.Close();




            comboCurrencyType.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd1 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd1.CommandType = CommandType.Text;

            ModCommonClasses.cmd1.CommandText = "SELECT *FROM tbl_Currency";
            ModCommonClasses.cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(ModCommonClasses.cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {


                comboCurrencyType.Items.Add(dr1["Name"].ToString());

            }


            ModCommonClasses.con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAccountName.Text == "")
            {
                MessageBox.Show("Please select account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountName.Focus();
                return;
            }
            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();

                string cb = "insert into tbl_transaction([Date],[AccountID],accountname,mobileno,[PaymentMode],[DiscountType],[DiscountAmount],[CurrencyType],[PaymentModeDetails],[Oldbalance],[Amount],[Notes])"+
                    "VALUES ('" + dtpTranactionDate.Text + "' ,'" + txtAccountID.Text + "' ,'"+txtAccountName.Text+"','"+ txtContactNo.Text+"', '" + cmbPaymentMode.Text + "', '" + comboDiscounttype.Text + "', '" + textBox1.Text + "', '" + comboCurrencyType.Text + "', '" + txtPaymentModeDetails.Text + "', '" + lblBalance.Text + "', '" + txtTotalAmountafterdis.Text + "', '" + txtNotes.Text + "')";

                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteReader();
                ModCommonClasses.con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ModFunc.LogFunc(lblUser.Text, "Add the Transaction For Account name  '" + txtAccountName.Text + "' with Amount '" + txtTotalAmountafterdis.Text + "'");
                DisplayData();
                ClearData();

                this.ActiveControl = txtAccountName;
                txtAccountName.Focus();
            }
            catch (Exception)
            {

                throw;
            }





        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_transaction " +
                    "SET " +
     " [Date] = '" + dtpTranactionDate.Text + "' " +
     " ,[AccountID] ='" + txtAccountID.Text + "' " +
     " ,[AccountName] ='" + txtAccountName.Text + "' " +
     " ,[MobileNo] = '" + txtContactNo.Text + "' " +
",[PaymentMode] = '" + cmbPaymentMode.Text + "' " +
     " ,[DiscountType] = '" + comboDiscounttype.Text + "' " +
     " ,[DiscountAmount] = '" + textBox1.Text + "' " +
     " ,[CurrencyType] ='" + comboCurrencyType.Text + "' " +
     " ,[PaymentModeDetails] = '" + cmbPaymentMode.Text + "' " +
     " ,[Oldbalance] = '" + lblBalance.Text + "' " +
     " ,[Amount] = '" + txtTotalAmountafterdis.Text + "' " +
     " ,[Notes] = '" + txtNotes.Text + "' WHERE T_ID='" + txtTransactionNo.Text + "'";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the Transaction with ID  '" + txtTransactionNo.Text + "' info";

                MessageBox.Show("Successfully Updated", "Rack Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the Transaction with ID  '" + txtTransactionNo.Text + "' info");
                DisplayData();
                ClearData();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you Really Want to Delete this Record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    DeleteRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cq = "delete from tbl_transaction where t_id=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtTransactionNo.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the TRansactgion '" + txtTransactionNo.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    ModFunc.LogFunc(lblUser.Text, "Delete the TRansaction '" + txtTransactionNo.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
                if (ModCommonClasses.con.State == ConnectionState.Open)
                    ModCommonClasses.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                    txtTransactionNo.Text = dr.Cells[0].Value.ToString();
                    dtpTranactionDate.Text = dr.Cells[2].Value.ToString();
                    txtAccountID.Text = dr.Cells[3].Value.ToString();
                    txtAccountName.Text = dr.Cells[4].Value.ToString();
                    txtContactNo.Text= dr.Cells[5].Value.ToString();
                    cmbPaymentMode.Text= dr.Cells[6].Value.ToString();
                    comboDiscounttype.Text= dr.Cells[7].Value.ToString();
                    textBox1.Text= dr.Cells[8].Value.ToString();
                    comboCurrencyType.Text= dr.Cells[9].Value.ToString();
                    cmbPaymentMode.Text= dr.Cells[10].Value.ToString();
                    txtTotalAmountafterdis.Text= dr.Cells[11].Value.ToString();
                    txtNotes.Text= dr.Cells[12].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
    

        

    