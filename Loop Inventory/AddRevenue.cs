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
    public partial class AddRevenue : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public AddRevenue()
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

        private void AddRevenue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }

        private void panel24_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void panel24_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void panel24_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void AddRevenue_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tbl_Currency' table. You can move, or remove it, as needed.
            this.tbl_CurrencyTableAdapter.Fill(this.dataSet1.tbl_Currency);
            this.ActiveControl = cmbCurrencyType;
            cmbCurrencyType.Focus();
        }

        private void add1_Click(object sender, EventArgs e)
        {
            Currency_Master ss = new Currency_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }
        public void ClearField()
        {

            txtRevenueNumber.Text = "";
            txtRevenueNumber2.Text = "";
            dateTimePicker1.Value = System.DateTime.Now;
            cmbCurrencyType.SelectedIndex = 0;
            txtRevenuName.Text = "";
            txtTotalBeforeTax.Text = "";
            TxtAmount.Text = "";
            cmbPaymentMethod.SelectedIndex = 0;
            txtTax.Text = "";
            txtTotal.Text = "";
            TxtNotes.Text = "";



          


            refreshGrid();
        }
        public void refreshGrid()
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            var tb = db.tbl_AddRevenue.ToList();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].Width = 0;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRevenuName.Text != "")
            {


                Inventory_DBEntities db = new Inventory_DBEntities();
                tbl_AddRevenue tb = new tbl_AddRevenue();

                if(txtRevenueNumber.Text!="")
                {
                    decimal revenuenumber = decimal.Parse(txtRevenueNumber.Text);
                    tb.RevenueNumber = revenuenumber;

                }

                if (txtRevenueNumber2.Text != "")
                {
                    decimal revenuenumber2 = decimal.Parse(txtRevenueNumber2.Text);
                    tb.RevenueNumber2 = revenuenumber2;
                }
                tb.Date = dateTimePicker1.Text;
                tb.CurrencyType = cmbCurrencyType.Text;
                tb.RevenueName = txtRevenuName.Text;
                if(txtTotalBeforeTax.Text!="")
                {
                    decimal totalb = decimal.Parse(txtTotalBeforeTax.Text);
                    tb.TotalBeforeTax = totalb; 

                }
                if(TxtAmount.Text!="")
                {
                    decimal amount = decimal.Parse(TxtAmount.Text);
                    tb.Amount = amount;

                }
                tb.PaymentMethods = cmbPaymentMethod.Text;
                if(txtTax.Text!="")
                {
                    decimal taxes = decimal.Parse(txtTax.Text);
                    tb.Taxes = taxes;

                }
                if(txtTotal.Text!="")
                {
                    decimal total = decimal.Parse(txtTotal.Text);//.te)
                    tb.Total = total;

                }
                tb.Notes = TxtNotes.Text;
                db.tbl_AddRevenue.Add(tb);
                db.SaveChanges();

                MessageBox.Show("Successfully Added", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
                ClearField();





            }
            }

        private void btnSaveandPrint_Click(object sender, EventArgs e)
        {
            if (txtRevenuName.Text != "")
            {


                Inventory_DBEntities db = new Inventory_DBEntities();
                decimal idd = decimal.Parse(txtid.Text);
                var tb = db.tbl_AddRevenue.Where(x => x.id == idd).FirstOrDefault();

                if (txtRevenueNumber.Text != "")
                {
                    decimal revenuenumber = decimal.Parse(txtRevenueNumber.Text);
                    tb.RevenueNumber = revenuenumber;

                }

                if (txtRevenueNumber2.Text != "")
                {
                    decimal revenuenumber2 = decimal.Parse(txtRevenueNumber2.Text);
                    tb.RevenueNumber2 = revenuenumber2;
                }
                tb.Date = dateTimePicker1.Text;
                tb.CurrencyType = cmbCurrencyType.Text;
                tb.RevenueName = txtRevenuName.Text;
                if (txtTotalBeforeTax.Text != "")
                {
                    decimal totalb = decimal.Parse(txtTotalBeforeTax.Text);
                    tb.TotalBeforeTax = totalb;

                }
                if (TxtAmount.Text != "")
                {
                    decimal amount = decimal.Parse(TxtAmount.Text);
                    tb.Amount = amount;

                }
                tb.PaymentMethods = cmbPaymentMethod.Text;
                if (txtTax.Text != "")
                {
                    decimal taxes = decimal.Parse(txtTax.Text);
                    tb.Taxes = taxes;

                }
                if (txtTotal.Text != "")
                {
                    decimal total = decimal.Parse(txtTotal.Text);//.te)
                    tb.Total = total;

                }
                tb.Notes = TxtNotes.Text;
                db.SaveChanges();

                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
                ClearField();



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
                Inventory_DBEntities db = new Inventory_DBEntities();
                decimal idd = decimal.Parse(txtid.Text);
                var tb = db.tbl_AddRevenue.Where(x => x.id == idd).FirstOrDefault();
                db.tbl_AddRevenue.Remove(tb);
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

        private void btn_serach_Click(object sender, EventArgs e)
        {
            try
            {

                if (combo_search_type.Text == "Number")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    if(txtRevenueNumber.Text=="")
                    {
                        return;
                    }
                    decimal revenumbernumber = decimal.Parse(txtRevenueNumber.Text);
                    var tb1 = db.tbl_AddRevenue.Where(x => x.RevenueNumber == revenumbernumber).ToList();
                    dataGridView1.DataSource = tb1;
                    dataGridView1.Columns[0].Width = 0;
                }
                else if (combo_search_type.Text == "Name")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    if (txtRevenuName.Text == "")
                    {
                        return;
                    }
                    
                    var tb1 = db.tbl_AddRevenue.Where(x => x.RevenueName == txtRevenuName.Text).ToList();
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
                    txtid.Text = dr.Cells[0].Value.ToString();
                    txtRevenueNumber.Text = dr.Cells[1].Value.ToString();
                    txtRevenueNumber2.Text = dr.Cells[2].Value.ToString();
                    dateTimePicker1.Text = dr.Cells[3].Value.ToString();
                    cmbCurrencyType.Text = dr.Cells[4].Value.ToString();
                    txtRevenuName.Text = dr.Cells[5].Value.ToString();
                    txtTotalBeforeTax.Text = dr.Cells[6].Value.ToString();
                    TxtAmount.Text = dr.Cells[7].Value.ToString();
                    cmbPaymentMethod.Text = dr.Cells[8].Value.ToString();
                    txtTax.Text = dr.Cells[9].Value.ToString();
                    TxtNotes.Text = dr.Cells[10].Value.ToString();

                }
            }
            catch
            {

            }
        }
    }
}
