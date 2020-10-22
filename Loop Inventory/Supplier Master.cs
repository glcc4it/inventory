using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
using System.Data.SqlClient;

namespace Loop_Inventory
{
    public partial class Supplier_Master : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Supplier_Master()
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
            txtCustomerID.Text = "";
            dateTimePicker1.Text = System.DateTime.Now.ToString();
            txtSupplierName.Text = "";
            comboAccounttype.SelectedIndex = 0;// = dr.Cells[3].Value.ToString();
            comboCurrencyType.SelectedIndex = 0;// = dr.Cells[4].Value.ToString();
            txtOpeningBalance.Text = "";
            cmbOpeningBalanceType.SelectedIndex = 0;// = dr.Cells[6].Value.ToString();
            txtAddress.Text = "";
            txtEmailID.Text = "";
            txtContactNo.Text = "";
            txtCreditLimit.Text = "";
            txtAccountName.Text = "";
            txtBranch.Text = "";
            txtAccountNo.Text = "";
            cmbDefultTransaction.Text = "--- Set Transaction---";
            cmbStatus.SelectedIndex = 0; ;// = dr.Cells[15].Value.ToString();
            refreshGrid();
        }
        public void refreshGrid()
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            var tb = db.Suppliers.ToList();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].Width = 0;


        }
        public void FillOpeningBalance()
        {
            decimal debit = 0;
            decimal credit = 0;
            if(cmbOpeningBalanceType.Text=="Cr")
            {
                debit = 0;
                credit = decimal.Parse(txtOpeningBalance.Text);
            }
            if (cmbOpeningBalanceType.Text == "Dr")
            {
                credit = 0;
                debit = decimal.Parse(txtOpeningBalance.Text);
            }

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            string cb = "insert into SupplierLedgerBook(Date,Name,Label,Debit,Credit,Mobileno) VALUES ('" + dateTimePicker1.Text + "' ,'" + txtSupplierName.Text + "' , 'Opening Balance','"+ debit +"','"+ credit+"','"+ txtContactNo.Text+"')";

            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();


        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txtSupplierName.Text != "")
            {
                Inventory_DBEntities db = new Inventory_DBEntities();
                Supplier tb = new Supplier();
                tb.Date = dateTimePicker1.Value;
                tb.Name = txtSupplierName.Text;
                tb.AccountNature = comboAccounttype.Text;
                tb.CurrencyType = comboCurrencyType.Text;
                if (txtOpeningBalance.Text != "")
                {
                    decimal ob = decimal.Parse(txtOpeningBalance.Text.ToString());
                    tb.OpeningBalance = ob;
                }

                tb.OpeningBalanceType = cmbOpeningBalanceType.Text;
                tb.Address = txtAddress.Text;
                tb.EmailID = txtEmailID.Text;
                tb.Mobileno = txtContactNo.Text;
                if (txtCreditLimit.Text != "")
                {
                    decimal credit = decimal.Parse(txtCreditLimit.Text.ToString());

                    tb.CreditLimit = credit;
                }
                tb.AccountName = txtAccountName.Text;
                tb.Branch = txtBranch.Text;
                tb.AccountNumber = txtAccountNo.Text;
                tb.DefultTransaction = cmbDefultTransaction.Text;
                tb.Status = cmbStatus.Text;
                db.Suppliers.Add(tb);
                db.SaveChanges();

                FillOpeningBalance();

                MessageBox.Show("Successfully Added", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshGrid();
                ClearField();


            }


        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txtSupplierName.Text != "")
            {
                Inventory_DBEntities db = new Inventory_DBEntities();
                decimal idd = decimal.Parse(txtCustomerID.Text);
                var tb = db.Suppliers.Where(x => x.id == idd).FirstOrDefault();
                tb.Date = dateTimePicker1.Value;
                tb.Name = txtSupplierName.Text;
                tb.AccountNature = comboAccounttype.Text;
                tb.CurrencyType = comboCurrencyType.Text;
                if (txtOpeningBalance.Text != "")
                {
                    decimal ob = decimal.Parse(txtOpeningBalance.Text.ToString());
                    tb.OpeningBalance = ob;
                }

                tb.OpeningBalanceType = cmbOpeningBalanceType.Text;
                tb.Address = txtAddress.Text;
                tb.EmailID = txtEmailID.Text;
                tb.Mobileno = txtContactNo.Text;
                if (txtCreditLimit.Text != "")
                {
                    decimal credit = decimal.Parse(txtCreditLimit.Text.ToString());

                    tb.CreditLimit = credit;
                }
                tb.AccountName = txtAccountName.Text;
                tb.Branch = txtBranch.Text;
                tb.AccountNumber = txtAccountNo.Text;
                tb.DefultTransaction = cmbDefultTransaction.Text;
                tb.Status = cmbStatus.Text;
                db.Suppliers.Add(tb);
                db.SaveChanges();
                UpdateOpeningBalance();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
                ClearField();
            }

        }
        public void UpdateOpeningBalance()
        {
            decimal debit = 0;
            decimal credit = 0;
            if (cmbOpeningBalanceType.Text == "Cr")
            {
                debit = 0;
                credit = decimal.Parse(txtOpeningBalance.Text);
            }
            if (cmbOpeningBalanceType.Text == "Dr")
            {
                credit = 0;
                debit = decimal.Parse(txtOpeningBalance.Text);
            }

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            string cb = "update  CustomerLedgerBook set Date='" + dateTimePicker1.Text + "',Name='" + txtSupplierName.Text + "',Label='Opening Balance',Debit='" + debit + "',Credit='" + credit + "',Mobileno='" + txtContactNo.Text + "' where ID='" + txtCustomerID.Text + "'";

            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();


        }

        private void Supplier_Master_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tbl_Currency' table. You can move, or remove it, as needed.
            this.tbl_CurrencyTableAdapter.Fill(this.dataSet1.tbl_Currency);
            // TODO: This line of code loads data into the 'dataSet1.tbl_AccountMaster' table. You can move, or remove it, as needed.
            this.tbl_AccountMasterTableAdapter.Fill(this.dataSet1.tbl_AccountMaster);
            refreshGrid();


            this.ActiveControl = txtSupplierName;
            txtSupplierName.Focus();




        }

        private void btn_delete_Click(object sender, EventArgs e)
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
                int idd = int.Parse(txtCustomerID.Text.ToString());
                var xx = db.Suppliers.Where(x => x.id == idd).FirstOrDefault();
                db.Suppliers.Remove(xx);
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    txtCustomerID.Text = dr.Cells[0].Value.ToString();
                    dateTimePicker1.Text = dr.Cells[1].Value.ToString();
                    txtSupplierName.Text = dr.Cells[2].Value.ToString();
                    comboAccounttype.Text = dr.Cells[3].Value.ToString();
                    comboCurrencyType.Text = dr.Cells[4].Value.ToString();
                    txtOpeningBalance.Text = dr.Cells[5].Value.ToString();
                    cmbOpeningBalanceType.Text = dr.Cells[6].Value.ToString();
                    txtAddress.Text = dr.Cells[7].Value.ToString();
                    txtEmailID.Text = dr.Cells[8].Value.ToString();
                    txtContactNo.Text = dr.Cells[9].Value.ToString();
                    txtCreditLimit.Text = dr.Cells[10].Value.ToString();
                    txtAccountName.Text = dr.Cells[11].Value.ToString();
                    txtBranch.Text = dr.Cells[12].Value.ToString();
                    txtAccountNo.Text = dr.Cells[13].Value.ToString();
                    cmbDefultTransaction.Text = dr.Cells[14].Value.ToString();
                    cmbStatus.Text = dr.Cells[15].Value.ToString();

                }
            }
            catch
            {

            }
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

        private void Supplier_Master_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {

                if (combo_search_type.Text == "Name")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.Suppliers.Where(x => x.Name == txt_search.Text).ToList();
                    dataGridView1.DataSource = tb1;
                    dataGridView1.Columns[0].Width = 0;
                }
                else if (combo_search_type.Text == "Mobile")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.Suppliers.Where(x => x.Mobileno == txt_search.Text).ToList();
                    dataGridView1.DataSource = tb1;
                    dataGridView1.Columns[0].Width = 0;
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("Some error Occured ! Pls try again");
            }
        }
    }
}
