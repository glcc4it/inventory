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
    public partial class Add_Bank : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Add_Bank()
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

        private void Add_Bank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        public void ClearField()
        {
            txtIDNo.Text = "";
            dtpTranactionDate.Value = System.DateTime.Now;
            cmbAccountType.SelectedIndex = 0;
            cmbCurrencyType.SelectedIndex = 0;
            txtBankName.Text = "";
            txtBranchName.Text = "";
            txtAddress.Text = "";
            txtPhonenumber.Text = "";
            txtEmail.Text = "";
            cmbStatus.SelectedIndex = 0;

                
            refreshGrid();
        }
        public void refreshGrid()
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            var tb = db.tblStores.ToList();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].Width = 0;


        }
        private void Add_Bank_Load(object sender, EventArgs e)
        {
            this.ActiveControl = cmbAccountType;
            cmbAccountType.Focus();
            refreshGrid();
        }

       

        private void add2_Click(object sender, EventArgs e)
        {
            Currency_Master ss = new Currency_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void add1_Click(object sender, EventArgs e)
        {
            Account_Master ss = new Account_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtBankName.Text!="")
            {

           
            Inventory_DBEntities db = new Inventory_DBEntities();
            tbl_AddBank tb = new tbl_AddBank();

                Random rr = new Random();
            int bankno= rr.Next(100, 900);
                string banknoo = bankno.ToString();
                tb.BankNo = banknoo;
            tb.Date = dtpTranactionDate.Text;
            tb.AccountType = cmbAccountType.Text;
            tb.CurrencyType = cmbCurrencyType.Text;
            tb.BankName = txtBankName.Text;
            tb.BranchName = txtBranchName.Text;
            tb.Address = txtAddress.Text;
            tb.Phone = txtPhonenumber.Text;
            tb.Email = txtEmail.Text;
            tb.Status = cmbStatus.Text;
            db.tbl_AddBank.Add(tb);
            db.SaveChanges();
            MessageBox.Show("Successfully Added", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshGrid();
            ClearField();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtBankName.Text != "")
            {


                Inventory_DBEntities db = new Inventory_DBEntities();
                decimal idd = decimal.Parse(txtIDNo.Text);
                var tb = db.tbl_AddBank.Where(x => x.id == idd).FirstOrDefault();

                tb.Date = dtpTranactionDate.Text;
                tb.AccountType = cmbAccountType.Text;
                tb.CurrencyType = cmbCurrencyType.Text;
                tb.BankName = txtBankName.Text;
                tb.BranchName = txtBranchName.Text;
                tb.Address = txtAddress.Text;
                tb.Phone = txtPhonenumber.Text;
                tb.Email = txtEmail.Text;
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
                decimal idd = decimal.Parse(txtIDNo.Text);
                var tb = db.tbl_AddBank.Where(x => x.id == idd).FirstOrDefault();
                db.tbl_AddBank.Remove(tb);
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

        private void lnk_sale_rpt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearField();
            refreshGrid();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    txtIDNo.Text = dr.Cells[0].Value.ToString();
                    txtbankno.Text = dr.Cells[1].Value.ToString();
                    dtpTranactionDate.Text = dr.Cells[2].Value.ToString();
                    cmbAccountType.Text= dr.Cells[3].Value.ToString();
                  cmbCurrencyType.Text = dr.Cells[4].Value.ToString();
                  txtBankName.Text = dr.Cells[5].Value.ToString();
                   txtBranchName.Text = dr.Cells[6].Value.ToString();
                    txtAddress.Text = dr.Cells[7].Value.ToString();
                    txtPhonenumber.Text = dr.Cells[8].Value.ToString();
                    txtEmail.Text = dr.Cells[9].Value.ToString();
                  cmbStatus.Text = dr.Cells[10].Value.ToString();

                }
            }
            catch
            {

            }
        }
    }
}
