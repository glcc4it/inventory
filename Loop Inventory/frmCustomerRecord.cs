using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loop_Inventory
{
    public partial class frmCustomerRecord : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public frmCustomerRecord()
        {
            InitializeComponent();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frmCustomerRecord_Load(object sender, EventArgs e)
        {
            
        }

        private void btnaddsupplier_Click(object sender, EventArgs e)
        {

        }

        private void dgw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgw.SelectedRows[0];
                this.Hide();
                Saleproduct frmsale = new Saleproduct();
                // or simply use column name instead of index
                // dr.Cells["id"].Value.ToString();
                if (lblSet.Text == "Sale")
                    frmsale.Show();
                frmsale.txtCus_ID.Text = dr.Cells[0].Value.ToString();
                frmsale.txtCustomerID.Text = dr.Cells[1].Value.ToString();
                frmsale.txtCustomerName.Text = dr.Cells[3].Value.ToString();
                frmsale.txt_cus_mob.Text = dr.Cells[9].Value.ToString();
                frmsale.GetSupplierBalance();



               





            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void panel32_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void panel32_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void panel32_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
