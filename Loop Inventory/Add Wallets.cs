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
    public partial class Add_Wallets : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Add_Wallets()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Wallets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


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

        private void Add_Wallets_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tbl_Currency' table. You can move, or remove it, as needed.
            this.tbl_CurrencyTableAdapter.Fill(this.dataSet1.tbl_Currency);
            // TODO: This line of code loads data into the 'dataSet1.tbl_AccountMaster' table. You can move, or remove it, as needed.
            this.tbl_AccountMasterTableAdapter.Fill(this.dataSet1.tbl_AccountMaster);
            this.ActiveControl = cmbAccountType;
            cmbAccountType.Focus();
        }

        private void add1_Click(object sender, EventArgs e)
        {
            Account_Master ss = new Account_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void add2_Click(object sender, EventArgs e)
        {
            Currency_Master ss = new Currency_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        public void ClearField()
        {
            txtid.Text = "";
            txtWalletNumber.Text = "";
            dateTimePicker1.Value = System.DateTime.Now;
            cmbAccountType.SelectedIndex = 0;
            cmbCurrencyType.SelectedIndex = 0;
            txtWalletName.Text = "";
            TxtOpeningBalance.Text = "";
            
            cmbStatus.SelectedIndex = 0;


            refreshGrid();
        }
        public void refreshGrid()
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            var tb = db.tbl_AddWallet.ToList();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].Width = 0;


        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearField();
            refreshGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtWalletName.Text != "")
            {


                Inventory_DBEntities db = new Inventory_DBEntities();
                tbl_AddWallet tb = new tbl_AddWallet();

                Random rr = new Random();
                int bankno = rr.Next(100, 900);
                tb.WelletNumber = bankno;

                tb.Date = dateTimePicker1.Text;
                tb.AccountType = cmbAccountType.Text;
                tb.CurrencyType = cmbCurrencyType.Text;
                tb.WalletName = txtWalletName.Text;
                if(TxtOpeningBalance.Text!="")
                {
                    decimal opening = decimal.Parse(TxtOpeningBalance.Text);
                    tb.OpeningBalance = opening;

                }
                tb.Status = cmbStatus.Text;
                db.tbl_AddWallet.Add(tb);
                db.SaveChanges();
                MessageBox.Show("Successfully Added", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
                ClearField();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtWalletName.Text != "")
            {


                Inventory_DBEntities db = new Inventory_DBEntities();
                decimal idd = decimal.Parse(txtid.Text);
                var tb = db.tbl_AddWallet.Where(x => x.id == idd).FirstOrDefault();

                tb.Date = dateTimePicker1.Text;
                tb.AccountType = cmbAccountType.Text;
                tb.CurrencyType = cmbCurrencyType.Text;
                tb.WalletName = txtWalletName.Text;
                if (TxtOpeningBalance.Text != "")
                {
                    decimal opening = decimal.Parse(TxtOpeningBalance.Text);
                    tb.OpeningBalance = opening;

                }
                tb.Status = cmbStatus.Text;
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
                var tb = db.tbl_AddWallet.Where(x => x.id == idd).FirstOrDefault();
                db.tbl_AddWallet.Remove(tb);
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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (combo_search_type.Text == "Wallet Name")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tbl_AddWallet.Where(x => x.WalletName == txt_search.Text).ToList();
                    dataGridView1.DataSource = tb1;
                    dataGridView1.Columns[0].Width = 0;
                }
                else if (combo_search_type.Text == "Wallet Number")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    decimal number = decimal.Parse(txt_search.Text);
                    var tb1 = db.tbl_AddWallet.Where(x => x.WelletNumber == number).ToList();
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
                    txtWalletNumber.Text = dr.Cells[1].Value.ToString();
                    dateTimePicker1.Text = dr.Cells[2].Value.ToString();
                    cmbAccountType.Text = dr.Cells[3].Value.ToString();
                    cmbCurrencyType.Text = dr.Cells[4].Value.ToString();
                    txtWalletName.Text = dr.Cells[5].Value.ToString();
                    TxtOpeningBalance.Text = dr.Cells[6].Value.ToString();
                    cmbStatus.Text = dr.Cells[7].Value.ToString();


                }
            }
            catch
            {

            }
        }
    }
}
