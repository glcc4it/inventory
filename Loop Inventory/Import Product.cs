using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace Loop_Inventory
{
    public partial class Import_Product : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SERVER;Initial Catalog=Inventory_DB;Integrated Security=True;MultipleActiveResultSets=True;");
        SqlCommand cmd;
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Import_Product()
        {
            InitializeComponent();
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

        private void Import_Product_Load(object sender, EventArgs e)
        {
            

        }


        private void loadExcelToDataGrid(string strFilePath)
        {
            string sheet = "Sheet1";
            String strConnectionString = @"Data Source=" + strFilePath + "; Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Excel 12.0;";
            OleDbConnection con = new OleDbConnection(strConnectionString);
            con.Open();
            OleDbCommand cmdSelect = new OleDbCommand(@"SELECT * FROM [" + sheet + "$]", con);
            OleDbDataAdapter daCSV = new OleDbDataAdapter();
            daCSV.SelectCommand = cmdSelect;
            DataSet ds = new DataSet();
            daCSV.Fill(ds);
            dgvExcelData.DataSource = ds.Tables[0];
            con.Close();
        }


        private void btnGetData_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
                loadExcelToDataGrid(ofd.FileName);
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btngetrecord_Click(object sender, EventArgs e)
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

                rowsTotal = dgvExcelData.RowCount - 1;
                colsTotal = dgvExcelData.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dgvExcelData.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dgvExcelData.Rows[I].Cells[j].Value;
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

        private void btnSave_Click(object sender, EventArgs e)
        {




            for (int i = 0; i < dgvExcelData.Rows.Count - 1; i++)
            {

                cmd = new SqlCommand(@"Insert into tbl_stock_product VALUES('" + dgvExcelData.Rows[i].Cells[0].Value + "', '" + dgvExcelData.Rows[i].Cells[1].Value + "', '" + dgvExcelData.Rows[i].Cells[2].Value + "', '" + dgvExcelData.Rows[i].Cells[3].Value + "', '" + dgvExcelData.Rows[i].Cells[4].Value + "', '" + dgvExcelData.Rows[i].Cells[5].Value + "', '" + dgvExcelData.Rows[i].Cells[6].Value + "', '" + dgvExcelData.Rows[i].Cells[7].Value + "', '" + dgvExcelData.Rows[i].Cells[8].Value + "', '" + dgvExcelData.Rows[i].Cells[9].Value + "', '" + dgvExcelData.Rows[i].Cells[10].Value + "', '" + dgvExcelData.Rows[i].Cells[11].Value + "', '" + dgvExcelData.Rows[i].Cells[12].Value + "', '" + dgvExcelData.Rows[i].Cells[13].Value + "', '" + dgvExcelData.Rows[i].Cells[14].Value + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();




                cmd = new SqlCommand(@"Insert into Temp_Stock VALUES('" + dgvExcelData.Rows[i].Cells[0].Value + "', '" + dgvExcelData.Rows[i].Cells[1].Value + "', '" + dgvExcelData.Rows[i].Cells[2].Value + "', '" + dgvExcelData.Rows[i].Cells[3].Value + "', '" + dgvExcelData.Rows[i].Cells[4].Value + "', '" + dgvExcelData.Rows[i].Cells[5].Value + "', '" + dgvExcelData.Rows[i].Cells[6].Value + "', '" + dgvExcelData.Rows[i].Cells[7].Value + "', '" + dgvExcelData.Rows[i].Cells[8].Value + "', '" + dgvExcelData.Rows[i].Cells[9].Value + "', '" + dgvExcelData.Rows[i].Cells[10].Value + "', '" + dgvExcelData.Rows[i].Cells[12].Value + "', '" + dgvExcelData.Rows[i].Cells[13].Value + "', '" + dgvExcelData.Rows[i].Cells[14].Value + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();




            }


        }
            
       }
        
    }

        
  

