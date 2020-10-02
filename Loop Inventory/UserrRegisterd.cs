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
    public partial class UserrRegisterd : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        private string st1;
        public UserrRegisterd()
        {
            InitializeComponent();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void autonumber()
        {

            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd = new SqlCommand("select max (UserID)+1 from tbl_login", ModCommonClasses.con);
            SqlDataReader dr = ModCommonClasses.cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtUserID.Text = dr[0].ToString();
                    if (txtUserID.Text == "")
                    {
                        txtUserID.Text = "01";

                    }

                }

            }
            else
            {
                txtUserID.Text = "01";
            }

            ModCommonClasses.con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter Username", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }


            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string ct = "select userid from tbl_login where UserID=@d1";
                ModCommonClasses.cmd = new SqlCommand(ct);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtUserID.Text);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                if (ModCommonClasses.rdr.Read())
                {
                    MessageBox.Show("User ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserID.Text = "";
                    txtUserID.Focus();
                    if (ModCommonClasses.rdr != null)
                        ModCommonClasses.rdr.Close();
                    return;
                }

                if (chkActive.Checked == true)
                    st1 = "Yes";
                else
                    st1 = "No";
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "insert into tbl_login(UserID, UserType, Name, Password, Address, Email, Mobile, JoiningDate, Active) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModFunc ep = new ModFunc();
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtUserID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", cmbUserType.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txtName.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", ModFunc.Encrypt(txtPassword.Text.Trim()));

                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txtAddress.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txtemail.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txtmobile.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", DateTime.Now);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d9", st1);
                ModCommonClasses.cmd.ExecuteReader();
                ModCommonClasses.con.Close();
                string st = "added the new user '" + txtUserID.Text + "'";
                
                MessageBox.Show("Successfully Registered", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Add New User '" + txtName.Text + "' Having UserID '" + txtUserID.Text + "'");
                autonumber();
                this.ActiveControl = cmbUserType;
                cmbUserType.Focus();
                DisplayData();
                ClearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Display Data in DataGridView
        private void DisplayData()
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "select * from tbl_login";
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
           
            cmbUserType.Text = "--- Select Type---";
            txtName.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";
            txtemail.Text = "";
            txtmobile.Text = "";
            chkActive.Checked = false;
        }

        private void UserrRegisterd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_login' table. You can move, or remove it, as needed.
            this.tbl_loginTableAdapter.Fill(this.inventory_DBDataSet.tbl_login);


            dataGridView1.EnableHeadersVisualStyles = false;

            this.ActiveControl = cmbUserType;
            cmbUserType.Focus();
            ClearData();
            DisplayData();
            autonumber();
            
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                    txtUserID.Text = dr.Cells[0].Value.ToString();
                    cmbUserType.Text = dr.Cells[1].Value.ToString();
                    txtName.Text = dr.Cells[2].Value.ToString();
                    txtPassword.Text = dr.Cells[3].Value.ToString();
                    txtAddress.Text = dr.Cells[4].Value.ToString();
                    txtemail.Text = dr.Cells[5].Value.ToString();
                    txtmobile.Text = dr.Cells[6].Value.ToString();

                   


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUserType.Focus();
                return;
            }

            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_login set UserID=@d1,UserType=@d2,Name=@d3,Password=@d4,Address=@d5,Email=@d6,Mobile=@d7,JoiningDate=@d8 WHERE UserID=@d1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txtUserID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", cmbUserType.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txtName.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", txtPassword.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txtAddress.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txtemail.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txtmobile.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", DateTime.Now);




                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the User '" + txtName.Text + "' info";

                MessageBox.Show("Successfully Updated", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the User '" + txtName.Text + "' Having UserID '" + txtUserID.Text + "'");
                DisplayData();
                ClearData();
                this.ActiveControl = cmbUserType;
                cmbUserType.Focus();
                autonumber();

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
                string cq = "delete from tbl_login where UserID=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtUserID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the User '" + txtUserID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = cmbUserType;
                    cmbUserType.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the User '" + txtName.Text + "' Having UserID '" + txtUserID.Text + "'");
                    autonumber();
                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbUserType.Focus();
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

        private void UserrRegisterd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }

        private void combo_search_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_search_type.SelectedItem.ToString() == "Username")
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

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (combo_search_type.Text == "Username")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT UserID,UserType,Name,Password,Address,Email,Mobile,JoiningDate,Active FROM tbl_login where Name like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;


            }

            if (combo_search_type.Text == "Mobile")
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT UserID,UserType,Name,Password,Address,Email,Mobile,JoiningDate,Active FROM tbl_login where Mobile like '" + txt_search.Text + "%'", ModCommonClasses.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;


            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "User Records";
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


    }
}
