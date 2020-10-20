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
    public partial class Store_Master : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Store_Master()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ClearField()
        {
            txtName.Text = "";
            dateTimePicker1.Value = System.DateTime.Now;
            txtUserID.Text = "";
            txtAddress.Text = "";
            txtemail.Text = "";
            txtmobile.Text = "";
            cmbUserType.SelectedIndex = 0;
            refreshGrid();
        }
        public void refreshGrid()
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            var tb = db.tblStores.ToList();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].Width = 0;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtName.Text != "")
            {
                Inventory_DBEntities db = new Inventory_DBEntities();
                tblStore tb = new tblStore();
                tb.Name = txtName.Text;
                DateTime dtTo = DateTime.Parse(dateTimePicker1.Text);
                tb.DateCreated = dtTo;
                tb.Address = txtAddress.Text;
                tb.EmailAddress = txtemail.Text;
                tb.MobileNumber = txtmobile.Text;
                tb.Status = cmbUserType.Text;

                db.tblStores.Add(tb);
                db.SaveChanges();
                MessageBox.Show("Successfully Added", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
                ClearField();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                Inventory_DBEntities db = new Inventory_DBEntities();
                decimal idd = decimal.Parse(txtUserID.Text.ToString());
                var tb = db.tblStores.Where(x => x.ID == idd).FirstOrDefault();
                tb.Name = txtName.Text;
                DateTime dtTo = DateTime.Parse(dateTimePicker1.Text);
                tb.DateCreated = dtTo;
                tb.Address = txtAddress.Text;
                tb.EmailAddress = txtemail.Text;
                tb.MobileNumber = txtmobile.Text;
                tb.Status = cmbUserType.Text;
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
                int idd = int.Parse(txtUserID.Text.ToString());
                var xx = db.tblStores.Where(x => x.ID == idd).FirstOrDefault();
                db.tblStores.Remove(xx);
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

        private void Store_Master_Load(object sender, EventArgs e)
        {
            refreshGrid();

            this.ActiveControl = txtName;
            txtName.Focus();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {

                if (combo_search_type.Text == "StoreName")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tblStores.Where(x => x.Name == txt_search.Text).ToList();
                    dataGridView1.DataSource = tb1;
                    dataGridView1.Columns[0].Width = 0;
                }
                else if (combo_search_type.Text == "Mobile")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tblStores.Where(x => x.MobileNumber == txt_search.Text).ToList();
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
                    txtUserID.Text = dr.Cells[0].Value.ToString();
                    dateTimePicker1.Text = dr.Cells[1].Value.ToString();
                    txtName.Text = dr.Cells[2].Value.ToString();
                    txtAddress.Text = dr.Cells[3].Value.ToString();
                    txtemail.Text = dr.Cells[4].Value.ToString();
                    txtmobile.Text = dr.Cells[5].Value.ToString();
                    cmbUserType.Text = dr.Cells[6].Value.ToString();
                }
            }
            catch
            {

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void Store_Master_KeyDown(object sender, KeyEventArgs e)
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
    }
}
