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
    public partial class ProductMaster : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SERVER;Initial Catalog=Inventory_DB;Integrated Security=True;MultipleActiveResultSets=True;");
        SqlCommand cmd;
        bool drag = false;
        Point start_point = new Point(0, 0);
        string proid = "Pro-";


        public ProductMaster()
        {
            InitializeComponent();
        }


        public void procode()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            SqlCommand cmd = new SqlCommand("select Count(Code) from tblItemMaster", ModCommonClasses.con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            ModCommonClasses.con.Close();
            i++;
            txt_Productcode.Text = proid + i.ToString();

        }


        public void barcodenumber()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = new SqlCommand("select max (Barcode1)+1 from tblItemMaster", ModCommonClasses.con);
            SqlDataReader dr = ModCommonClasses.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txt_Barcode1.Text = dr[0].ToString();
                    if (txt_Barcode1.Text == "")
                    {
                        txt_Barcode1.Text = "10000001";

                    }

                }

            }
            else
            {
                txt_Barcode1.Text = "10000001";
            }

            ModCommonClasses.con.Close();
        }


        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ClearField()
        {
            txt_Barcode1.Text = "";
            txt_Barcode2.Text = "";
            txt_Productcode.Text = "";
            txt_ProductnameArabic.Text = "";
            txt_ProductnameEng.Text = "";
            combo_Store.SelectedIndex = 0;// = "";
            combo_Brand.SelectedIndex = 0;// ;
            combo_Category.SelectedIndex = 0;// ;
            combo_Unit.SelectedIndex = 0;// ;
            combo_Color.SelectedIndex = 0;// ;
            txt_Description.Text = "";
            txt_QtyPerUnit.Text = "";
            txt_CompanyProduct.Text = "";
            txt_PreferredVender.Text = "";
            combo_DiscountType.SelectedIndex = 0;//= "";
            txt_DirectDiscount.Text = "";
            txt_NextShoppingDiscount.Text = "";
            combo_TaxType.Text = "";
            txt_ReorderLevel.Text = "";
            dateTimePicker2.Value = System.DateTime.Now;
            dateTimePicker1.Value = System.DateTime.Now;// "";
            combo_PurchaseCurency.SelectedIndex = 0;// ;
            combo_SellingCurrency.SelectedIndex = 0;// ;
            txt_WholeSalePrice.Text = "";
            txt_PurchasePrice.Text = "";
            txt_CustomerPrice.Text = "";
            txt_RetailPrice.Text = "";
            txt_AddProfit.Text = "";
            combo_Status.SelectedIndex = 0;// ;
            refreshGrid();
        }

        public void refreshGrid()
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            var tb = db.tblItemMasters.ToList();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].Width = 0;


        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Inventory_DBEntities db = new Inventory_DBEntities();
            tblItemMaster tb = new tblItemMaster();
            tb.Barcode1 = txt_Barcode1.Text;
            tb.Barcode2 = txt_Barcode2.Text;
            tb.Code = txt_Productcode.Text;
            tb.NameArabic = txt_ProductnameArabic.Text;
            tb.NameEng = txt_ProductnameEng.Text;
            tb.StoreType = combo_Store.Text;
            tb.BrandName = combo_Brand.Text;
            tb.Category = combo_Category.Text;
            tb.Unit = combo_Unit.Text;
            tb.Color = combo_Color.Text;
            tb.Description = txt_Description.Text;
            if (txt_QtyPerUnit.Text != "")
            {
                decimal qtyperunit = decimal.Parse(txt_QtyPerUnit.Text.ToString());
                tb.QtyPerUnit = qtyperunit;
            }
            tb.Company = txt_CompanyProduct.Text;
            tb.Vender = txt_PreferredVender.Text;
            tb.DiscountType = combo_DiscountType.Text;
            if (txt_DirectDiscount.Text != "")
            {
                decimal direct = decimal.Parse(txt_DirectDiscount.Text.ToString());

                tb.DirectDiscount = direct;
            }
            if (txt_NextShoppingDiscount.Text != "")
            {
                decimal nextshopping = decimal.Parse(txt_NextShoppingDiscount.Text.ToString());

                tb.NextShoppingDiscount = nextshopping;
            }
            if (txt_NextShoppingDiscount.Text != "")
            {
                decimal taxpercentage = decimal.Parse(combo_TaxType.Text.ToString());

                tb.TaxPercent = taxpercentage;
            }
            if (txt_NextShoppingDiscount.Text != "")
            {
                decimal redorder = decimal.Parse(txt_ReorderLevel.Text.ToString());

                tb.ReorderLevel = redorder;
            }
            DateTime manu = DateTime.Parse(dateTimePicker2.Text);
            tb.ManufacturingDate = manu;
            DateTime expire = DateTime.Parse(dateTimePicker1.Text);

            tb.ExpireDate = expire;
            tb.PurchaseCurrency = combo_PurchaseCurency.Text;
            tb.SellingCurrency = combo_SellingCurrency.Text;
            if (txt_WholeSalePrice.Text != "")
            {
                decimal wholesale = decimal.Parse(txt_WholeSalePrice.Text.ToString());

                tb.WholeSalePrice = wholesale;
            }
            if (txt_PurchasePrice.Text != "")
            {
                decimal purchaseprice = decimal.Parse(txt_PurchasePrice.Text.ToString());

                tb.PurchasePrice = purchaseprice;
            }
            if (txt_PurchasePrice.Text != "")
            {
                decimal customerprice = decimal.Parse(txt_CustomerPrice.Text.ToString());

                tb.CustomerPrice = customerprice;
            }
            if (txt_RetailPrice.Text != "")
            {
                decimal retialprice = decimal.Parse(txt_RetailPrice.Text.ToString());

                tb.RetailPrice = retialprice;
            }
            if (txt_AddProfit.Text != "")
            {
                decimal addprofit = decimal.Parse(txt_AddProfit.Text.ToString());

                tb.AddProfit = addprofit;
            }
            tb.Status = combo_Status.Text;
            db.tblItemMasters.Add(tb);
            db.SaveChanges();
            MessageBox.Show("Successfully Added", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshGrid();
            ClearField();
            barcodenumber();
            procode();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_ProductnameEng.Text != "")
            {


                Inventory_DBEntities db = new Inventory_DBEntities();
                decimal idd = decimal.Parse(txtID.Text.ToString());
                var tb = db.tblItemMasters.Where(x => x.ID == idd).FirstOrDefault();
                tb.Barcode1 = txt_Barcode1.Text;
                tb.Barcode2 = txt_Barcode2.Text;
                tb.Code = txt_Productcode.Text;
                tb.NameArabic = txt_ProductnameArabic.Text;
                tb.NameEng = txt_ProductnameEng.Text;
                tb.StoreType = combo_Store.Text;
                tb.BrandName = combo_Brand.Text;
                tb.Category = combo_Category.Text;
                tb.Unit = combo_Unit.Text;
                tb.Color = combo_Color.Text;
                tb.Description = txt_Description.Text;
                if (txt_QtyPerUnit.Text != "")
                {
                    decimal qtyperunit = decimal.Parse(txt_QtyPerUnit.Text.ToString());
                    tb.QtyPerUnit = qtyperunit;
                }
                tb.Company = txt_CompanyProduct.Text;
                tb.Vender = txt_PreferredVender.Text;
                tb.DiscountType = combo_DiscountType.Text;
                if (txt_DirectDiscount.Text != "")
                {
                    decimal direct = decimal.Parse(txt_DirectDiscount.Text.ToString());

                    tb.DirectDiscount = direct;
                }
                if (txt_NextShoppingDiscount.Text != "")
                {
                    decimal nextshopping = decimal.Parse(txt_NextShoppingDiscount.Text.ToString());

                    tb.NextShoppingDiscount = nextshopping;
                }
                if (txt_NextShoppingDiscount.Text != "")
                {
                    decimal taxpercentage = decimal.Parse(combo_TaxType.Text.ToString());

                    tb.TaxPercent = taxpercentage;
                }
                if (txt_NextShoppingDiscount.Text != "")
                {
                    decimal redorder = decimal.Parse(txt_ReorderLevel.Text.ToString());

                    tb.ReorderLevel = redorder;
                }
                DateTime manu = DateTime.Parse(dateTimePicker2.Text);
                tb.ManufacturingDate = manu;
                DateTime expire = DateTime.Parse(dateTimePicker1.Text);

                tb.ExpireDate = expire;
                tb.PurchaseCurrency = combo_PurchaseCurency.Text;
                tb.SellingCurrency = combo_SellingCurrency.Text;
                if (txt_WholeSalePrice.Text != "")
                {
                    decimal wholesale = decimal.Parse(txt_WholeSalePrice.Text.ToString());

                    tb.WholeSalePrice = wholesale;
                }
                if (txt_PurchasePrice.Text != "")
                {
                    decimal purchaseprice = decimal.Parse(txt_PurchasePrice.Text.ToString());

                    tb.PurchasePrice = purchaseprice;
                }
                if (txt_PurchasePrice.Text != "")
                {
                    decimal customerprice = decimal.Parse(txt_CustomerPrice.Text.ToString());

                    tb.CustomerPrice = customerprice;
                }
                if (txt_RetailPrice.Text != "")
                {
                    decimal retialprice = decimal.Parse(txt_RetailPrice.Text.ToString());

                    tb.RetailPrice = retialprice;
                }
                if (txt_AddProfit.Text != "")
                {
                    decimal addprofit = decimal.Parse(txt_AddProfit.Text.ToString());

                    tb.AddProfit = addprofit;
                }
                tb.Status = combo_Status.Text;
                db.SaveChanges();

                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
                ClearField();
                barcodenumber();
                procode();




            }
        }


        private void DeleteRecord()
        {
            try
            {
                Inventory_DBEntities db = new Inventory_DBEntities();
                decimal idd = decimal.Parse(txtID.Text.ToString());
                var tb = db.tblItemMasters.Where(x => x.ID == idd).FirstOrDefault();
                db.tblItemMasters.Remove(tb);
                db.SaveChanges();


                MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
                ClearField();
                barcodenumber();
                procode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndel_Click(object sender, EventArgs e)
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

        private void ProductMaster_Load(object sender, EventArgs e)
        {
            refreshGrid();

            barcodenumber();
            procode();


            this.ActiveControl = txt_Barcode2;
            txt_Barcode2.Focus();


            combo_Store.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "SELECT *FROM tbl_StoreMaster";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {


                combo_Store.Items.Add(dr["Name"].ToString());

            }


            ModCommonClasses.con.Close();











            combo_Category.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd1 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd1.CommandType = CommandType.Text;

            ModCommonClasses.cmd1.CommandText = "SELECT *FROM tbl_category";
            ModCommonClasses.cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(ModCommonClasses.cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {


                combo_Category.Items.Add(dr1["Categoryname"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_Brand.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd2 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd2.CommandType = CommandType.Text;

            ModCommonClasses.cmd2.CommandText = "SELECT *FROM tbl_BrandMaster";
            ModCommonClasses.cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(ModCommonClasses.cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {


                combo_Brand.Items.Add(dr2["BrandName"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_Color.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd3 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd3.CommandType = CommandType.Text;

            ModCommonClasses.cmd3.CommandText = "SELECT *FROM tbl_category";
            ModCommonClasses.cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(ModCommonClasses.cmd3);
            da3.Fill(dt3);
            foreach (DataRow dr3 in dt3.Rows)
            {


                combo_Color.Items.Add(dr3["Color"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_Unit.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd4 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd4.CommandType = CommandType.Text;

            ModCommonClasses.cmd4.CommandText = "SELECT *FROM tbl_unitmaster";
            ModCommonClasses.cmd4.ExecuteNonQuery();
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter(ModCommonClasses.cmd4);
            da4.Fill(dt4);
            foreach (DataRow dr4 in dt4.Rows)
            {


                combo_Unit.Items.Add(dr4["Unit_type"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_DiscountType.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd5 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd5.CommandType = CommandType.Text;

            ModCommonClasses.cmd5.CommandText = "SELECT *FROM tbl_discount";
            ModCommonClasses.cmd5.ExecuteNonQuery();
            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter(ModCommonClasses.cmd5);
            da5.Fill(dt5);
            foreach (DataRow dr5 in dt5.Rows)
            {


                combo_DiscountType.Items.Add(dr5["DiscountName"].ToString());

            }


            ModCommonClasses.con.Close();










            combo_PurchaseCurency.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd7 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd7.CommandType = CommandType.Text;

            ModCommonClasses.cmd7.CommandText = "SELECT *FROM tbl_Currency";
            ModCommonClasses.cmd7.ExecuteNonQuery();
            DataTable dt7 = new DataTable();
            SqlDataAdapter da7 = new SqlDataAdapter(ModCommonClasses.cmd7);
            da7.Fill(dt7);
            foreach (DataRow dr7 in dt7.Rows)
            {


                combo_PurchaseCurency.Items.Add(dr7["Name"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_SellingCurrency.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd8 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd8.CommandType = CommandType.Text;

            ModCommonClasses.cmd8.CommandText = "SELECT *FROM tbl_Currency";
            ModCommonClasses.cmd8.ExecuteNonQuery();
            DataTable dt8 = new DataTable();
            SqlDataAdapter da8 = new SqlDataAdapter(ModCommonClasses.cmd8);
            da8.Fill(dt8);
            foreach (DataRow dr8 in dt8.Rows)
            {


                combo_SellingCurrency.Items.Add(dr8["Name"].ToString());

            }


            ModCommonClasses.con.Close();






            combo_TaxType.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd9 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd9.CommandType = CommandType.Text;

            ModCommonClasses.cmd9.CommandText = "SELECT *FROM tbl_Tax";
            ModCommonClasses.cmd9.ExecuteNonQuery();
            DataTable dt9 = new DataTable();
            SqlDataAdapter da9 = new SqlDataAdapter(ModCommonClasses.cmd9);
            da9.Fill(dt9);
            foreach (DataRow dr9 in dt9.Rows)
            {


                combo_TaxType.Items.Add(dr9["Name"].ToString());

            }


            ModCommonClasses.con.Close();



        }

    private void txt_search_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (combo_search_type.Text == "Barcode")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tblItemMasters.Where(x => x.Barcode1 == txt_search.Text).ToList();
                    dataGridView1.DataSource = tb1;
                    dataGridView1.Columns[0].Width = 0;
                }
                else if (combo_search_type.Text == "Name")
                {
                    Inventory_DBEntities db = new Inventory_DBEntities();
                    var tb1 = db.tblItemMasters.Where(x => x.NameEng == txt_search.Text).ToList();
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

                    txt_Barcode1.Text = dr.Cells[1].Value.ToString();
                    txt_Barcode2.Text = dr.Cells[2].Value.ToString();
                    txt_Productcode.Text = dr.Cells[3].Value.ToString();
                    txt_ProductnameArabic.Text = dr.Cells[4].Value.ToString();
                    txt_ProductnameEng.Text = dr.Cells[5].Value.ToString();
                    combo_Store.Text = dr.Cells[6].Value.ToString();
                    combo_Brand.Text = dr.Cells[7].Value.ToString();
                    combo_Category.Text = dr.Cells[8].Value.ToString();
                    combo_Unit.Text = dr.Cells[9].Value.ToString();
                    combo_Color.Text = dr.Cells[10].Value.ToString();
                    txt_Description.Text = dr.Cells[11].Value.ToString();
                    txt_QtyPerUnit.Text = dr.Cells[12].Value.ToString();
                    txt_CompanyProduct.Text = dr.Cells[13].Value.ToString();
                    txt_PreferredVender.Text = dr.Cells[14].Value.ToString();
                    combo_DiscountType.Text = dr.Cells[15].Value.ToString();
                    txt_DirectDiscount.Text = dr.Cells[16].Value.ToString();
                    txt_NextShoppingDiscount.Text = dr.Cells[17].Value.ToString();
                    combo_TaxType.Text = dr.Cells[18].Value.ToString();
                    txt_ReorderLevel.Text = dr.Cells[19].Value.ToString();
                    dateTimePicker2.Text = dr.Cells[20].Value.ToString();
                    dateTimePicker1.Text = dr.Cells[21].Value.ToString();
                    combo_PurchaseCurency.Text = dr.Cells[22].Value.ToString();
                    combo_SellingCurrency.Text = dr.Cells[23].Value.ToString();
                    txt_WholeSalePrice.Text = dr.Cells[24].Value.ToString();
                    txt_PurchasePrice.Text = dr.Cells[25].Value.ToString();
                    txt_CustomerPrice.Text = dr.Cells[26].Value.ToString();
                    txt_RetailPrice.Text = dr.Cells[27].Value.ToString();
                    txt_AddProfit.Text = dr.Cells[28].Value.ToString();
                    combo_Status.Text = dr.Cells[29].Value.ToString();


                }
            }
            catch
            {

            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();




            try
            {
                Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dgw.RowCount - 1;
                colsTotal = dgw.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dgw.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dgw.Rows[I].Cells[j].Value;
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

        private void add1_Click(object sender, EventArgs e)
        {
            Store_Master ss = new Store_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void add2_Click(object sender, EventArgs e)
        {
            Categorymaster ss = new Categorymaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void add3_Click(object sender, EventArgs e)
        {
            Brand_Master ss = new Brand_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void add4_Click(object sender, EventArgs e)
        {
            Categorymaster ss = new Categorymaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void add5_Click(object sender, EventArgs e)
        {
            Unitmaster ss = new Unitmaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void add6_Click(object sender, EventArgs e)
        {
            Tax_Master ss = new Tax_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void add7_Click(object sender, EventArgs e)
        {
            DiscountMaster ss = new DiscountMaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void add8_Click(object sender, EventArgs e)
        {
            Currency_Master ss = new Currency_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void add9_Click(object sender, EventArgs e)
        {
            Currency_Master ss = new Currency_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

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

        private void ProductMaster_Activated(object sender, EventArgs e)
        {
            combo_Store.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "SELECT *FROM tbl_StoreMaster";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {


                combo_Store.Items.Add(dr["Name"].ToString());

            }


            ModCommonClasses.con.Close();











            combo_Category.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd1 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd1.CommandType = CommandType.Text;

            ModCommonClasses.cmd1.CommandText = "SELECT *FROM tbl_category";
            ModCommonClasses.cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(ModCommonClasses.cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {


                combo_Category.Items.Add(dr1["Categoryname"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_Brand.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd2 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd2.CommandType = CommandType.Text;

            ModCommonClasses.cmd2.CommandText = "SELECT *FROM tbl_BrandMaster";
            ModCommonClasses.cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(ModCommonClasses.cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {


                combo_Brand.Items.Add(dr2["BrandName"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_Color.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd3 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd3.CommandType = CommandType.Text;

            ModCommonClasses.cmd3.CommandText = "SELECT *FROM tbl_category";
            ModCommonClasses.cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(ModCommonClasses.cmd3);
            da3.Fill(dt3);
            foreach (DataRow dr3 in dt3.Rows)
            {


                combo_Color.Items.Add(dr3["Color"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_Unit.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd4 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd4.CommandType = CommandType.Text;

            ModCommonClasses.cmd4.CommandText = "SELECT *FROM tbl_unitmaster";
            ModCommonClasses.cmd4.ExecuteNonQuery();
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter(ModCommonClasses.cmd4);
            da4.Fill(dt4);
            foreach (DataRow dr4 in dt4.Rows)
            {


                combo_Unit.Items.Add(dr4["Unit_type"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_DiscountType.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd5 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd5.CommandType = CommandType.Text;

            ModCommonClasses.cmd5.CommandText = "SELECT *FROM tbl_discount";
            ModCommonClasses.cmd5.ExecuteNonQuery();
            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter(ModCommonClasses.cmd5);
            da5.Fill(dt5);
            foreach (DataRow dr5 in dt5.Rows)
            {


                combo_DiscountType.Items.Add(dr5["DiscountName"].ToString());

            }


            ModCommonClasses.con.Close();










            combo_PurchaseCurency.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd7 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd7.CommandType = CommandType.Text;

            ModCommonClasses.cmd7.CommandText = "SELECT *FROM tbl_Currency";
            ModCommonClasses.cmd7.ExecuteNonQuery();
            DataTable dt7 = new DataTable();
            SqlDataAdapter da7 = new SqlDataAdapter(ModCommonClasses.cmd7);
            da7.Fill(dt7);
            foreach (DataRow dr7 in dt7.Rows)
            {


                combo_PurchaseCurency.Items.Add(dr7["Name"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_PurchaseCurency.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd8 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd8.CommandType = CommandType.Text;

            ModCommonClasses.cmd8.CommandText = "SELECT *FROM tbl_Currency";
            ModCommonClasses.cmd8.ExecuteNonQuery();
            DataTable dt8 = new DataTable();
            SqlDataAdapter da8 = new SqlDataAdapter(ModCommonClasses.cmd8);
            da8.Fill(dt8);
            foreach (DataRow dr8 in dt8.Rows)
            {


                combo_PurchaseCurency.Items.Add(dr8["Name"].ToString());

            }


            ModCommonClasses.con.Close();





            combo_TaxType.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd9 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd9.CommandType = CommandType.Text;

            ModCommonClasses.cmd9.CommandText = "SELECT *FROM tbl_Tax";
            ModCommonClasses.cmd9.ExecuteNonQuery();
            DataTable dt9 = new DataTable();
            SqlDataAdapter da9 = new SqlDataAdapter(ModCommonClasses.cmd9);
            da9.Fill(dt9);
            foreach (DataRow dr9 in dt9.Rows)
            {


                combo_TaxType.Items.Add(dr9["Name"].ToString());

            }


            ModCommonClasses.con.Close();




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

        private void ProductMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }

        }
    }
}

    

