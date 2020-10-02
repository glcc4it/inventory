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
    public partial class Saleproduct : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        private string str;
        public int num1;
        DataTable dt = new DataTable();
        public Saleproduct()
        {
            InitializeComponent();
        }




        public void stockid()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = new SqlCommand("select max (Inv_ID)+1 from tbl_salemaster", ModCommonClasses.con);
            SqlDataReader dr = ModCommonClasses.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtinvoice.Text = dr[0].ToString();
                    if (txtinvoice.Text == "")
                    {
                        txtinvoice.Text = "01";

                    }

                }

            }
            else
            {
                txtinvoice.Text = "01";
            }

            ModCommonClasses.con.Close();
        }


        public void autonumber()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = new SqlCommand("select max (Invoiceno)+1 from tbl_sale_pro", ModCommonClasses.con);
            SqlDataReader dr = ModCommonClasses.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txt_invoice_no.Text = dr[0].ToString();
                    if (txt_invoice_no.Text == "")
                    {
                        txt_invoice_no.Text = "01";

                    }

                }

            }
            else
            {
                txt_invoice_no.Text = "01";
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

        private void Saleproduct_Load(object sender, EventArgs e)
        {


            dt.Columns.Add("Productcode");
            dt.Columns.Add("Barcode");
            
            dt.Columns.Add("Product");
            dt.Columns.Add("Saleprice");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Unit");
            dt.Columns.Add("Total");



            combo_salesman.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd1 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd1.CommandType = CommandType.Text;

            ModCommonClasses.cmd1.CommandText = "SELECT *FROM tbl_salesman";
            ModCommonClasses.cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(ModCommonClasses.cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {


                combo_salesman.Items.Add(dr1["Salesmanname"].ToString());

            }


            ModCommonClasses.con.Close();





            


            Search();
            stockid();




            combo_bil_type.SelectedIndex = 0;

            combo_salesman.SelectedIndex = 0;

            autonumber();

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;

            dataGridView1.EnableHeadersVisualStyles = false;





            
            this.ActiveControl = txt_pro_name;
            
        }

      

        private void Saleproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }

        bool change = true;
        private void proCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (change)
            {
                change = true;

                txt_barcode.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                txt_pro_code.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                txt_pro_name.Text = dgview.SelectedRows[0].Cells[2].Value.ToString();
                txt_current_stock.Text = dgview.SelectedRows[0].Cells[3].Value.ToString();
                txt_unit.Text = dgview.SelectedRows[0].Cells[5].Value.ToString();


                this.dgview.Visible = false;
                txt_price.Focus();
                change = true;
            }
        }

        private void txt_pro_name_TextChanged(object sender, EventArgs e)
        {
            if (txt_pro_name.Text.Length > 0)
            {
                this.dgview.Visible = true;
                dgview.BringToFront();
                Search(19, 181, 613, 290, "Barcodeno,Productcode,Productname,Currentstock,Purchaseprice,Typeofunit", "110,90,130,90,90");
                this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.proCode_MouseDoubleClick);



                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Top(10) Barcodeno, Productcode, Product, Quantity, Purchaseprice, Typeofunit  From [Temp_Stock] WHERE [Product] Like '" + txt_pro_name.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgview.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dgview.Rows.Add();
                    dgview.Rows[n].Cells[0].Value = row["Barcodeno"].ToString();
                    dgview.Rows[n].Cells[1].Value = row["Productcode"].ToString();
                    dgview.Rows[n].Cells[2].Value = row["Product"].ToString();
                    dgview.Rows[n].Cells[3].Value = row["Quantity"].ToString();
                    dgview.Rows[n].Cells[4].Value = row["Purchaseprice"].ToString();
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

        private void txt_pro_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgview.Rows.Count > 5)
                {


                    txt_barcode.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                    txt_pro_name.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                    txt_current_stock.Text = dgview.SelectedRows[0].Cells[2].Value.ToString();
                    txt_unit.Text = dgview.SelectedRows[0].Cells[4].Value.ToString();
                    this.dgview.Visible = false;
                    txt_price.Focus();
                }
                else
                {
                    this.dgview.Visible = false;
                }
            }
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            int value1 = 0;
            int value2 = 0;
            int result = 0;

            if (int.TryParse(txt_qty.Text, out value1) & int.TryParse(txt_price.Text, out value2))
            {
                result = value1 * value2;
                txt_amount.Text = result.ToString();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
           


           








            int stock = 0;

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd1 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd1.CommandType = CommandType.Text;

            ModCommonClasses.cmd1.CommandText = "select * from tbl_stock_product where Product='" + txt_pro_name.Text + "'";
            ModCommonClasses.cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(ModCommonClasses.cmd1);
            da1.Fill(dt1);
            ModCommonClasses.con.Close();
            foreach (DataRow dr1 in dt1.Rows)
            {
                stock = Convert.ToInt32(dr1["Quantity"].ToString());
            }

            if (Convert.ToInt32(txt_qty.Text) > stock)
            {


                MessageBox.Show("This Much Value Is Not Available");


            }


            else
            {




                DataRow dr = dt.NewRow();


                dr["Productcode"] = txt_pro_code.Text;
                dr["Barcode"] = txt_barcode.Text;
                dr["Product"] = txt_pro_name.Text;
                dr["Saleprice"] = txt_price.Text;
                dr["Quantity"] = txt_qty.Text;
                dr["Unit"] = txt_unit.Text;
                dr["Total"] = txt_amount.Text;

                dt.Rows.Add(dr);
                dataGridView1.DataSource = dt;
                clearItem();

                txt_barcode.Focus();



                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {


                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);

                    txt_total_amount.Text = sum.ToString();
                    txt_net_amount.Text = sum.ToString();
                  
                }




            }








        }




        void clearItem()
        {
            //Clearing item after enter the value

            txt_pro_name.Text = "";
            txt_barcode.Text = "";
            txt_current_stock.Text = "";
            txt_price.Text = "";
            txt_qty.Text = "";
            txt_unit.Text = "";
            txt_amount.Text = "";
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btn_add.PerformClick();

            }
        }





        private void Saleproduct_Activated(object sender, EventArgs e)
        {
            combo_salesman.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd1 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd1.CommandType = CommandType.Text;

            ModCommonClasses.cmd1.CommandText = "SELECT *FROM tbl_salesman";
            ModCommonClasses.cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(ModCommonClasses.cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {


                combo_salesman.Items.Add(dr1["Salesmanname"].ToString());

            }


            ModCommonClasses.con.Close();





           
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
                double.TryParse(txt_total_items.Text, out val5);
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


                    txt_tax_amount.Text = "";


                }



            }

        }

        private void Reset()
        {


            this.ActiveControl = txt_pro_name;
            txt_pro_name.Focus();
            dt.Clear();
            txt_qty.Text = "";
            txtCustomerName.Text = "";
            txt_cus_mob.Text = "";
            txt_unit.Text = "";
            txt_amount.Text = "";
            txt_total_items.Text = "";
            txt_total_amount.Text = "0";
            
            txt_discount.Text = "0";
            txt_tax.Text = "0";
            lblBalance.Text = "00";
            

            txt_tax_amount.Text = "0";
            txt_net_amount.Text = "";
            txt_old_bal.Text = "";
            txt_new_bal.Text = "";

            txt_rec_amount.Text = "";
            txt_dues.Text = "";

            txt_comment.Text = "";

            btn_save.Enabled = true;
          

            
            autonumber();
        }





        private void Reset1()
        {


            this.ActiveControl = txt_pro_name;
            txt_pro_name.Focus();
            dataGridView1.Rows.Clear();
            txt_qty.Text = "";
            txtCustomerName.Text = "";
            txt_cus_mob.Text = "";
            txt_unit.Text = "";
            txt_amount.Text = "";
            txt_total_items.Text = "";
            txt_total_amount.Text = "0";

            txt_discount.Text = "0";
            txt_tax.Text = "0";
            lblBalance.Text = "00";


            txt_tax_amount.Text = "0";
            txt_net_amount.Text = "";
            txt_old_bal.Text = "";
            txt_new_bal.Text = "";

            txt_rec_amount.Text = "";
            txt_dues.Text = "";

            txt_comment.Text = "";

            btn_save.Enabled = true;



            autonumber();
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

        private void txt_rec_amount_TextChanged(object sender, EventArgs e)
        {
            int value1 = 0;
            int value2 = 0;
            int result = 0;

            if (int.TryParse(txt_new_bal.Text, out value1) & int.TryParse(txt_rec_amount.Text, out value2))
            {
                result = value1 - value2;
                txt_dues.Text = result.ToString();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {


            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string ct = "select Invoiceno from tbl_salemaster where Invoiceno=@d1";
                ModCommonClasses.cmd = new SqlCommand(ct);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_invoice_no.Text);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                if (ModCommonClasses.rdr.Read())
                {
                    MessageBox.Show("Invoice No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_invoice_no.Text = "";
                    txt_invoice_no.Focus();
                    if ((ModCommonClasses.rdr != null))
                        ModCommonClasses.rdr.Close();
                    return;
                }
                ModCommonClasses.con.Close();


                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "insert into tbl_salemaster(Inv_ID,Invoiceno,Date,Salesman,Saletype,CustomerID,Customer,Grandtotal,Discount,Discountvalue,Tax,Taxvalue,Netamount,Oldbalance,Newbalance,Receivedamount,Balance,Comments) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)";
                ModCommonClasses.cmd = new SqlCommand(cb);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtinvoice.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_invoice_no.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", combo_salesman.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", combo_bil_type.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txtCus_ID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txtCustomerName.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txt_total_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d9", txt_discount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d10", txt_dis_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d11", txt_tax.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d12", txt_tax_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d13", txt_net_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d14", txt_old_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d15", txt_new_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d16", txt_rec_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d17", txt_dues.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d18", txt_comment.Text);


                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();






                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb1 = "insert into tbl_Temp_sale_product(InvoiceID,Productcode,Barcode,Invoiceno,Date,Customer,Productname,Price,Qty,Typeofunit,Total) VALUES (@sId,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                ModCommonClasses.cmd = new SqlCommand(cb1);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                // Prepare command for repeated execution
                ModCommonClasses.cmd.Prepare();
                // Data to be inserted
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        ModCommonClasses.cmd.Parameters.AddWithValue("@sId", txtinvoice.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txt_invoice_no.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txtCustomerName.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d6", row.Cells[2].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d7", row.Cells[3].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d8", row.Cells[4].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d9", row.Cells[5].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d10", row.Cells[6].Value);

                        ModCommonClasses.cmd.ExecuteNonQuery();
                        ModCommonClasses.cmd.Parameters.Clear();

                    }
                }
                ModCommonClasses.con.Close();




                
                
                
                
                
                
                
                
                
                
                
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb2 = "insert into tbl_sale_pro(InvoiceID,Productcode,Barcode,Invoiceno,Date,Customer,Productname,Price,Qty,Typeofunit,Total) VALUES (@sId,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                ModCommonClasses.cmd = new SqlCommand(cb2);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                // Prepare command for repeated execution
                ModCommonClasses.cmd.Prepare();
                // Data to be inserted
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        ModCommonClasses.cmd.Parameters.AddWithValue("@sId", txtinvoice.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txt_invoice_no.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txtCustomerName.Text);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d6", row.Cells[2].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d7", row.Cells[3].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d8", row.Cells[4].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d9", row.Cells[5].Value);
                        ModCommonClasses.cmd.Parameters.AddWithValue("@d10", row.Cells[6].Value);

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
                            string cb3 = "Update Temp_Stock set Quantity = Quantity - " + row.Cells[4].Value + " where Productcode=@d1 and Barcodeno=@d2";
                            ModCommonClasses.cmd = new SqlCommand(cb3);
                            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value);
                            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value);
                            ModCommonClasses.cmd.ExecuteReader();
                            ModCommonClasses.con.Close();
                        }
                       
                        }
                    }




                if (combo_bil_type.SelectedIndex == 1)

                    ModFunc.CustomerLedgerSave(dateTimePicker1.Text, txtCustomerID.Text, txtCustomerName.Text, "Sale Credit", 0, Convert.ToDecimal(txt_new_bal.Text) - Convert.ToDecimal(txt_old_bal.Text), txt_cus_mob.Text);

                if (combo_bil_type.SelectedIndex == 0)
                {
                    ModFunc.CustomerLedgerSave(dateTimePicker1.Text, txtCustomerID.Text, txtCustomerName.Text, "Sale Credit", 0, Convert.ToDecimal(txt_new_bal.Text) - Convert.ToDecimal(txt_old_bal.Text), txt_cus_mob.Text);
                    ModFunc.CustomerLedgerSave(dateTimePicker1.Text, txtCustomerID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_rec_amount.Text), 0, txt_cus_mob.Text);
                }


                if (combo_bil_type.SelectedIndex == 1)



                    ModFunc.LedgerSaveInvoice(dateTimePicker1.Text, txtCustomerID.Text, txtCustomerName.Text, "Sale Credit", 0, Convert.ToDecimal(txt_new_bal.Text) - Convert.ToDecimal(txt_old_bal.Text), txt_cus_mob.Text);


                if (combo_bil_type.SelectedIndex == 0)
                {
                    ModFunc.LedgerSaveInvoice(dateTimePicker1.Text, txtCustomerID.Text, txtCustomerName.Text, "Sale Credit", 0, Convert.ToDecimal(txt_new_bal.Text) - Convert.ToDecimal(txt_old_bal.Text), txt_cus_mob.Text);
                    ModFunc.LedgerSaveInvoice(dateTimePicker1.Text, txtCustomerID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_rec_amount.Text), 0, txt_cus_mob.Text);
                }




                printDocument1.Print();
                ModFunc.LogFunc(lblUser.Text, "Added the New Sale Having Invoice No. '" + txt_invoice_no.Text + "'");
                MessageBox.Show("Successfully Saved", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                stockid();
                this.ActiveControl = txt_pro_name;
                txt_pro_name.Focus();

                btn_save.Enabled = false;
                btnnew.Enabled = true;
               

              



                

                ModCommonClasses.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

               


                

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd4 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd4.CommandType = CommandType.Text;

            ModCommonClasses.cmd4.CommandText = "SELECT *FROM tbl_company";
            ModCommonClasses.cmd4.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(ModCommonClasses.cmd4);
            da3.Fill(dt3);


            
           {



               e.Graphics.DrawString("   " + dt3.Rows[0]["Businessname"].ToString(), new Font("Arial", 8, FontStyle.Bold),
          Brushes.Black, new Point(17, 88));



               e.Graphics.DrawString("Address:   " + dt3.Rows[0]["Addres"].ToString(), new Font("Arial", 6, FontStyle.Regular),
        Brushes.Black, new Point(27, 100));


               e.Graphics.DrawString("Mobileno:  " + dt3.Rows[0]["Mobile"].ToString(), new Font("Arial", 6, FontStyle.Regular),
       Brushes.Black, new Point(27, 110));


               e.Graphics.DrawString("Website:   " + dt3.Rows[0]["Website"].ToString(), new Font("Arial", 6, FontStyle.Regular),
      Brushes.Black, new Point(27, 120));


               



					}


            
            e.Graphics.DrawString("Invoice:   " + txt_invoice_no.Text, new Font("Arial", 6, FontStyle.Regular),
          Brushes.Black, new Point(30, 140));

            e.Graphics.DrawString("Date:   " + dateTimePicker1.Text, new Font("Arial", 6, FontStyle.Regular),
          Brushes.Black, new Point(170, 140));

            e.Graphics.DrawString("Customer Name:   " + txtCustomerName.Text, new Font("Arial", 6, FontStyle.Regular),
           Brushes.Black, new Point(30, 155));


            e.Graphics.DrawString("Mobile:   " + txt_cus_mob.Text, new Font("Arial", 6, FontStyle.Regular),
             Brushes.Black, new Point(170, 155));



            e.Graphics.DrawString("------------------------------------------", new Font("Arial", 12, FontStyle.Regular),
              Brushes.Black, new Point(25, 160));

            e.Graphics.DrawString("Product", new Font("Arial", 6, FontStyle.Regular),
             Brushes.Black, new Point(28, 180));

            e.Graphics.DrawString("Price", new Font("Arial", 6, FontStyle.Regular),
            Brushes.Black, new Point(125, 180));

            e.Graphics.DrawString("Qty", new Font("Arial", 6, FontStyle.Regular),
           Brushes.Black, new Point(160, 180));


            e.Graphics.DrawString("Unit", new Font("Arial", 6, FontStyle.Regular),
           Brushes.Black, new Point(190, 180));


            e.Graphics.DrawString("Total", new Font("Arial", 6, FontStyle.Regular),
          Brushes.Black, new Point(220, 180));

            e.Graphics.DrawString("------------------------------------------", new Font("Arial", 12, FontStyle.Regular),
                Brushes.Black, new Point(25, 190));


            int yPos = 210;

            foreach (DataRow dr in dt.Rows)
            {
                e.Graphics.DrawString(dr["Product"].ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                e.Graphics.DrawString(dr["Saleprice"].ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(127, yPos));
                e.Graphics.DrawString(dr["Quantity"].ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(163, yPos));
                e.Graphics.DrawString(dr["Unit"].ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(189, yPos));
                e.Graphics.DrawString(dr["Total"].ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(224, yPos));

                yPos += 13;
            }


            e.Graphics.DrawString("------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, yPos));

            e.Graphics.DrawString("Subtotal:      " + txt_total_amount.Text.Trim(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(175, yPos + 18));

            e.Graphics.DrawString("Discount:      " + txt_dis_amount.Text.Trim(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(175, yPos + 33));

            e.Graphics.DrawString("Taxamount:  " + txt_tax_amount.Text.Trim(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(175, yPos + 48));

            e.Graphics.DrawString("Net total:      " + txt_net_amount.Text.Trim(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(175, yPos + 63));

            e.Graphics.DrawString("Oldbalnce:    " + txt_old_bal.Text.Trim(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(175, yPos + 78));

            e.Graphics.DrawString("Newbalnce:  " + txt_new_bal.Text.Trim(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(175, yPos + 93));

            e.Graphics.DrawString("Received:   " + txt_rec_amount.Text.Trim(), new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(175, yPos + 108));

            e.Graphics.DrawString("Balance:     " + txt_dues.Text.Trim(), new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(175, yPos + 123));


            e.Graphics.DrawString("          " + txt_footer_message.Text.Trim(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(30, yPos + 140));

            e.Graphics.DrawString("                   " + txt_greeting.Text.Trim(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(30, yPos + 150));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            Reset();
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Salesmanmaster ss = new Salesmanmaster();
            ss.Show();
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmCustomerRecord frmcustomerrecord = new frmCustomerRecord();
            // or simply use column name instead of index
            // dr.Cells["id"].Value.ToString();
            frmcustomerrecord.Show();
            frmcustomerrecord.lblSet.Text = "Sale";
        }

        private void combo_bil_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_bil_type.SelectedIndex == 1)
            {
                txt_rec_amount.Text = "0";
                txt_rec_amount.ReadOnly = true;
                txt_rec_amount.Enabled = false;

            }
            else
            {
                txt_rec_amount.Text = "0";
                txt_rec_amount.ReadOnly = false;
                txt_rec_amount.Enabled = true;
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
                    string sql = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from CustomerLedgerBook where LedgerNo=@d1 group By LedgerNo";
                    ModCommonClasses.cmd = new SqlCommand(sql, ModCommonClasses.con);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtCustomerID.Text);
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

        private void btnget_Click(object sender, EventArgs e)
        {
            this.Hide();

            Sale_view frmsaleview = new Sale_view();
            // or simply use column name instead of index
            // dr.Cells["id"].Value.ToString();
            frmsaleview.Show();
            frmsaleview.lblSet.Text = "Saleview";
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
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtCustomerID.Text);
                    ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if ((ModCommonClasses.rdr.Read() == true))
                        num1 = Convert.ToInt32(ModCommonClasses.rdr.GetValue(0));
                    ModCommonClasses.con.Close();
                    lblBalance.Text = num1.ToString();
                    if (Convert.ToInt32(lblBalance.Text) >= 0)
                        str = "CR";
                    else if (Convert.ToInt32(string.CompareOrdinal(lblBalance.Text, "0") < 0) != 0)
                        str = "DR";
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
    }
}
