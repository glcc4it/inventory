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
    public partial class Purchaseproduct : Form
    {



        private string str;
        public int num1;
        bool drag = false;
        Point start_point = new Point(0, 0);
        
        public Purchaseproduct()
        {
            InitializeComponent();
        }


        public void purinvoice()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = new SqlCommand("select max (Invoiceno)+1 from tbl_purchase", ModCommonClasses.con);
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


        public void stockid()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = new SqlCommand("select max (ST_ID)+1 from tbl_purchase", ModCommonClasses.con);
            SqlDataReader dr = ModCommonClasses.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtST_ID.Text = dr[0].ToString();
                    if (txtST_ID.Text == "")
                    {
                        txtST_ID.Text = "01";

                    }

                }

            }
            else
            {
                txtST_ID.Text = "01";
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

        private void Purchaseproduct_Load(object sender, EventArgs e)
        {
            stockid();
            Search();

            purinvoice();
            combo_pur_type.SelectedIndex = 0;




            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;

            dataGridView1.EnableHeadersVisualStyles = false;



            this.ActiveControl = txt_ven_invoice;
            txt_ven_invoice.Focus();

        }


        public void Reset()
        {
            purinvoice();
            this.ActiveControl = txt_product;
            txt_product.Focus();
            dataGridView1.Rows.Clear();

            combo_pur_type.SelectedIndex = 0;






            txt_qty.Text = "";
            txt_unit.Text = "";
            txt_amount.Text = "";

            txtSupplierName.Text = "";
            txtContactNo.Text = "";
            txt_ven_invoice.Text = "";
            lblBalance.Text = "00";



            txt_current_stock.Text = "";
            txt_total_amount.Text = "";

            txt_discount.Text = "0";
            txt_tax.Text = "0";



            txt_tax_amount.Text = "";
            txt_net_amount.Text = "";
            txt_old_bal.Text = "";
            txt_new_bal.Text = "";

            txt_paid_amount.Text = "0";
            txt_dues.Text = "";
            txt_comments.Text = "";

            txtSup_ID.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string ct = "select Invoiceno from tbl_purchase where Invoiceno=@d1";
                ModCommonClasses.cmd = new SqlCommand(ct);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_invoice.Text);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                if (ModCommonClasses.rdr.Read())
                {
                    MessageBox.Show("Invoice No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_invoice.Text = "";
                    txt_invoice.Focus();
                    if ((ModCommonClasses.rdr != null))
                        ModCommonClasses.rdr.Close();
                    return;
                }
                ModCommonClasses.con.Close();


                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "insert into tbl_purchase(ST_ID,Invoiceno,Invoicedate,Venderinvoice,Venderinvoicedate,PurchaseType,SupplierID,Suppliercode,Suppliername,Grandtotal,Discount,Discountvalue,Tax,Taxvalue,Netamount,Oldbalance,Newbalance,Paidamount,Duesamount,Comments) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)";
                ModCommonClasses.cmd = new SqlCommand(cb);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtST_ID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_invoice.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txt_ven_invoice.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dateTimePicker2.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", combo_pur_type.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txtSup_ID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txtSupplierID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d9", txtSupplierName.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d10", txt_total_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d11", txt_discount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d12", txt_dis_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d13", txt_tax.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d14", txt_tax_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d15", txt_net_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d16", txt_old_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d17", txt_new_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d18", txt_paid_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d19", txt_dues.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d20", txt_comments.Text);

                
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();






                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb1 = "insert into tbl_Temp_pur_product(StockID,Productcode,Barcode,Invoiceno,Date,Suppliername,Productname,Typeofunit,Description,Purchaseprice,Qty,Total,Mfd,Expdate) VALUES (@sId,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
                ModCommonClasses.cmd = new SqlCommand(cb1);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                // Prepare command for repeated execution
                ModCommonClasses.cmd.Prepare();
                // Data to be inserted
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        ModCommonClasses.cmd.Parameters.AddWithValue("@sId", txtST_ID.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txt_invoice.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dateTimePicker1.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txtSupplierName.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d6", row.Cells[2].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d7", row.Cells[3].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d8", row.Cells[4].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d9", row.Cells[5].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d10", row.Cells[6].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d11", row.Cells[7].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d12", row.Cells[8].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d13", row.Cells[9].Value);

                        ModCommonClasses.cmd.ExecuteNonQuery();
                        ModCommonClasses.cmd.Parameters.Clear();

                    }
                }
                ModCommonClasses.con.Close();



                
                
                
                
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb4 = "insert into tbl_pur_product(StockID,Productcode,Barcode,Invoiceno,Date,Suppliername,Productname,Typeofunit,Description,Purchaseprice,Qty,Total,Mfd,Expdate) VALUES (@sId,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)";
                ModCommonClasses.cmd = new SqlCommand(cb4);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                // Prepare command for repeated execution
                ModCommonClasses.cmd.Prepare();
                // Data to be inserted
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        ModCommonClasses.cmd.Parameters.AddWithValue("@sId", txtST_ID.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txt_invoice.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dateTimePicker1.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txtSupplierName.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d6", row.Cells[2].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d7", row.Cells[3].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d8", row.Cells[4].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d9", row.Cells[5].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d10", row.Cells[6].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d11", row.Cells[7].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d12", row.Cells[8].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d13", row.Cells[9].Value);

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
                        string ctx = "select Productcode from Temp_Stock where Productcode=@d1 and Barcodeno=@d2";
                        ModCommonClasses.cmd = new SqlCommand(ctx);
                        ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);
                        ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                        if ((ModCommonClasses.rdr.Read()))
                        {
                            ModCommonClasses.con = new SqlConnection(ModCS.cs);
                            ModCommonClasses.con.Open();
                            string cb2 = "Update Temp_Stock set Quantity = Quantity + " + row.Cells[6].Value + " where Productcode=@d1 and Barcodeno=@d2";
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
                            string cb3 = "insert into Temp_Stock(ProductCode,Barcodeno,Product,Typeofunit,Description,Purchaseprice,Quantity,Mfd,Expdate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
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







                
                
                if (combo_pur_type.SelectedIndex == 1)



                    ModFunc.SupplierLedgerSaveInvoice(dateTimePicker1.Text, txtSupplierID.Text, txtSupplierName.Text, "Purchase", 0, Convert.ToDecimal(txt_new_bal.Text) - Convert.ToDecimal(txt_old_bal.Text), txtContactNo.Text);
                
                
                if (combo_pur_type.SelectedIndex == 0)
                {
                    ModFunc.SupplierLedgerSaveInvoice(dateTimePicker1.Text, txtSupplierID.Text, txtSupplierName.Text, "Purchase", 0, Convert.ToDecimal(txt_new_bal.Text) - Convert.ToDecimal(txt_old_bal.Text), txtContactNo.Text);
                    ModFunc.SupplierLedgerSaveInvoice(dateTimePicker1.Text, txtSupplierID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);
                }




                if (combo_pur_type.SelectedIndex == 1)



                    ModFunc.LedgerSaveInvoice(dateTimePicker1.Text, txtSupplierID.Text, txtSupplierName.Text, "Purchase", 0, Convert.ToDecimal(txt_new_bal.Text) - Convert.ToDecimal(txt_old_bal.Text), txtContactNo.Text);


                if (combo_pur_type.SelectedIndex == 0)
                {
                    ModFunc.LedgerSaveInvoice(dateTimePicker1.Text, txtSupplierID.Text, txtSupplierName.Text, "Purchase", 0, Convert.ToDecimal(txt_new_bal.Text) - Convert.ToDecimal(txt_old_bal.Text), txtContactNo.Text);
                    ModFunc.LedgerSaveInvoice(dateTimePicker1.Text, txtSupplierID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_paid_amount.Text), 0, txtContactNo.Text);
                }



                ModFunc.LogFunc(lblUser.Text, "Added the New Purchase Having Invoice No. '" + txt_invoice.Text + "'");
                MessageBox.Show("Successfully Saved", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.ActiveControl = txt_product;
                txt_product.Focus();

                btnSave.Enabled = false;
                btnNew.Enabled = true;
               
                ModCommonClasses.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        bool change = true;
        private void proCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (change)
            {
                change = true;
                txt_category.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                txt_product.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                txt_barcode.Text = dgview.SelectedRows[0].Cells[2].Value.ToString();
               

                txt_unit.Text = dgview.SelectedRows[0].Cells[5].Value.ToString();


                this.dgview.Visible = false;
                txt_pur_price.Focus();
                change = true;
            }
        }


        private void txt_product_TextChanged(object sender, EventArgs e)
        {
            if (txt_product.Text.Length > 0)
            {
                this.dgview.Visible = true;
                dgview.BringToFront();
                Search(19, 180, 613, 290, "Categoryname,Productname,Barcodeno,Purchaseprice,Quantity,Typeofunit", "120,130,90,90,90,90");
                this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.proCode_MouseDoubleClick);



                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Top(10) Category, Product, Barcodeno, Purchaseprice, Quantity, Typeofunit  From [Temp_Stock] WHERE [Product] Like '" + txt_product.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgview.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dgview.Rows.Add();
                    dgview.Rows[n].Cells[0].Value = row["Category"].ToString();
                    dgview.Rows[n].Cells[1].Value = row["Product"].ToString();
                    dgview.Rows[n].Cells[2].Value = row["Barcodeno"].ToString();
                    dgview.Rows[n].Cells[3].Value = row["Purchaseprice"].ToString();
                    dgview.Rows[n].Cells[4].Value = row["Quantity"].ToString();
                    dgview.Rows[n].Cells[5].Value = row["Typeofunit"].ToString();






                }
            }
            else
            {
                dgview.Visible = false;
            }

        }




        private DataGridView dgview;
        private DataGridViewTextBoxColumn dgviewcol1;
        private DataGridViewTextBoxColumn dgviewcol2;
        private DataGridViewTextBoxColumn dgviewcol3;
        private DataGridViewTextBoxColumn dgviewcol4;
        private DataGridViewTextBoxColumn dgviewcol5;
        private DataGridViewTextBoxColumn dgviewcol6;


        void Search()
        {
            dgview = new DataGridView();
            dgviewcol1 = new DataGridViewTextBoxColumn();
            dgviewcol2 = new DataGridViewTextBoxColumn();
            dgviewcol3 = new DataGridViewTextBoxColumn();
            dgviewcol4 = new DataGridViewTextBoxColumn();
            dgviewcol5 = new DataGridViewTextBoxColumn();
            dgviewcol6 = new DataGridViewTextBoxColumn();


            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgviewcol1, this.dgviewcol2, this.dgviewcol3, this.dgviewcol4, this.dgviewcol5, this.dgviewcol6 });
            this.dgview.Name = "dgview";
            dgview.Visible = false;
            this.dgviewcol1.Visible = false;
            this.dgviewcol2.Visible = false;
            this.dgviewcol3.Visible = false;
            this.dgviewcol4.Visible = false;
            this.dgviewcol5.Visible = false;
            this.dgviewcol6.Visible = false;


            this.dgview.AllowUserToAddRows = false;
            this.dgview.RowHeadersVisible = false;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.dgview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgview_KeyDown);

            this.Controls.Add(dgview);
            this.dgview.ReadOnly = true;
            dgview.BringToFront();
        }

        //Two Column
        void Search(int LX, int LY, int DW, int DH, string ColName, String ColSize)
        {
            this.dgview.Location = new System.Drawing.Point(LX, LY);
            this.dgview.Size = new System.Drawing.Size(DW, DH);

            string[] ClSize = ColSize.Split(',');
            //Size
            for (int i = 0; i < ClSize.Length; i++)
            {
                if (int.Parse(ClSize[i]) != 0)
                {
                    dgview.Columns[i].Width = int.Parse(ClSize[i]);
                }
                else
                {
                    dgview.Columns[i].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            //Name 
            string[] ClName = ColName.Split(',');

            for (int i = 0; i < ClName.Length; i++)
            {
                this.dgview.Columns[i].HeaderText = ClName[i];
                this.dgview.Columns[i].Visible = true;
            }

        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            int value1 = 0;
            int value2 = 0;
            int result = 0;

            if (int.TryParse(txt_qty.Text, out value1) & int.TryParse(txt_pur_price.Text, out value2))
            {
                result = value1 * value2;
                txt_amount.Text = result.ToString();
            }

        }

        private void txt_product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgview.Rows.Count > 0)
                {
                    txt_category.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                    txt_product.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                    txt_barcode.Text = dgview.SelectedRows[0].Cells[2].Value.ToString();
                   
                    txt_unit.Text = dgview.SelectedRows[0].Cells[5].Value.ToString();
                    this.dgview.Visible = false;
                    txt_pur_price.Focus();
                }
                else
                {
                    this.dgview.Visible = false;
                }
            }

        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btn_add.PerformClick();

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


        private void btn_add_Click(object sender, EventArgs e)
        {
            


            if (txt_product.Text != "" && txt_pur_price.Text != "" && txt_qty.Text != "")
            {


                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                ModCommonClasses.cmd = new SqlCommand("select * from Temp_Stock where Product= '" + txt_product.Text + "'", ModCommonClasses.con);

                ModCommonClasses.cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = ModCommonClasses.cmd.ExecuteReader();


                while (dr.Read())
                {


                    int row = 0;
                    dataGridView1.Rows.Add();
                    row = dataGridView1.Rows.Count - 2;

                    




                    string procode = (string)dr["Productcode"].ToString();
                    dataGridView1["Productcode", row].Value = procode;


                    string barcode = (string)dr["Barcodeno"].ToString();
                    dataGridView1["Barcode", row].Value = barcode;


                   


                   


                    string mfd = (string)dr["Mfd"].ToString();
                    dataGridView1["MfD", row].Value = mfd;



                    string expd = (string)dr["Expdate"].ToString();
                    dataGridView1["EXp", row].Value = expd;

                   


                    string des = (string)dr["Description"].ToString();
                    dataGridView1["Description", row].Value = des;


                    
                    dataGridView1["Product", row].Value = txt_product.Text;
                    dataGridView1["Purchaseprice", row].Value = txt_pur_price.Text;
                    dataGridView1["Quantity", row].Value = txt_qty.Text;
                    dataGridView1["Unit", row].Value = txt_unit.Text;




                    dataGridView1["Total", row].Value = txt_amount.Text;





                    this.ActiveControl = txt_category;
                    txt_category.Focus();

                    txt_category.Text = "";
                    txt_product.Text = "";
                    txt_barcode.Text = "";
                    txt_pur_price.Text = "";

                    txt_qty.Text = "";
                    txt_unit.Text = "";
                    txt_amount.Text = "";


                    int sum = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {


                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);

                        txt_total_amount.Text = sum.ToString();
                        txt_net_amount.Text = sum.ToString();



                    }


                }

                ModCommonClasses.con.Close();

            }
            else
            {
                MessageBox.Show("Please Provide Product Details!");
                this.ActiveControl = txt_product;
                txt_product.Focus();


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


                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);

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


                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);

                    txt_total_amount.Text = sum.ToString();
                    txt_net_amount.Text = sum.ToString();


                    txtSup_ID.Text = "";


                }



            }

        }

        private void txt_net_amount_TextChanged(object sender, EventArgs e)
        {
            int value1 = 0;
            int value2 = 0;
            int result = 0;

            if (int.TryParse(txt_net_amount.Text, out value1) & int.TryParse(txt_old_bal.Text, out value2))
            {
                result = value1 + value2;
                txt_new_bal.Text = result.ToString();
                txt_dues.Text = result.ToString();
            }

        }

        private void txt_paid_amount_TextChanged(object sender, EventArgs e)
        {
            int value1 = 0;
            int value2 = 0;
            int result = 0;

            if (int.TryParse(txt_new_bal.Text, out value1) & int.TryParse(txt_paid_amount.Text, out value2))
            {
                result = value1 - value2;
                txt_dues.Text = result.ToString();
            }

        }

        private void Purchaseproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }


        }

        private void combo_pur_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_pur_type.SelectedIndex == 1)
            {
                txt_paid_amount.Text = "0";
                txt_paid_amount.ReadOnly = true;
                txt_paid_amount.Enabled = false;

            }
            else
            {
                txt_paid_amount.Text = "0";
                txt_paid_amount.ReadOnly = false;
                txt_paid_amount.Enabled = true;
            }

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

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            ModCS.InvoiceNumber = txt_ven_invoice.Text;
           

            this.Hide();

            frmSupplierRecord frmsupplierrecord = new frmSupplierRecord();
            // or simply use column name instead of index
            // dr.Cells["id"].Value.ToString();
            frmsupplierrecord.Show();
            frmsupplierrecord.lblSet.Text = "Purchase";


        }


        

      





        













        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmPurchaseRecord frmpurchaseview = new frmPurchaseRecord();
            // or simply use column name instead of index
            // dr.Cells["id"].Value.ToString();
            frmpurchaseview.Show();
            frmpurchaseview.lblSet.Text = "PurchaseView";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
            btnSave.Enabled = true;
        }


        

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            this.ActiveControl = txt_product;
            txt_product.Focus();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
    
}

