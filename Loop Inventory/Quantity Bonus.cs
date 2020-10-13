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
    public partial class Quantity_Bonus : Form
    {
        public Quantity_Bonus()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void refreshGrid()
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            var tb = db.tblBonusQuantities.ToList();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].Width = 0;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            tblBonusQuantity tb = new tblBonusQuantity();
            tb.Barcode = txtBarcode.Text;
            tb.ItemName = txtProductname.Text;
            decimal bonus = decimal.Parse(txtBonus.Text.ToString());
            tb.Bonus = bonus;
            decimal offer = decimal.Parse(txtOfferQty.Text.ToString());

            tb.OfferQuantity = offer;
            tb.TypeOfUnit = cmbUserType.Text;
            DateTime dtfrom = DateTime.Parse(dateTimePicker1.Text);
            tb.FromDate = dtfrom;
            DateTime dtTo = DateTime.Parse(dateTimePicker2.Text);
            tb.ToDate = dtTo;
            db.tblBonusQuantities.Add(tb);
            db.SaveChanges();
            MessageBox.Show("Successfully Added", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            decimal idd = decimal.Parse(txtID.Text.ToString());
            var tb = db.tblBonusQuantities.Where(x => x.ID == idd).FirstOrDefault();
            tb.Barcode = txtBarcode.Text;
            tb.ItemName = txtProductname.Text;
            decimal bonus = decimal.Parse(txtBonus.Text.ToString());
            tb.Bonus = bonus;
            decimal offer = decimal.Parse(txtOfferQty.Text.ToString());

            tb.OfferQuantity = offer;
            tb.TypeOfUnit = cmbUserType.Text;
            DateTime dtfrom = DateTime.Parse(dateTimePicker1.Text);
            tb.FromDate = dtfrom;
            DateTime dtTo = DateTime.Parse(dateTimePicker2.Text);
            tb.FromDate = dtfrom;
            db.SaveChanges();
            MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshGrid();
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
                var xx = db.tblBonusQuantities.Where(x => x.ID == idd).FirstOrDefault();
                db.tblBonusQuantities.Remove(xx);
                db.SaveChanges();


                MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Quantity_Bonus_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {

                if (combo_search_type.Text == "Barcode")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tblBonusQuantities.Where(x=>x.Barcode==txt_search.Text).ToList();
                    dataGridView1.DataSource = tb1;
                    dataGridView1.Columns[0].Width = 0;
                }
            else if(combo_search_type.Text == "Barcode")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tblBonusQuantities.Where(x => x.ItemName == txt_search.Text).ToList();
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

                    txtBarcode.Text = dr.Cells[1].Value.ToString();
                    txtProductname.Text = dr.Cells[2].Value.ToString();
                    cmbUserType.Text = dr.Cells[3].Value.ToString();
                    dateTimePicker1.Text= dr.Cells[4].Value.ToString();
                    dateTimePicker2.Text = dr.Cells[5].Value.ToString();
                    txtOfferQty.Text= dr.Cells[6].Value.ToString();
                    txtBonus.Text= dr.Cells[7].Value.ToString();
                }
            }
            catch
            {

            }

        }
    }
}
