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
    public partial class Tax_Master : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Tax_Master()
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
            var tb = db.tbl_Tax.ToList();
            dgw.DataSource = tb;
            dgw.Columns[0].Width = 0;
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            tbl_Tax tb = new tbl_Tax();
            tb.Name = txt_Tax_name.Text;
            decimal  valuee = decimal.Parse(txt_Tax_percent.Text.ToString());
            tb.value = valuee;
            tb.Status = combo_status.Text;
            db.tbl_Tax.Add(tb);
            db.SaveChanges();
            refreshGrid();
        }

        private void dgw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgw.Rows.Count > 0)
                {
                    DataGridViewRow dr = dgw.SelectedRows[0];
                    txtID.Text= dr.Cells[0].Value.ToString();
                    txt_Tax_name.Text= dr.Cells[1].Value.ToString();
                    txt_Tax_percent.Text= dr.Cells[2].Value.ToString();
                    combo_status.Text= dr.Cells[3].Value.ToString();



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
                var xx = db.tbl_Tax.Where(x => x.ID == idd).FirstOrDefault();
                db.tbl_Tax.Remove(xx);
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

            var tb = db.tbl_Tax.Where(x => x.ID == idd).FirstOrDefault();

            tb.Name = txt_Tax_name.Text;
            decimal valuee = decimal.Parse(txt_Tax_percent.Text.ToString());
            tb.value = valuee;
            tb.Status = combo_status.Text;
            
            db.SaveChanges();
            refreshGrid();
        }

        private void Tax_Master_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void Tax_Master_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }

        private void panel12_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel12_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }
        }

        private void panel12_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
