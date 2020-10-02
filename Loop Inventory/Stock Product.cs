using DGVPrinterHelper;
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
    public partial class Stock_Product : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

       
        public Stock_Product()
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

        private void Stock_Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.Temp_Stock' table. You can move, or remove it, as needed.
            this.temp_StockTableAdapter.Fill(this.inventory_DBDataSet.Temp_Stock);


            Cmb_field.SelectedIndex = 0;

            this.ActiveControl = txt_search;
            txt_search.Focus();

           

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Stock Product Records";
            printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Developed By Glcc4it Solutions";
            printer.FooterSpacing = 5;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dgw);
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (Cmb_field.Text == "ProductName")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Category,Product,Typeofunit,Description,Rackno,Godown,Quantity,Mfd,Expdate FROM Temp_Stock where Product like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;
                

            }

            if (Cmb_field.Text == "Category")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Category,Product,Typeofunit,Description,Rackno,Godown,Quantity,Mfd,Expdate FROM Temp_Stock where Category like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.DataSource = dt;
               

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

        private void btngetrecord_Click(object sender, EventArgs e)
        {

        }

        

        
    }
}
