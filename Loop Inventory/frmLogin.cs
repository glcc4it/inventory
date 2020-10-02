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
    public partial class frmLogin : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);


        
		
        public frmLogin()
        {
            InitializeComponent();

        }

       

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (Username.Text.Trim(' ').Length == 0)
            {
                MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Username.Focus();
                return;
            }
            if (Username.Text.Trim(' ').Length == 0)
            {
                MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Password.Focus();
                return;
            }
            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
                ModCommonClasses.cmd.CommandText = "SELECT RTRIM(UserID),RTRIM(Password) FROM tbl_login where UserType = @d1 and Name = @d2 and Password=@d3 and Active='Yes'";
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", combo_type.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Username.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", ModFunc.Encrypt(Password.Text));
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                if (ModCommonClasses.rdr.Read())
                {
                    ModCommonClasses.con = new SqlConnection(ModCS.cs);
                    ModCommonClasses.con.Open();
                    ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
                    ModCommonClasses.cmd.CommandText = "SELECT usertype FROM tbl_login where UserType=@d4 and Name=@d5 and Password=@d6";
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d4", combo_type.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Username.Text);
                    ModCommonClasses.cmd.Parameters.AddWithValue("@d6", ModFunc.Encrypt(Password.Text));
                    ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                    if (ModCommonClasses.rdr.Read())
                    {

                    }
                    if (ModCommonClasses.rdr != null)
                    {
                        ModCommonClasses.rdr.Close();
                    }
                    if (ModCommonClasses.con.State == ConnectionState.Open)
                    {
                        ModCommonClasses.con.Close();
                    }

                   
                    string st = "Successfully logged in";
                    ModFunc.LogFunc(Username.Text, st);
                    this.Hide();
                    Dashboard ss = new Dashboard();
                    ss.Show();
                    
                    ss.lblUser.Text = Username.Text;
                    ss.lblUserType.Text = combo_type.Text;
                }
                else
                {
                    Interaction.MsgBox("Login is Failed...Try again !", MsgBoxStyle.Critical, "Login Denied");
                    Username.Text = "";
                    Password.Text = "";
                    Username.Focus();
                }
                ModCommonClasses.cmd.Dispose();
                ModCommonClasses.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = Username;
            Username.Focus();

            combo_type.SelectedIndex = 0;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo, "Exit System") == MsgBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btn_login.PerformClick();

            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void frmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }
    }
}
