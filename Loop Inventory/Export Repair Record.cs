using DGVPrinterHelper;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Loop_Inventory
{
    public partial class Export_Repair_Record : Form
    {
        public Export_Repair_Record()
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

        private void Export_Repair_Record_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_repair_order' table. You can move, or remove it, as needed.
            this.tbl_repair_orderTableAdapter.Fill(this.inventory_DBDataSet.tbl_repair_order);
            
            
            
           
            


            Cmb_field.SelectedIndex = 0;


            this.ActiveControl = txt_search;
            txt_search.Focus();

        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();




            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = advancedDataGridView1.RowCount - 1;
                colsTotal = advancedDataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = advancedDataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = advancedDataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.tblrepairorderBindingSource.Sort = this.advancedDataGridView1.SortString;
        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.tblrepairorderBindingSource.Filter = this.advancedDataGridView1.FilterString;
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (Cmb_field.Text == "Jobno")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Servicesid,Job_no,Invoicedate,cus_name,cus_number,Mobile_brand,Mobile_model,Mobile_fault,Other_fault,worker,Estimate,mobile_acccess,Reciveid_by,Description,Market,Out_date,Status,Total_payment,Advance,Balance FROM tbl_repair_order where Job_no like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                advancedDataGridView1.DataSource = dt;


            }


            if (Cmb_field.Text == "CustomerName")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Servicesid,Job_no,Invoicedate,cus_name,cus_number,Mobile_brand,Mobile_model,Mobile_fault,Other_fault,worker,Estimate,mobile_acccess,Reciveid_by,Description,Market,Out_date,Status,Total_payment,Advance,Balance FROM tbl_repair_order where cus_name like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                advancedDataGridView1.DataSource = dt;


            }


            if (Cmb_field.Text == "Mobile")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Servicesid,Job_no,Invoicedate,cus_name,cus_number,Mobile_brand,Mobile_model,Mobile_fault,Other_fault,worker,Estimate,mobile_acccess,Reciveid_by,Description,Market,Out_date,Status,Total_payment,Advance,Balance FROM tbl_repair_order where cus_number like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                advancedDataGridView1.DataSource = dt;


            }

            if (Cmb_field.Text == "Model")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Servicesid,Job_no,Invoicedate,cus_name,cus_number,Mobile_brand,Mobile_model,Mobile_fault,Other_fault,worker,Estimate,mobile_acccess,Reciveid_by,Description,Market,Out_date,Status,Total_payment,Advance,Balance FROM tbl_repair_order where Mobile_model like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                advancedDataGridView1.DataSource = dt;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Repair Order Records";
            printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Developed By Glcc4it Solutions";
            printer.FooterSpacing = 5;

            printer.PrintDataGridView(advancedDataGridView1);
        }
    }
}
