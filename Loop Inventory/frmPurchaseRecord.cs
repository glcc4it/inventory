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
    public partial class frmPurchaseRecord : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public frmPurchaseRecord()
        {
            InitializeComponent();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void frmPurchaseRecord_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_purchase' table. You can move, or remove it, as needed.
            this.tbl_purchaseTableAdapter.Fill(this.inventory_DBDataSet.tbl_purchase);

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

        

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void btnfetch_Click_1(object sender, EventArgs e)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            SqlDataAdapter sdf = new SqlDataAdapter("select * from tbl_purchase where Invoicedate between '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "'", ModCommonClasses.con);
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

        private void dgw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgw.Rows.Count > 0)
                {

                    {
                        DataGridViewRow dr = dgw.SelectedRows[0];


                        this.Hide();
                        Purchaseproduct frmPurchase = new Purchaseproduct();
                        // or simply use column name instead of index
                        // dr.Cells["id"].Value.ToString();
                        frmPurchase.Show();
                        frmPurchase.txtST_ID.Text = dr.Cells[0].Value.ToString();
                        frmPurchase.txt_invoice.Text = dr.Cells[1].Value.ToString();
                        frmPurchase.dateTimePicker1.Text = dr.Cells[2].Value.ToString();
                        frmPurchase.txt_ven_invoice.Text = dr.Cells[3].Value.ToString();
                        frmPurchase.combo_pur_type.Text = dr.Cells[5].Value.ToString();
                        frmPurchase.txtSup_ID.Text = dr.Cells[6].Value.ToString();
                        frmPurchase.txtSupplierID.Text = dr.Cells[7].Value.ToString();
                        frmPurchase.txtSupplierName.Text = dr.Cells[8].Value.ToString();
                        frmPurchase.txt_total_amount.Text = dr.Cells[9].Value.ToString();
                        frmPurchase.txt_discount.Text = dr.Cells[10].Value.ToString();
                        frmPurchase.txt_dis_amount.Text = dr.Cells[11].Value.ToString();
                        frmPurchase.txt_tax.Text = dr.Cells[12].Value.ToString();
                        frmPurchase.txt_tax_amount.Text = dr.Cells[13].Value.ToString();

                        frmPurchase.txt_net_amount.Text = dr.Cells[14].Value.ToString();
                        frmPurchase.txt_old_bal.Text = dr.Cells[15].Value.ToString();
                        frmPurchase.txt_new_bal.Text = dr.Cells[16].Value.ToString();

                        frmPurchase.txt_paid_amount.Text = dr.Cells[17].Value.ToString();
                        frmPurchase.txt_dues.Text = dr.Cells[18].Value.ToString();
                        frmPurchase.txt_comments.Text = dr.Cells[19].Value.ToString();


                        frmPurchase.btnSave.Enabled = false;
                        frmPurchase.btn_add.Enabled = false;

                        frmPurchase.GetSupplierBalance1();
                        frmPurchase.btnDelete.Enabled = true;

                        frmPurchase.panel22.Enabled = false;





                        ModCommonClasses.con = new SqlConnection(ModCS.cs);
                        ModCommonClasses.con.Open();
                        string sql = "SELECT tbl_pur_product.Productcode,tbl_pur_product.Barcode,tbl_pur_product.Productname,tbl_pur_product.Typeofunit,tbl_pur_product.Description,tbl_pur_product.Purchaseprice,tbl_pur_product.Qty,tbl_pur_product.Total,tbl_pur_product.Mfd,tbl_pur_product.Expdate from tbl_pur_product,tbl_stock_product,tbl_purchase where tbl_purchase.ST_ID=tbl_pur_product.StockID and tbl_stock_product.Productcode=tbl_pur_product.Productcode and tbl_purchase.ST_ID=" + dr.Cells[0].Value.ToString() + "";
                        ModCommonClasses.cmd = new SqlCommand(sql, ModCommonClasses.con);
                        ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        frmPurchase.dataGridView1.Rows.Clear();
                        while (ModCommonClasses.rdr.Read() == true)
                        {
                            frmPurchase.dataGridView1.Rows.Add(ModCommonClasses.rdr[0], ModCommonClasses.rdr[1], ModCommonClasses.rdr[2], ModCommonClasses.rdr[3], ModCommonClasses.rdr[4], ModCommonClasses.rdr[5], ModCommonClasses.rdr[6], ModCommonClasses.rdr[7], ModCommonClasses.rdr[8], ModCommonClasses.rdr[9]);
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

       

       
    }
}
