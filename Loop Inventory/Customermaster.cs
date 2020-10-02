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
    public partial class Customermaster : Form
    {
        public Customermaster()
        {
            InitializeComponent();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo, "Exit System") == MsgBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_cus_name.Text != "")
            {

                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                ModCommonClasses.cmd = new SqlCommand("insert into tbl_customer(Date,Customername,Address,Cityname,Email,Mobileno,Tinno,Balanceamount,Total) values(@Date,@Customername,@Address,@Cityname,@Email,@Mobileno,@Tinno,@Balanceamount,@Total)", ModCommonClasses.con);

                ModCommonClasses.cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Customername", txt_cus_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Address", txt_address.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Cityname", txt_city.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Mobileno", txt_mob.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Tinno", txt_tin_no.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Balanceamount", txt_balance.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Total", txt_total.Text);


                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();






                this.ActiveControl = txt_cus_name;
                txt_cus_name.Focus();

                MessageBox.Show("Record Inserted Successfully");
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }
        //Display Data in DataGridView
        private void DisplayData()
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "select * from tbl_customer";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            ModCommonClasses.con.Close();
        }
        //Clear Data 
        private void ClearData()
        {


            txt_cus_name.Text = "";
            txt_address.Text = "";
            txt_city.Text = "";
            txt_email.Text = "";
            txt_mob.Text = "";
            txt_tin_no.Text = "";
            txt_balance.Text = "";
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " Naveed Links Customer Record";
            printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Developed By Glcc4it Solutions";
            printer.FooterSpacing = 5;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dataGridView1);
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (combo_search_type.Text == "Customer")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Customercode,Date,Customername,Address,Cityname,Email,Mobileno,Tinno,Balanceamount FROM tbl_customer where Customername like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }

            if (combo_search_type.Text == "Mobile")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Customercode,Date,Customername,Address,Cityname,Email,Mobileno,Tinno,Balanceamount FROM tbl_customer where Mobileno like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void Customermaster_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_customer' table. You can move, or remove it, as needed.
            this.tbl_customerTableAdapter.Fill(this.inventory_DBDataSet.tbl_customer);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;

            dataGridView1.EnableHeadersVisualStyles = false;
            combo_search_type.SelectedIndex = 0;
            this.ActiveControl = txt_cus_name;
            txt_cus_name.Focus();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                    dateTimePicker1.Text = dr.Cells[1].Value.ToString();
                    txt_cus_name.Text = dr.Cells[2].Value.ToString();
                    txt_address.Text = dr.Cells[3].Value.ToString();
                    txt_city.Text = dr.Cells[4].Value.ToString();
                    txt_email.Text = dr.Cells[5].Value.ToString();
                    txt_mob.Text = dr.Cells[6].Value.ToString();

                    txt_tin_no.Text = dr.Cells[7].Value.ToString();
                    txt_balance.Text = dr.Cells[8].Value.ToString();





                    btnUpdate.Enabled = true;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string cb = "Update tbl_customer set Date=@d1, Customername=@d2, Address=@d3, Cityname=@d4, Email=@d5, Mobileno=@d6, Tinno=@d7, Balanceamount=@d8 WHERE Customercode=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtID.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_cus_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txt_address.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txt_city.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txt_email.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txt_mob.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txt_tin_no.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txt_balance.Text);




                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the Customer '" + txt_cus_name.Text + "' info";

                MessageBox.Show("Successfully Updated", "Customer Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the Customer '" + txt_cus_name.Text + "' Having Customer Code '" + txtID.Text + "'");
                DisplayData();
                ClearData();


                this.ActiveControl = txt_cus_name;
                txt_cus_name.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                int RowsAffected = 0;
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cq = "delete from tbl_customer where Customercode=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the Customer '" + txtID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = txt_cus_name;
                    txt_cus_name.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the Customer '" + txt_cus_name.Text + "' Having Customer Code '" + txtID.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_cus_name.Focus();
                    return;

                }
                if (ModCommonClasses.con.State == ConnectionState.Open)
                    ModCommonClasses.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }
}

}