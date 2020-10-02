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
    public partial class Sale_view : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public Sale_view()
        {
            InitializeComponent();
        }

        private void Sale_view_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_salemaster' table. You can move, or remove it, as needed.
            this.tbl_salemasterTableAdapter.Fill(this.inventory_DBDataSet.tbl_salemaster);

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dgw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgw.Rows.Count > 0)
                {

                    {
                        DataGridViewRow dr = dgw.SelectedRows[0];


                        this.Hide();
                        Saleproduct frmSale = new Saleproduct();
                        // or simply use column name instead of index
                        // dr.Cells["id"].Value.ToString();
                        frmSale.Show();
                        frmSale.txtinvoice.Text = dr.Cells[0].Value.ToString();
                        frmSale.txt_invoice_no.Text = dr.Cells[1].Value.ToString();
                        frmSale.dateTimePicker1.Text = dr.Cells[2].Value.ToString();
                        frmSale.combo_salesman.Text = dr.Cells[3].Value.ToString();
                        frmSale.combo_bil_type.Text = dr.Cells[4].Value.ToString();
                        frmSale.txtCustomerID.Text = dr.Cells[5].Value.ToString();
                        frmSale.txtCustomerName.Text = dr.Cells[6].Value.ToString();
                        frmSale.txt_total_amount.Text = dr.Cells[7].Value.ToString();
                        frmSale.txt_discount.Text = dr.Cells[8].Value.ToString();
                        frmSale.txt_dis_amount.Text = dr.Cells[9].Value.ToString();
                        frmSale.txt_tax.Text = dr.Cells[10].Value.ToString();
                        frmSale.txt_tax_amount.Text = dr.Cells[11].Value.ToString();

                        frmSale.txt_net_amount.Text = dr.Cells[12].Value.ToString();
                        frmSale.txt_old_bal.Text = dr.Cells[13].Value.ToString();
                        frmSale.txt_new_bal.Text = dr.Cells[14].Value.ToString();

                        frmSale.txt_rec_amount.Text = dr.Cells[15].Value.ToString();
                        frmSale.txt_dues.Text = dr.Cells[16].Value.ToString();
                        frmSale.txt_comment.Text = dr.Cells[17].Value.ToString();

                        frmSale.btn_save.Enabled = false;
                        frmSale.btn_add.Enabled = false;

                        frmSale.GetSupplierBalance1();
                        frmSale.btndel.Enabled = true;

                        frmSale.panel22.Enabled = false;




                        ModCommonClasses.con = new SqlConnection(ModCS.cs);
                        ModCommonClasses.con.Open();
                        string sql = "SELECT tbl_sale_pro.Productcode,tbl_sale_pro.Barcode,tbl_sale_pro.Productname,tbl_sale_pro.Price,tbl_sale_pro.Qty,tbl_sale_pro.Typeofunit,tbl_sale_pro.Total from tbl_sale_pro,tbl_stock_product,tbl_salemaster where tbl_salemaster.Inv_ID=tbl_sale_pro.InvoiceID and tbl_stock_product.Productcode=tbl_sale_pro.Productcode and tbl_salemaster.Inv_ID=" + dr.Cells[0].Value.ToString() + "";
                        ModCommonClasses.cmd = new SqlCommand(sql, ModCommonClasses.con);
                        ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        frmSale.dataGridView1.Rows.Clear();
                        while (ModCommonClasses.rdr.Read() == true)
                        {
                            frmSale.dataGridView1.Rows.Add(ModCommonClasses.rdr[0], ModCommonClasses.rdr[1], ModCommonClasses.rdr[2], ModCommonClasses.rdr[3], ModCommonClasses.rdr[4], ModCommonClasses.rdr[5], ModCommonClasses.rdr[6]);
                        }
                        ModCommonClasses.con.Close();







                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

       

        private void panel32_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void panel32_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void panel32_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnfetch_Click(object sender, EventArgs e)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            SqlDataAdapter sdf = new SqlDataAdapter("select * from tbl_salemaster where Date between '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", ModCommonClasses.con);
            DataTable sd = new DataTable();
            sdf.Fill(sd);
            dgw.DataSource = sd;


            int sum = 0;
            for (int i = 0; i < dgw.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgw.Rows[i].Cells[16].Value);
            }
            label14.Text = sum.ToString();
        }

       
    }
}
