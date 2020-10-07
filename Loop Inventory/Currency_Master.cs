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
    public partial class Currency_Master : Form
    {
        public Currency_Master()
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
        public void refreshGrid()
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            var tb = db.tbl_Currency.ToList();
            dgw.DataSource = tb;
            dgw.Columns[0].Width = 0;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            tbl_Currency tb = new tbl_Currency();
            tb.Name = txt_cur_name.Text;
            decimal valuee = decimal.Parse(txt_cur_rate.Text.ToString());
            tb.value = valuee;
            tb.Status = combo_status.Text;
            db.tbl_Currency.Add(tb);
            db.SaveChanges();
            MessageBox.Show("Successfully Added", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            refreshGrid();
        }

        private void dgw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgw.Rows.Count > 0)
                {
                    DataGridViewRow dr = dgw.SelectedRows[0];
                    txtID.Text = dr.Cells[0].Value.ToString();
                    txt_cur_name.Text = dr.Cells[1].Value.ToString();
                    txt_cur_rate.Text = dr.Cells[2].Value.ToString();
                    combo_status.Text = dr.Cells[3].Value.ToString();



                }
            }
            catch
            {

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
                int idd = int.Parse(txtID.Text.ToString());
                var xx = db.tbl_Currency.Where(x => x.ID == idd).FirstOrDefault();
                db.tbl_Currency.Remove(xx);
                db.SaveChanges();


                MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            int idd = int.Parse(txtID.Text.ToString());

            var tb = db.tbl_Currency.Where(x => x.ID == idd).FirstOrDefault();

            tb.Name = txt_cur_name.Text;
            decimal valuee = decimal.Parse(txt_cur_rate.Text.ToString());
            tb.value = valuee;
            tb.Status = combo_status.Text;

            db.SaveChanges();
            MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            refreshGrid();
        }

        private void Tax_Master_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void Currency_Master_Load(object sender, EventArgs e)
        {
            refreshGrid();

        }
    }
}
