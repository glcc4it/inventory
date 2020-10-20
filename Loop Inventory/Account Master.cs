using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loop_Inventory
{
    public partial class Account_Master : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Account_Master()
        {
            InitializeComponent();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ClearField()
        {
            //txt_Barcode1.Text = "";
            //txt_Barcode2.Text = "";
            //txt_Productcode.Text = "";
            //txt_ProductnameArabic.Text = "";
            //txt_ProductnameEng.Text = "";
            //combo_Store.SelectedIndex = 0;// = "";
            //combo_Brand.SelectedIndex = 0;// ;
            //combo_Category.SelectedIndex = 0;// ;
            //combo_Unit.SelectedIndex = 0;// ;
            //combo_Color.SelectedIndex = 0;// ;
            //txt_Description.Text = "";
            //txt_QtyPerUnit.Text = "";
            //txt_CompanyProduct.Text = "";
            //txt_PreferredVender.Text = "";
            //combo_DiscountType.SelectedIndex = 0;//= "";
            //txt_DirectDiscount.Text = "";
            //txt_NextShoppingDiscount.Text = "";
            //txt_TaxPercentage.Text = "";
            //txt_ReorderLevel.Text = "";
            //dateTimePicker2.Value = System.DateTime.Now;
            //dateTimePicker1.Value = System.DateTime.Now;// "";
            //combo_PurchaseCurency.SelectedIndex = 0;// ;
            //combo_SellingCurrency.SelectedIndex = 0;// ;
            //txt_WholeSalePrice.Text = "";
            //txt_PurchasePrice.Text = "";
            //txt_CustomerPrice.Text = "";
            //txt_RetailPrice.Text = "";
            //txt_AddProfit.Text = "";
            //combo_Status.SelectedIndex = 0;// ;
            refreshGrid();
        }
        public void refreshGrid()
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            var tb = db.tbl_AccountMaster.ToList();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].Width = 0;


        }
        private void Account_Master_Load(object sender, EventArgs e)
        {
            refreshGrid();

            this.ActiveControl = cmbAccounttype;
            cmbAccounttype.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            tbl_AccountMaster tb = new tbl_AccountMaster();
            tb.AccountNumber = txtAccountNo.Text;
            DateTime dttransactiondate = DateTime.Parse(dtpTranactionDate.Value.ToString());
            tb.Date = dttransactiondate;
            tb.Accounttype = cmbAccounttype.Text;
            tb.AccountName = txtAccountName.Text;
            tb.SubAccountof = txtSubAccount.Text;
            tb.AccountRules = txtAccountRules.Text;
            tb.AccountCurrency = cmbCurrency.Text;
            tb.Notes = txtRemarks.Text;
            tb.Status = cmbStatus.Text;

            db.tbl_AccountMaster.Add(tb);
            db.SaveChanges();
            db.SaveChanges();
            MessageBox.Show("Successfully Added", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshGrid();
            ClearField();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            decimal idd = decimal.Parse(txtID.Text.ToString());
            var tb = db.tbl_AccountMaster.Where(x => x.Id == idd).FirstOrDefault();
            tb.AccountNumber = txtAccountNo.Text;
            DateTime dttransactiondate = DateTime.Parse(dtpTranactionDate.Value.ToString());
            tb.Date = dttransactiondate;
            tb.Accounttype = cmbAccounttype.Text;
            tb.AccountName = txtAccountName.Text;
            tb.SubAccountof = txtSubAccount.Text;
            tb.AccountRules = txtAccountRules.Text;
            tb.AccountCurrency = cmbCurrency.Text;
            tb.Notes = txtRemarks.Text;
            tb.Status = cmbStatus.Text;

            db.tbl_AccountMaster.Add(tb);
            db.SaveChanges();
            db.SaveChanges();
            MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshGrid();
            ClearField();
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
                Inventory_DBEntities db = new Inventory_DBEntities();
                decimal idd = decimal.Parse(txtID.Text.ToString());
                var tb = db.tbl_AccountMaster.Where(x => x.Id == idd).FirstOrDefault();
                db.tbl_AccountMaster.Remove(tb);
                db.SaveChanges();


                MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
                ClearField();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBox2.Text == "AccountNumber")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tbl_AccountMaster.Where(x => x.AccountNumber == txtSearch.Text).ToList();
                    dataGridView1.DataSource = tb1;
                    dataGridView1.Columns[0].Width = 0;
                }
                else if (comboBox2.Text == "Type")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tbl_AccountMaster.Where(x => x.Accounttype == txtSearch.Text).ToList();
                    dataGridView1.DataSource = tb1;
                    dataGridView1.Columns[0].Width = 0;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Some error Occured ! Pls try again");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    txtID.Text = dr.Cells[0].Value.ToString();

                    txtAccountNo.Text = dr.Cells[1].Value.ToString();
                    dtpTranactionDate.Text = dr.Cells[2].Value.ToString();
                    cmbAccounttype.Text = dr.Cells[3].Value.ToString();
                    txtAccountName.Text = dr.Cells[4].Value.ToString();
                    txtSubAccount.Text = dr.Cells[5].Value.ToString();
                    txtAccountRules.Text = dr.Cells[6].Value.ToString();
                    cmbCurrency.Text = dr.Cells[7].Value.ToString();
                    txtRemarks.Text = dr.Cells[8].Value.ToString();
                    cmbStatus.Text = dr.Cells[9].Value.ToString();                   


                }
            }
            catch
            {

            }
        }

        private void panel46_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel46_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }
        }

        private void panel46_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
