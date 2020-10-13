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
    public partial class Purchase_Return : Form
    {

        private string str;
        public int num1;
        
        DataTable dt = new DataTable();

        public Purchase_Return()
        {
            InitializeComponent();
        }



        public void purreturninvoice()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = new SqlCommand("select max (PRNo)+1 from PurchaseReturnmaster", ModCommonClasses.con);
            SqlDataReader dr = ModCommonClasses.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txt_invoice.Text = dr[0].ToString();
                    if (txt_invoice.Text == "")
                    {
                        txt_invoice.Text = "01";

                    }

                }

            }
            else
            {
                txt_invoice.Text = "01";
            }

            ModCommonClasses.con.Close();
        }

       

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

       

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {


                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "insert into PurchaseReturnmaster(PRNo,Date,Purchasetype,PurchaseID,Suppliername,Mobileno,Purchaseinvoice,Grandtotal,Discount,Discountamount,Tax,Taxamount,Netamount,Oldbalance,Newbalance,Suppliernotes) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)";
                ModCommonClasses.cmd = new SqlCommand(cb);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_invoice.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", combo_pur_type.Text);
                
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txtPurchase_ID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txtSupplierName.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txtmobile.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txtPurtinvoice.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txt_net_amount.Text);
             
                ModCommonClasses.cmd.Parameters.AddWithValue("@d9", txt_discount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d10", txt_dis_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d11", txt_tax.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d12", txt_tax_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d13", txt_net_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d14", txt_old_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d15", txt_new_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d16", txt_comments.Text);
               
               


                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();



                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb1 = "insert into PurchaseReturnProduct(Returnno,Date,Purchaseinvoice,Suppliername,Mobileno,Productname,Typeofunit,Purchaseprice,PurQty,Purchasetotal,ReturnQty,Returntotal,Grandtotal) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
                ModCommonClasses.cmd = new SqlCommand(cb1);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                // Prepare command for repeated execution
                ModCommonClasses.cmd.Prepare();
                // Data to be inserted
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_invoice.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dateTimePicker1.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txtPurtinvoice.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txtSupplierName.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txtmobile.Text);


                        ModCommonClasses.cmd.Parameters.AddWithValue("@d6", row.Cells[0].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d7", row.Cells[1].Value);
                        
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d8", row.Cells[2].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d9", row.Cells[3].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d10", row.Cells[4].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d11", row.Cells[5].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d12", row.Cells[6].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d13", txt_net_amount.Text);
                       

                        ModCommonClasses.cmd.ExecuteNonQuery();
                        ModCommonClasses.cmd.Parameters.Clear();

                    }
                }
                
                
                ModCommonClasses.con.Close();
       
                 foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        ModCommonClasses.con = new SqlConnection(ModCS.cs);
                        ModCommonClasses.con.Open();
                        string ctx = "select Product from Temp_Stock where Product=@d1 and Typeofunit=@d2";
                        ModCommonClasses.cmd = new SqlCommand(ctx);
                        ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);
                        ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                        if ((ModCommonClasses.rdr.Read()))
                        {
                            ModCommonClasses.con = new SqlConnection(ModCS.cs);
                            ModCommonClasses.con.Open();
                            string cb2 = "Update Temp_Stock set Quantity = Quantity - " + row.Cells[5].Value + " where Product=@d1 and Typeofunit=@d2";
                            ModCommonClasses.cmd = new SqlCommand(cb2);
                            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);
                            ModCommonClasses.cmd.ExecuteReader();
                            ModCommonClasses.con.Close();
                        }
                        
                    }
                }




                 foreach (DataGridViewRow row in dataGridView1.Rows)
                 {
                     if (!row.IsNewRow)
                     {
                         ModCommonClasses.con = new SqlConnection(ModCS.cs);
                         ModCommonClasses.con.Open();
                         string ctx = "select Productcode from tbl_Temp_pur_product where Productname=@d1 and Typeofunit=@d2";
                         ModCommonClasses.cmd = new SqlCommand(ctx);
                         ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                         ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                         ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);
                         ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                         if ((ModCommonClasses.rdr.Read()))
                         {
                             ModCommonClasses.con = new SqlConnection(ModCS.cs);
                             ModCommonClasses.con.Open();
                             string cb2 = "Update tbl_Temp_pur_product set Qty = Qty - " + row.Cells[5].Value + " where Productname=@d1 and Typeofunit=@d2";
                             ModCommonClasses.cmd = new SqlCommand(cb2);
                             ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                             ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                             ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);
                             ModCommonClasses.cmd.ExecuteReader();
                             ModCommonClasses.con.Close();
                         }
                         else
                         {
                             ModCommonClasses.con = new SqlConnection(ModCS.cs);
                             ModCommonClasses.con.Open();
                             string cb3 = "insert into tbl_Temp_pur_product(ProductCode,Barcodeno,Product,Typeofunit,Description,Purchaseprice,Quantity,Mfd,Expdate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
                             ModCommonClasses.cmd = new SqlCommand(cb3);
                             ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                             ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                             ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);

                             ModCommonClasses.cmd.Parameters.AddWithValue("@d3", row.Cells[2].Value);
                             ModCommonClasses.cmd.Parameters.AddWithValue("@d4", row.Cells[3].Value);

                             ModCommonClasses.cmd.Parameters.AddWithValue("@d5", row.Cells[4].Value);
                             ModCommonClasses.cmd.Parameters.AddWithValue("@d6", row.Cells[5].Value);
                             ModCommonClasses.cmd.Parameters.AddWithValue("@d7", row.Cells[6].Value);
                             ModCommonClasses.cmd.Parameters.AddWithValue("@d8", row.Cells[7].Value);

                             ModCommonClasses.cmd.Parameters.AddWithValue("@d9", row.Cells[8].Value);


                             ModCommonClasses.cmd.ExecuteReader();
                             ModCommonClasses.con.Close();










                         }
                     }
                 }




                 ModFunc.SupplierLedgerSaveInvoice(dateTimePicker1.Text, txtSupplierID.Text, "Cash Account", "Purchase Return", Convert.ToDecimal(txt_net_amount.Text), 0, txtmobile.Text);

                 ModFunc.LedgerSaveInvoice(dateTimePicker1.Text, txtSupplierID.Text, "Cash Account", "Purchase Return", Convert.ToDecimal(txt_net_amount.Text), 0, txtmobile.Text);
                 


                ModFunc.LogFunc(lblUser.Text, "Added the New Purchase Having Invoice No. '" + txt_invoice.Text + "'");
                MessageBox.Show("Successfully Saved", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                

                btnSave.Enabled = false;
                btnNew.Enabled = true;
               
                ModCommonClasses.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        }

        private void Purchase_Return_Load(object sender, EventArgs e)
        {
            purreturninvoice();

            this.ActiveControl = txtSupplierName;
            txtSupplierName.Focus();


           

            combo_pur_type.SelectedIndex = 0;



            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;

            dataGridView1.EnableHeadersVisualStyles = false;

        }

        private void bunifuImageButton10_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            frmSupplierRecord2 frmsupplierrecord = new frmSupplierRecord2();
            // or simply use column name instead of index
            // dr.Cells["id"].Value.ToString();
            frmsupplierrecord.Show();
            frmsupplierrecord.lblSet.Text = "PurchaseReturn";

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
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtSupplierID.Text);
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

        private void txtSupplierName_TextChanged_1(object sender, EventArgs e)
        {
            this.ActiveControl = txtPurtinvoice;
            txtPurtinvoice.Focus();

        }

        private void txtPurtinvoice_TextChanged(object sender, EventArgs e)
        {





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                row.Cells[dataGridView1.Columns["Returntotal"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["Purprice"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["ReturnQty"].Index].Value));

                row.Cells[dataGridView1.Columns["Total"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["Purprice"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Purqty"].Index].Value));

            }







            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {


                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);


                txt_total_amount.Text = sum.ToString();
                txt_net_amount.Text = sum.ToString();

            }

        }



        public void Calculate()
        {
            try
            {
                double val1 = 0;
                double val2 = 0;
                double val3 = 0;
                double val4 = 0;
                double val5 = 0;
                if (txt_discount.Text != "")
                {
                    val1 = Convert.ToInt32((Convert.ToInt32(txt_total_amount.Text) * Convert.ToInt32(txt_discount.Text) / 100));
                    val1 = Math.Round(val1, 2);
                    txt_dis_amount.Text = val1.ToString();

                }
                if (txt_tax.Text != "")
                {
                    val3 = Convert.ToInt32(((Convert.ToInt32(txt_total_amount.Text) + Convert.ToInt32(txt_dis_amount.Text)) * Convert.ToInt32(txt_tax.Text) / 100));
                    val3 = Math.Round(val3, 2);
                    txt_tax_amount.Text = val3.ToString();
                }

                double.TryParse(txt_tax_amount.Text, out val1);
                double.TryParse(txt_total_amount.Text, out val2);
                double.TryParse(txt_dis_amount.Text, out val3);
                double.TryParse(txt_net_amount.Text, out val4);
                double.TryParse(txt_current_stock.Text, out val5);
                val1 = Math.Round(val1, 2);
                val2 = Math.Round(val2, 2);
                val3 = Math.Round(val3, 2);
                val4 = val1 + val2 - val3;
                val4 = Math.Round(val4, 2);
                txt_net_amount.Text = val4.ToString();
                double I = (val5 - val4);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            string value = txt_discount.Text;

            if (value == "")
            {

                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {


                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);

                    txt_total_amount.Text = sum.ToString();
                    txt_net_amount.Text = sum.ToString();


                    txt_dis_amount.Text = "";


                }



            }
        }

        private void txt_tax_TextChanged(object sender, EventArgs e)
        {
            Calculate();


            string value = txt_tax.Text;

            if (value == "")
            {

                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {


                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);

                    txt_total_amount.Text = sum.ToString();
                    txt_net_amount.Text = sum.ToString();


                    


                }



            }
        }

        private void txt_net_amount_TextChanged(object sender, EventArgs e)
        {
            int value1 = 0;
            int value2 = 0;
            int result = 0;

            if (int.TryParse(txt_old_bal.Text, out value1) & int.TryParse(txt_net_amount.Text, out value2))
            {
                result = value1 - value2;
                txt_new_bal.Text = result.ToString();
                
            }
        }

        public void Reset()
        {

            this.ActiveControl = txtSupplierName;
            txtSupplierName.Focus();
            dataGridView1.Rows.Clear();

            combo_pur_type.SelectedIndex = 0;






            txtSupplierName.Text = "";
            txtmobile.Text = "";
          

            txt_total_amount.Text = "";
            txt_discount.Text = "0";
            txt_dis_amount.Text = "0";
            txt_tax.Text = "0";
            txt_tax_amount.Text = "";
            txt_net_amount.Text = "";

            txt_old_bal.Text = "";
            txt_new_bal.Text = "";


            txt_comments.Text = "";

            txtSupplierID.Text = "";


            lblBalance.Text = "00";



            txt_current_stock.Text = "";
           

           
           



           
            
           


            
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
            btnSave.Enabled = true;
        }

        private void txtPurtinvoice_KeyUp(object sender, KeyEventArgs e)
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string insertPur = "SELECT * FROM tbl_Temp_pur_product where Invoiceno = " + txtPurtinvoice.Text + " ";

            SqlDataAdapter da = new SqlDataAdapter(insertPur, ModCommonClasses.con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.Rows.Clear();





            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {


                txtPurchase_ID.Text = ds.Tables[0].Rows[0]["SP_ID"].ToString();
                dataGridView1.Rows.Add(ds.Tables[0].Rows[i]["Productname"].ToString(), ds.Tables[0].Rows[i]["Typeofunit"].ToString(), ds.Tables[0].Rows[i]["Purchaseprice"].ToString(), ds.Tables[0].Rows[i]["Qty"].ToString(), ds.Tables[0].Rows[i]["Total"].ToString());



            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }

        }
    
    


