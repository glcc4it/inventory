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
using System.IO;

namespace Loop_Inventory
{
    public partial class Dashboard : Form
    {
        private string Filename;
       
        public Dashboard()
        {
            InitializeComponent();
        }



        public void Backup()
		{
			try
			{
				DateTime dt = DateTime.Today;
				string destdir = "Inventory_DB " + DateTime.Now.ToString("dd-MM-yyyy_h-mm-ss") + ".bak";
				SaveFileDialog objdlg = new SaveFileDialog();
				objdlg.FileName = destdir;
				objdlg.ShowDialog();
				Filename = objdlg.FileName;
				Cursor = Cursors.WaitCursor;
				timer2.Enabled = true;
				ModCommonClasses.con = new SqlConnection(ModCS.cs);
				ModCommonClasses.con.Open();
				string cb = "backup database Inventory_DB to disk='" + Filename + "'with init,stats=10";
				ModCommonClasses.cmd = new SqlCommand(cb);
				ModCommonClasses.cmd.Connection = ModCommonClasses.con;
				ModCommonClasses.cmd.ExecuteReader();
				ModCommonClasses.con.Close();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


        public void LogOut()
        {
          
            string st = "Successfully logged out";
            ModFunc.LogFunc(lblUser.Text, st);
            this.Hide();
            frmLogin ss = new frmLogin();
            ss.Show();



            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            

            try
            {
               
                {
                    if (MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Backup();
                        LogOut();
                    }
                    else
                        LogOut();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
           
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

      
       

        private void linkLabel31_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                openFileDialog1.Filter = ("DB Backup File|*.bak;");
                openFileDialog1.FilterIndex = 4;
                //Clear the file name
                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    timer2.Enabled = true;
                    SqlConnection.ClearAllPools();
                    ModCommonClasses.con = new SqlConnection(ModCS.cs);
                    ModCommonClasses.con.Open();
                    string cb = "USE Master ALTER DATABASE Inventory_DB SET Single_User WITH Rollback Immediate Restore database Inventory_DB FROM disk='" + openFileDialog1.FileName + "' WITH REPLACE ALTER DATABASE Inventory_DB SET Multi_User ";
                    ModCommonClasses.cmd = new SqlCommand(cb);
                    ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                    ModCommonClasses.cmd.ExecuteReader();
                    ModCommonClasses.con.Close();
                    string st = "Sucessfully performed the restore";
                    ModFunc.LogFunc(lblUser.Text, st);
                    MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt");
        }

        private void userlogs_Click(object sender, EventArgs e)
        {
            Logs ss = new Logs();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void securty_Click(object sender, EventArgs e)
        {
            Securityrights ss = new Securityrights();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void userreg_Click(object sender, EventArgs e)
        {
            UserrRegisterd ss = new UserrRegisterd();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        

        

        private void timer2_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer2.Enabled = false;
        }

        private void linkLabel32_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Backup();
        }

        

        private void priceLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pricing_level ss = new Pricing_level();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        
       
        private void BillingSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Services_Billing ss = new Services_Billing();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void EditCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Companymaster ss = new Companymaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void LinkCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Companymaster ss = new Companymaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        

        private void LinkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Categorymaster ss = new Categorymaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void CatgoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categorymaster ss = new Categorymaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void LinkUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Unitmaster ss = new Unitmaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void UnitMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unitmaster ss = new Unitmaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void LinkRack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Rackmaster ss = new Rackmaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void RackMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rackmaster ss = new Rackmaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void LinkAddproduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductMaster ss = new ProductMaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;


        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductMaster ss = new ProductMaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

       

        

        private void LinkSalesman_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Salesmanmaster ss = new Salesmanmaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void salesManToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salesmanmaster ss = new Salesmanmaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void LinkUserrights_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            UserSetting ss = new UserSetting();
            ss.Show();

        }

        private void LinkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Supplier_Master ss = new Supplier_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void SupplierMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplier_Master ss = new Supplier_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void GodownMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Godownmaster ss = new Godownmaster();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;

        }

        private void PurchaseProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchaseproduct ss = new Purchaseproduct();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void PurchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase_Return ss = new Purchase_Return();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void purchaseViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseRecord ss = new frmPurchaseRecord();
            ss.Show();
            
        }

        private void SaleProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Saleproduct ss = new Saleproduct();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void SaleReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale_Return ss = new Sale_Return();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void salesViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale_view ss = new Sale_view();
            ss.Show();
            
        }

        private void ImportProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Import_Product ss = new Import_Product();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void stockProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_Product ss = new Stock_Product();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void CashPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Cash_Transaction ss = new Cash_Transaction();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
            
        }

        

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aboutus ss = new Aboutus();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

       

       

        

       

        private void LinkStockproduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Stock_Product ss = new Stock_Product();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void StockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_Transfer ss = new Stock_Transfer();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void securityRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_Report ss = new Stock_Report();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        

        private void transation_Click(object sender, EventArgs e)
        {
            Transaction_Record ss = new Transaction_Record();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void transToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction_Reports ss = new Transaction_Reports();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

      

        

       

       

        private void SearchRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Services_Billing ss = new Services_Billing();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void dayBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Daybook ss = new Daybook();
            ss.Show();
            
        }

        private void CashbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cashbook ss = new Cashbook();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trial_Balance ss = new Trial_Balance();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void profitAndLossAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profit_and_Loss ss = new Profit_and_Loss();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        

        

        

        private void repairLedgerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void serviesTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void LinkBarcodesetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Receipt_Customer ss = new Receipt_Customer();
            ss.Show();
            
        }

        

        private void serviceLedgerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Service_Ledger_Report ss = new Service_Ledger_Report();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void purchaseReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase_Report ss = new Purchase_Report();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void currenyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Currency_Master ss = new Currency_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void expenseMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expense_Master ss = new Expense_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void taxMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tax_Master ss = new Tax_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        

        private void storeMasterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Store_Master ss = new Store_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void bonusQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quantity_Bonus ss = new Quantity_Bonus();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void AccountGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account_Master ss = new Account_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void moneyTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Money_Transfer ss = new Money_Transfer();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void CustomerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Master ss = new Customer_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void quantityMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quantity_Bonus ss = new Quantity_Bonus();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }
    }
}
