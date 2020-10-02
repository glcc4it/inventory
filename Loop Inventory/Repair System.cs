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
    public partial class Repair_System : Form
    {

        string serid = "Ser-";
        SqlDataAdapter adapt;
        DataTable dt;
        public Repair_System()
        {
            InitializeComponent();
        }



        public void autonumber()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = new SqlCommand("select max (Job_no)+1 from tbl_repair_order", ModCommonClasses.con);
            SqlDataReader dr = ModCommonClasses.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txt_id.Text = dr[0].ToString();
                    if (txt_id.Text == "")
                    {
                        txt_id.Text = "01";

                    }

                }

            }
            else
            {
                txt_id.Text = "01";
            }

            ModCommonClasses.con.Close();
        }

        
        public void sercode()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            SqlCommand cmd = new SqlCommand("select Count(Servicesid) from tbl_repair_order", ModCommonClasses.con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            ModCommonClasses.con.Close();
            i++;
            txtServicesID.Text = serid + i.ToString();

        }

           

        private void Repair_System_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_repair_order' table. You can move, or remove it, as needed.
            this.tbl_repair_orderTableAdapter.Fill(this.inventory_DBDataSet.tbl_repair_order);
           
            
            
           
            
           
           
            
            sercode();
            autonumber();
            this.ActiveControl = txt_cus_name;
            txt_cus_name.Focus();

            
        }

       

       

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Repair_System_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            {
                string s = "";
                foreach (Control c in this.Controls)
                {

                    if (c is CheckBox)
                    {

                        CheckBox b = (CheckBox)c;
                        if (b.Checked)
                        {

                            s = b.Text + " " + s;
                        }
                    }

                }





                if (txt_cus_name.Text != "" && txt_cus_numbr.Text != "" && Cmb_mob_brnd.Text != "" && txt_model.Text != "")
                {

                    ModCommonClasses.con = new SqlConnection(ModCS.cs);
                    ModCommonClasses.con.Open();
                    string cb = "insert into tbl_repair_order(Servicesid,Job_no,Invoicedate,cus_name,cus_number,Mobile_brand,Mobile_model,Mobile_fault,Other_fault,worker,Estimate,mobile_acccess,Reciveid_by,Description,Market,Out_date,Status,Total_payment,Advance,Balance) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)";
                    ModCommonClasses.cmd = new SqlCommand(cb);

                    ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtServicesID.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_id.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dateTimePicker1.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txt_cus_name.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txt_cus_numbr.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Cmb_mob_brnd.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txt_model.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Cmb_mob_fault.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d9", txt_other_fault.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Cmb_worker.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d11", txt_esitmate.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d12", s);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Cmb_recivied_by.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d14", txt_decrption.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d15", txt_market.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dateTimePicker2.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Cmb_status.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d18", txt_old_bal.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d19", txt_paid_amount.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d20", txt_dues.Text);

                    ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                    ModCommonClasses.cmd.ExecuteNonQuery();
                    ModCommonClasses.con.Close();





                    ModFunc.ServicesLedgerBook(dateTimePicker1.Text, txtServicesID.Text, txt_cus_name.Text, "Service Payment", 0, Convert.ToDecimal(txt_old_bal.Text), txt_cus_numbr.Text);
                    ModFunc.ServicesLedgerBook(dateTimePicker1.Text, txtServicesID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_paid_amount.Text), 0, txt_cus_numbr.Text);



                    ModFunc.LedgerSave(dateTimePicker1.Text, txtServicesID.Text, txt_cus_name.Text, "Service Payment", 0, Convert.ToDecimal(txt_old_bal.Text), txt_cus_numbr.Text);
                    ModFunc.LedgerSave(dateTimePicker1.Text, txtServicesID.Text, "Cash Account", "Payment", Convert.ToDecimal(txt_paid_amount.Text), 0, txt_cus_numbr.Text);


                    
                    


                    ModFunc.LogFunc(lblUser.Text, "Added the New Services Having ServicesID '" + txtServicesID.Text + "'");
                    MessageBox.Show("Successfully Saved", "Customer Record", MessageBoxButtons.OK, MessageBoxIcon.Information);




                    this.ActiveControl = txt_cus_name;
                    txt_cus_name.Focus();
                    sercode();
                    autonumber();
                    DisplayData();
                    ClearData();

                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                    this.ActiveControl = txt_cus_name;
                    txt_cus_name.Focus();
                }
            }
        }
        
        
        //Display Data in DataGridView
        private void DisplayData()
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "select * from tbl_repair_order";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            advancedDataGridView1.DataSource = dt;
            ModCommonClasses.con.Close();
        }
        //Clear Data 
        private void ClearData()
        {


            dateTimePicker1.Text = "";
            txt_cus_name.Text = "";
            txt_cus_numbr.Text = "";
            Cmb_mob_brnd.Text = "---Select Brand---";
            txt_model.Text = "";

            Cmb_mob_fault.Text = "--- Mobile Fault---";
            txt_other_fault.Text = "";
            Cmb_worker.Text = "--- Select Worker---";
            txt_esitmate.Text = "";
            txt_old_bal.Text = "";
            txt_paid_amount.Text = "";


            txt_dues.Text = "";
            Cmb_recivied_by.Text = "--- Select Worker---";

            txt_decrption.Text = "";
            txt_market.Text = "";
            Cmb_status.Text = "--- Select Status---";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
        }

        private void advancedDataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (advancedDataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = advancedDataGridView1.SelectedRows[0];



                    txtID.Text = dr.Cells[0].Value.ToString();
                    txtServicesID.Text = dr.Cells[1].Value.ToString();
                    txt_id.Text = dr.Cells[2].Value.ToString();
                    dateTimePicker1.Text = dr.Cells[3].Value.ToString();
                    txt_cus_name.Text = dr.Cells[4].Value.ToString();
                    txt_cus_numbr.Text = dr.Cells[5].Value.ToString();
                    Cmb_mob_brnd.Text = dr.Cells[6].Value.ToString();
                    txt_model.Text = dr.Cells[7].Value.ToString();
                    Cmb_mob_fault.Text = dr.Cells[8].Value.ToString();
                    txt_other_fault.Text = dr.Cells[9].Value.ToString();
                    Cmb_worker.Text = dr.Cells[10].Value.ToString();
                    txt_esitmate.Text = dr.Cells[11].Value.ToString();

                   
                    
                    Cmb_recivied_by.Text = dr.Cells[13].Value.ToString();
                    txt_decrption.Text = dr.Cells[14].Value.ToString();

                    txt_market.Text = dr.Cells[15].Value.ToString();
                    Cmb_status.Text = dr.Cells[16].Value.ToString();

                    Cmb_status.Text = dr.Cells[17].Value.ToString();


                    txt_old_bal.Text = dr.Cells[18].Value.ToString();
                    txt_paid_amount.Text = dr.Cells[19].Value.ToString();
                    txt_dues.Text = dr.Cells[20].Value.ToString();





                    txt_old_bal.ReadOnly = true;
                    txt_paid_amount.ReadOnly = true;
                    txt_dues.ReadOnly = true;






                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            adapt = new SqlDataAdapter("select * from tbl_repair_order where Job_no like '" + txt_search.Text + "%'", ModCommonClasses.con);
            dt = new DataTable();
            adapt.Fill(dt);
            advancedDataGridView1.DataSource = dt;
            ModCommonClasses.con.Close();
        }

        private void txt_advance_pay_TextChanged(object sender, EventArgs e)
        {
            int value1 = 0;
            int value2 = 0;
            int result = 0;

            if (int.TryParse(txt_old_bal.Text, out value1) & int.TryParse(txt_paid_amount.Text, out value2))
            {
                result = value1 - value2;
                txt_dues.Text = result.ToString();
            }

            string value = txt_paid_amount.Text;

            if (value == "")
            {




                txt_dues.Text = "";


            }
        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_cus_name.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_cus_name.Focus();
                return;
            }

            try
            {


                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "update tbl_repair_order set Job_no=@d1, Invoicedate=@d2,cus_name=@d3, cus_number=@d4, Mobile_brand=@d5,Mobile_model=@d6,Mobile_fault=@d7,Other_fault=@d8,worker=@d9,Estimate=@d10,Reciveid_by=@d11,Description=@d12,Market=@d13,Status=@d14,Total_payment=@d15,Advance=@d16,Balance=@d17 where Servicesid=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtServicesID.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_id.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txt_cus_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txt_cus_numbr.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Cmb_mob_brnd.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txt_model.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Cmb_mob_fault.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txt_other_fault.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Cmb_worker.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d10", txt_esitmate.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Cmb_recivied_by.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d12", txt_decrption.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d13", txt_market.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Cmb_status.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d15", txt_old_bal.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d16", txt_paid_amount.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d17", txt_dues.Text);


                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModFunc.LogFunc(lblUser.Text, "Updated the Customer Having Customer id '" + txtServicesID.Text + "'");
                MessageBox.Show("Successfully Updated", "Customer Record", MessageBoxButtons.OK, MessageBoxIcon.Information);



                ModCommonClasses.con.Close();
                this.ActiveControl = txt_cus_name;
                txt_cus_name.Focus();
                sercode();
                autonumber();
                DisplayData();
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearData();
            sercode();
            autonumber();
            this.ActiveControl = txt_cus_name;
            txt_cus_name.Focus();
        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.tblrepairorderBindingSource.Sort = this.advancedDataGridView1.SortString;
        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.tblrepairorderBindingSource.Filter = this.advancedDataGridView1.FilterString;
        }

        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = advancedDataGridView1.SelectedRows[0];




                this.Hide();
                Services_Billing frmtrans = new Services_Billing();
               

                frmtrans.Show();



                frmtrans.txtID.Text = dr.Cells[0].Value.ToString();
                frmtrans.txtAccountID.Text = dr.Cells[1].Value.ToString();
                frmtrans.txtAccountName.Text = dr.Cells[4].Value.ToString();
                frmtrans.txtContactNo.Text = dr.Cells[5].Value.ToString();
                frmtrans.GetSupplierBalance();





            }






            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

      
    }

}

