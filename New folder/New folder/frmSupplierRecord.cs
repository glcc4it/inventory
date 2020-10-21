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
    public partial class frmSupplierRecord : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public frmSupplierRecord()
        {
            InitializeComponent();
        }

        private void frmSupplierRecord_Load(object sender, EventArgs e)
        {
            
           
            


            
           

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

       

        private void btnaddsupplier_Click(object sender, EventArgs e)
        {

            Supplier_Master ss = new Supplier_Master();
            ss.Show();
        }

        private void dgw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgw.SelectedRows[0];
                this.Hide();
                Purchaseproduct frmPurchase = new Purchaseproduct();

                if (lblSet.Text == "Purchase")
                  
                    frmPurchase.txt_ven_invoice.Text = ModCS.InvoiceNumber;
                    frmPurchase.Show();
                frmPurchase.txtSup_ID.Text = dr.Cells[0].Value.ToString();
                frmPurchase.txtSupplierID.Text = dr.Cells[1].Value.ToString();
                frmPurchase.txtSupplierName.Text = dr.Cells[3].Value.ToString();
                frmPurchase.txtContactNo.Text = dr.Cells[9].Value.ToString();
                frmPurchase.GetSupplierBalance();


                
               
            }




            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {

            
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
