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
    public partial class Add_Expense : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Add_Expense()
        {
            InitializeComponent();
        }
        private void DisplayData()
        {
            Inventory_DBEntities db = new Inventory_DBEntities();

            var dt = db.tbl_AddExpenses.ToList();
            dataGridView1.DataSource = dt;
        }
        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Expense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


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



        private void add2_Click(object sender, EventArgs e)
        {
            Currency_Master ss = new Currency_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void add1_Click(object sender, EventArgs e)
        {
            Expense_Master ss = new Expense_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            tbl_AddExpenses tb = new tbl_AddExpenses();
            tb.Date = dateTimePicker1.Text;
            if (txtInvoiceno.Text != "")
            {
                decimal invoice = decimal.Parse(txtInvoiceno.Text);
                tb.InvoiceNumber = invoice;

            }
            tb.ExpenseType = cmbExpenseType.Text;
            tb.ExpensesName = txtExpenseName.Text;
            tb.CurrencyType = cmbCurrencyType.Text;
            tb.TransactionType = cmbTransactionType.Text;
            if (txtAmount.Text != "")
            {
                decimal amount = decimal.Parse(txtAmount.Text);
                tb.Amount = amount;


            }
            tb.Notes = txtNotes.Text;
            tb.PaymentMethods = cmbPaymentMethod.Text;
            if (txtTax.Text != "")
            {
                decimal tax = decimal.Parse(txtTax.Text);
                tb.TaxAmount = tax;
            }
            if (txtTotal.Text != "")
            {
                decimal total = decimal.Parse(txtTotal.Text);
                tb.TotalAmount = total;
            }
            db.tbl_AddExpenses.Add(tb);
            db.SaveChanges();

            MessageBox.Show("Successfully Added", "Expense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ModFunc.LogFunc(lblUser.Text, "Added the Expense With total Amount  with ID :  '" + txtTotal.Text + "' info");
            DisplayData();
            ClearData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Inventory_DBEntities db = new Inventory_DBEntities();

            decimal idd = decimal.Parse(txtExpenseNumber.Text);
            var tb = db.tbl_AddExpenses.Where(x => x.id == idd).FirstOrDefault();
            tb.Date = dateTimePicker1.Text;
            if (txtInvoiceno.Text != "")
            {
                decimal invoice = decimal.Parse(txtInvoiceno.Text);
                tb.InvoiceNumber = invoice;

            }
            tb.ExpenseType = cmbExpenseType.Text;
            tb.ExpensesName = txtExpenseName.Text;
            tb.CurrencyType = cmbCurrencyType.Text;
            tb.TransactionType = cmbTransactionType.Text;
            if (txtAmount.Text != "")
            {
                decimal amount = decimal.Parse(txtAmount.Text);
                tb.Amount = amount;


            }
            tb.Notes = txtNotes.Text;
            tb.PaymentMethods = cmbPaymentMethod.Text;
            if (txtTax.Text != "")
            {
                decimal tax = decimal.Parse(txtTax.Text);
                tb.TaxAmount = tax;
            }
            if (txtTotal.Text != "")
            {
                decimal total = decimal.Parse(txtTotal.Text);
                tb.TotalAmount = total;
            }

            db.SaveChanges();

            MessageBox.Show("Successfully Updated", "Expense", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ModFunc.LogFunc(lblUser.Text, "Updated the Expense With  ID :  '" + txtExpenseNumber.Text + "");
            DisplayData();
            ClearData();
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

                decimal idd = decimal.Parse(txtExpenseNumber.Text);
                var tb = db.tbl_AddExpenses.Where(x => x.id == idd).FirstOrDefault();
                db.tbl_AddExpenses.Remove(tb);
                db.SaveChanges();

                MessageBox.Show("Successfully Delete", "Expense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Delted the Expense With  ID :  '" + txtExpenseNumber.Text + "");
                DisplayData();
                ClearData();
            }
            catch (Exception ex)
            {

            }
        }

        private void Add_Expense_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
       public void ClearData()
        {
            txtExpenseNumber.Text = "";

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {

                if (combo_search_type.Text == "Name")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tbl_AddExpenses.Where(x => x.ExpensesName == textBox10.Text).ToList();
                    dataGridView1.DataSource = tb1;
                    dataGridView1.Columns[0].Width = 0;
                }
                else if (combo_search_type.Text == "Mobile")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tblStores.Where(x => x.MobileNumber == textBox10.Text).ToList();
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
                    txtExpenseNumber.Text = dr.Cells[0].Value.ToString();
                    dateTimePicker1.Text = dr.Cells[1].Value.ToString();
                    txtInvoiceno.Text = dr.Cells[2].Value.ToString();
                    cmbExpenseType.Text = dr.Cells[3].Value.ToString();
                    txtExpenseName.Text= dr.Cells[4].Value.ToString();
                    cmbCurrencyType.Text= dr.Cells[5].Value.ToString();
                    cmbTransactionType.Text= dr.Cells[6].Value.ToString();
                    txtAmount.Text= dr.Cells[7].Value.ToString();
                    txtNotes.Text= dr.Cells[8].Value.ToString();
                    cmbPaymentMethod.Text= dr.Cells[9].Value.ToString();
                    txtTax.Text= dr.Cells[10].Value.ToString();
                    txtTotal.Text= dr.Cells[11].Value.ToString();
                }
            }
            catch
            {

            }
        }
    }
}
