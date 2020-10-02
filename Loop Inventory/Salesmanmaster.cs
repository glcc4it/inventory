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
    public partial class Salesmanmaster : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public Salesmanmaster()
        {
            InitializeComponent();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_salesman_name.Text != "")
            {

                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                ModCommonClasses.cmd = new SqlCommand("insert into tbl_salesman(Date,Salesmanname,Address,City,Email,Mobile,CNIC,Narration) values(@Date,@Salesmanname,@Address,@City,@Email,@Mobile,@CNIC,@Narration)", ModCommonClasses.con);

                ModCommonClasses.cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Salesmanname", txt_salesman_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Address", txt_address.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@City", txt_city.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Mobile", txt_mob.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@CNIC", txt_cnic_no.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Narration", txt_des.Text);


                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();







                MessageBox.Show("Record Inserted Successfully");

                this.ActiveControl = txt_salesman_name;
                txt_salesman_name.Focus();
                ModFunc.LogFunc(lblUser.Text, "Added the Salesman '" + txt_salesman_name.Text + "' Having Salesman Code '" + txtID.Text + "'");
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Provide Details!");

                this.ActiveControl = txt_salesman_name;
                txt_salesman_name.Focus();
            }
        }
        //Display Data in DataGridView
        private void DisplayData()
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "select * from tbl_salesman";
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


            txt_salesman_name.Text = "";
            txt_address.Text = "";
            txt_city.Text = "";
            txt_email.Text = "";
            txt_mob.Text = "";
            txt_cnic_no.Text = "";
            txt_des.Text = "";
        }

        private void Salesmanmaster_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_salesman' table. You can move, or remove it, as needed.
            this.tbl_salesmanTableAdapter.Fill(this.inventory_DBDataSet.tbl_salesman);
           
            combo_search_type.SelectedIndex = 0;
            this.ActiveControl = txt_salesman_name;
            txt_salesman_name.Focus();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Salesman Records";
            printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Developed By Glcc4it Solutions";
            printer.FooterSpacing = 5;
          
            printer.PrintDataGridView(dataGridView1);
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (combo_search_type.Text == "Salesman")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Salesmancode,Date,Salesmanname,Address,City,Email,Mobile,CNIC,Narration FROM tbl_salesman where Salesmanname like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }

            if (combo_search_type.Text == "Mobile")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Salesmancode,Date,Salesmanname,Address,City,Email,Mobile,CNIC,Narration FROM tbl_salesman where Mobile like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_salesman_name.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_salesman_name.Focus();
                return;
            }

            try
            {


                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_salesman set Date=@d1, Salesmanname=@d2, Address=@d3, City=@d4, Email=@d5, Mobile=@d6, CNIC=@d7, Narration=@d8 WHERE Salesmancode=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtID.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_salesman_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txt_address.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txt_city.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txt_email.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txt_mob.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txt_cnic_no.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txt_des.Text);
               


               
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the Salesman '" + txt_salesman_name.Text + "' info";

                MessageBox.Show("Successfully Updated", "Salesman Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the Salesman '" + txt_salesman_name.Text + "' Having Salesman Code '" + txtID.Text + "'");
                DisplayData();
                ClearData();


                this.ActiveControl = txt_salesman_name;
                txt_salesman_name.Focus();

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
                string cq = "delete from tbl_salesman where Salesmancode=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the Salesman '" + txtID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = txt_salesman_name;
                    txt_salesman_name.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the Salesman '" + txt_salesman_name.Text + "' Having Salesman Code '" + txtID.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_salesman_name.Focus();
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                    txtID.Text = dr.Cells[0].Value.ToString();
                    dateTimePicker1.Text = dr.Cells[1].Value.ToString();
                    txt_salesman_name.Text = dr.Cells[2].Value.ToString();
                    txt_address.Text = dr.Cells[3].Value.ToString();
                    txt_city.Text = dr.Cells[4].Value.ToString();
                    txt_email.Text = dr.Cells[5].Value.ToString();
                    txt_mob.Text = dr.Cells[6].Value.ToString();

                    txt_cnic_no.Text = dr.Cells[7].Value.ToString();
                    txt_des.Text = dr.Cells[8].Value.ToString();





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

        private void Salesmanmaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
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

        private void txt_des_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnSave.PerformClick();

            }
        }

        private void combo_search_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_search_type.SelectedItem.ToString() == "Salesman")
            {

                this.ActiveControl = txt_search;
                txt_search.Focus();

            }



            if (combo_search_type.SelectedItem.ToString() == "Mobile")
            {

                this.ActiveControl = txt_search;
                txt_search.Focus();

            }
        }

    }

}