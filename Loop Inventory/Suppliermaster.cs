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
    public partial class Suppliermaster : Form
    {
        public Suppliermaster()
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
            if (txt_supplier_name.Text != "")
            {

                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                ModCommonClasses.cmd = new SqlCommand("insert into tbl_supplier(Date,Suppliername,Producttype,Address,City,Email,Mobile,Creditamount) values(@Date,@Suppliername,@Producttype,@Address,@City,@Email,@Mobile,@Creditamount)", ModCommonClasses.con);

                ModCommonClasses.cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Suppliername", txt_supplier_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Producttype", combo_pro_type.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Address", txt_address.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@City", txt_city.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Mobile", txt_mob.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Creditamount", txt_credit.Text);


                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();






                this.ActiveControl = txt_supplier_name;
                txt_supplier_name.Focus();

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

            ModCommonClasses.cmd.CommandText = "select * from tbl_supplier";
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


            txt_supplier_name.Text = "";
            txt_address.Text = "";
            txt_city.Text = "";
            txt_email.Text = "";
            txt_mob.Text = "";
            combo_pro_type.Text = "";
            txt_credit.Text = "";
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " Naveed Links Supplier Record";
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
            if (combo_search_type.Text == "Supplier")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Suppliercode,Date,Suppliername,Producttype,Address,City,Email,Mobile,Creditamount FROM tbl_supplier where Suppliername like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }

            if (combo_search_type.Text == "Mobile")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Suppliercode,Date,Suppliername,Producttype,Address,City,Email,Mobile,Creditamount FROM tbl_supplier where Mobile like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void Suppliermaster_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_supplier' table. You can move, or remove it, as needed.
            this.tbl_supplierTableAdapter.Fill(this.inventory_DBDataSet.tbl_supplier);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;

            dataGridView1.EnableHeadersVisualStyles = false;

            this.ActiveControl = txt_supplier_name;
            txt_supplier_name.Focus();



            combo_search_type.SelectedIndex = 0;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                    dateTimePicker1.Text = dr.Cells[1].Value.ToString();
                    txt_supplier_name.Text = dr.Cells[2].Value.ToString();
                    combo_pro_type.Text = dr.Cells[3].Value.ToString();
                    txt_address.Text = dr.Cells[4].Value.ToString();
                    txt_city.Text = dr.Cells[5].Value.ToString();
                    txt_email.Text = dr.Cells[6].Value.ToString();

                    txt_mob.Text = dr.Cells[7].Value.ToString();
                    txt_credit.Text = dr.Cells[8].Value.ToString();





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
            if (txt_supplier_name.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_supplier_name.Focus();
                return;
            }

            try
            {


                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_supplier set Date=@d1, Suppliername=@d2, Producttype=@d3, Address=@d4, City=@d5, Email=@d6, Mobile=@d7, Creditamount=@d8 WHERE Suppliercode=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtID.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_supplier_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", combo_pro_type.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txt_address.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txt_city.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txt_email.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txt_mob.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txt_credit.Text);




                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the Supplier '" + txt_supplier_name.Text + "' info";

                MessageBox.Show("Successfully Updated", "Supplier Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the Supplier '" + txt_supplier_name.Text + "' Having Supplier Code '" + txtID.Text + "'");
                DisplayData();
                ClearData();


                this.ActiveControl = txt_supplier_name;
                txt_supplier_name.Focus();

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
                string cq = "delete from tbl_supplier where Suppliercode=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the Supplier '" + txtID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = txt_supplier_name;
                    txt_supplier_name.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the Supplier '" + txt_supplier_name.Text + "' Having Supplier Code '" + txtID.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_supplier_name.Focus();
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