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
    public partial class Supplier_Master : Form
    {
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
            txtDefulttransaction.Text = "";
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

                    tb.CreditLimit =credit;
                }
                tb.AccountName = txtAccountName.Text;
                tb.Branch = txtBranch.Text;
                tb.AccountNumber = txtAccountNo.Text;
                tb.DefultTransaction = txtDefulttransaction.Text;
                tb.Status = cmbStatus.Text;
                db.Suppliers.Add(tb);
                db.SaveChanges();
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
                tb.DefultTransaction = txtDefulttransaction.Text;
                tb.Status = cmbStatus.Text;
                db.Suppliers.Add(tb);
                db.SaveChanges();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
                ClearField();
            }

            }

        private void Supplier_Master_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.tbl_Currency' table. You can move, or remove it, as needed.
            this.tbl_CurrencyTableAdapter.Fill(this.dataSet1.tbl_Currency);
            // TODO: This line of code loads data into the 'dataSet1.tbl_AccountMaster' table. You can move, or remove it, as needed.
            this.tbl_AccountMasterTableAdapter.Fill(this.dataSet1.tbl_AccountMaster);
            refreshGrid();

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
                    txtAddress.Text= dr.Cells[7].Value.ToString();
                    txtEmailID.Text= dr.Cells[8].Value.ToString();
                    txtContactNo.Text= dr.Cells[9].Value.ToString();
                    txtCreditLimit.Text= dr.Cells[10].Value.ToString();
                    txtAccountName.Text= dr.Cells[11].Value.ToString();
                   txtBranch.Text= dr.Cells[12].Value.ToString();
                    txtAccountNo.Text= dr.Cells[13].Value.ToString();
                    txtDefulttransaction.Text= dr.Cells[14].Value.ToString();
                    cmbStatus.Text= dr.Cells[15].Value.ToString();

                }
            }
            catch
            {

            }
        }
    }
}
