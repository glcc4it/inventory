﻿using System;
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
    public partial class Item_Master : Form
    {
        public Item_Master()
        {
            InitializeComponent();
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
            txt_TaxPercentage.Text = "";
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
        private void lnk_sve_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
            tb.CompanyProduct = txt_CompanyProduct.Text;
            tb.VenderPreferred = txt_PreferredVender.Text;
            tb.DiscountType = combo_DiscountType.Text;
            if (txt_DirectDiscount.Text != "")
            {
                decimal direct = decimal.Parse(txt_DirectDiscount.Text.ToString());

                tb.DirectDiscount =direct;
            }
            if (txt_NextShoppingDiscount.Text != "")
            {
                decimal nextshopping = decimal.Parse(txt_NextShoppingDiscount.Text.ToString());

                tb.NextShoppingDiscount = nextshopping;
            }
            if (txt_NextShoppingDiscount.Text != "")
            {
                decimal taxpercentage = decimal.Parse(txt_TaxPercentage.Text.ToString());

                tb.TaxPercentage = taxpercentage;
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
        }

        private void lnk_sale_rpt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearField();
        }

        private void lnk_exprt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                tb.CompanyProduct = txt_CompanyProduct.Text;
                tb.VenderPreferred = txt_PreferredVender.Text;
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
                    decimal taxpercentage = decimal.Parse(txt_TaxPercentage.Text.ToString());

                    tb.TaxPercentage = taxpercentage;
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




            }
        }

        private void btn_delete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                decimal idd = decimal.Parse(txtID.Text.ToString());
                var tb = db.tblItemMasters.Where(x => x.ID == idd).FirstOrDefault();
                db.tblItemMasters.Remove(tb);
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

        private void Item_Master_Load(object sender, EventArgs e)
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
                    combo_Brand.Text  = dr.Cells[7].Value.ToString();
                    combo_Category.Text  = dr.Cells[8].Value.ToString();
                    combo_Unit.Text  = dr.Cells[9].Value.ToString();
                    combo_Color.Text  = dr.Cells[10].Value.ToString();
                    txt_Description.Text = dr.Cells[11].Value.ToString();
                    txt_QtyPerUnit.Text = dr.Cells[12].Value.ToString();
                    txt_CompanyProduct.Text = dr.Cells[13].Value.ToString();
                    txt_PreferredVender.Text = dr.Cells[14].Value.ToString();
                    combo_DiscountType.Text  = dr.Cells[15].Value.ToString();
                    txt_DirectDiscount.Text = dr.Cells[16].Value.ToString();
                    txt_NextShoppingDiscount.Text = dr.Cells[17].Value.ToString();
                    txt_TaxPercentage.Text = dr.Cells[18].Value.ToString();
                    txt_ReorderLevel.Text = dr.Cells[19].Value.ToString();
                    dateTimePicker2.Text  = dr.Cells[20].Value.ToString();
                    dateTimePicker1.Text  = dr.Cells[21].Value.ToString();
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

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnk_stock_updte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
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
    }
}
