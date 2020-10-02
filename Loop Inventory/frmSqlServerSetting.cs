using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace Loop_Inventory
{
    public partial class frmSqlServerSetting : Form
    {
        private string st;
        private string SqlConnStr;


        bool drag = false;
        Point start_point = new Point(0, 0);

       
        public frmSqlServerSetting()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (lblSet.Text == "Main Form")
                this.Close();
            else if (MessageBox.Show("Do you want to close the application????", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                System.Environment.Exit(0);
        }

        private void btnCreateDemoDataDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbServerName.Text == "")
                {
                    Interaction.MsgBox("Please Select/Enter Server Name", MsgBoxStyle.Information);
                    cmbServerName.Focus();
                    return;
                }
                if (cmbAuthentication.SelectedIndex == 1)
                {
                    if (txtUserName.Text.Length == 0)
                    {
                        Interaction.MsgBox("please enter user name", MsgBoxStyle.Information);
                        txtUserName.Focus();
                        return;
                    }
                    if (txtPassword.Text.Length == 0)
                    {
                        Interaction.MsgBox("please enter password", MsgBoxStyle.Information);
                        txtPassword.Focus();
                        return;
                    }
                }
                Cursor = Cursors.WaitCursor;
                Timer2.Enabled = true;
                if (cmbAuthentication.SelectedIndex == 0)
                    ModCommonClasses.con = new SqlConnection("Data source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;");
                if (cmbAuthentication.SelectedIndex == 1)
                    ModCommonClasses.con = new SqlConnection("Data Source=" + cmbServerName.Text + ";Initial Catalog=master;User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text + "");
                ModCommonClasses.con.Open();
                if ((ModCommonClasses.con.State == ConnectionState.Open))
                {
                    if (MessageBox.Show("It will create the DB and configure the sql server, Do you want to proceed????", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (StreamWriter sw = new StreamWriter(Application.StartupPath + @"\SQLSettings.dat"))
                        {
                            if (cmbAuthentication.SelectedIndex == 0)
                            {
                                sw.WriteLine("Data Source=" + cmbServerName.Text + ";Initial Catalog=Inventory_DB;Integrated Security=True");
                                sw.Close();
                            }
                            if (cmbAuthentication.SelectedIndex == 1)
                            {
                                sw.WriteLine("Data Source=" + cmbServerName.Text + ";Initial Catalog=Inventory_DB;User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text + "");
                                sw.Close();
                            }
                            CreateDB();
                        }
                    }
                    else
                        System.Environment.Exit(0);
                }
                MessageBox.Show("DB has been created and SQL Server setting has been saved successfully..." + Constants.vbCrLf + "Application will be closed,Please start it again", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to sql server" + Constants.vbCrLf, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if ((ModCommonClasses.con.State == ConnectionState.Open))
                    ModCommonClasses.con.Close();
            }
        }

        public void CreateDB()
        {
            try
            {
                ModCommonClasses.con = new SqlConnection("Data source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;");
                ModCommonClasses.con.Open();
                string cb2 = "Select * from sysdatabases where name='Inventory_DB'";
                ModCommonClasses.cmd = new SqlCommand(cb2);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                if (ModCommonClasses.rdr.Read())
                {
                    ModCommonClasses.con = new SqlConnection("Data source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;");
                    ModCommonClasses.con.Open();
                    string cb1 = "Drop Database Inventory_DB";
                    ModCommonClasses.cmd = new SqlCommand(cb1);
                    ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                    ModCommonClasses.cmd.ExecuteNonQuery();
                    ModCommonClasses.con.Close();
                    try
                    {
                        ModCommonClasses.con = new SqlConnection("Data source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;");
                        ModCommonClasses.con.Open();
                        string cb = "Create Database Inventory_DB";
                        ModCommonClasses.cmd = new SqlCommand(cb);
                        ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                        ModCommonClasses.cmd.ExecuteNonQuery();
                        ModCommonClasses.con.Close();
                        using (StreamReader sr = new StreamReader(Application.StartupPath + @"\DBScript.sql"))
                        {
                            st = sr.ReadToEnd();
                            Server server = new Server(new ServerConnection(ModCommonClasses.con));
                            server.ConnectionContext.ExecuteNonQuery(st);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ModCommonClasses.con = new SqlConnection("Data source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;");
                    ModCommonClasses.con.Open();
                    string cb3 = "Create Database Inventory_DB";
                    ModCommonClasses.cmd = new SqlCommand(cb3);
                    ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                    ModCommonClasses.cmd.ExecuteNonQuery();
                    ModCommonClasses.con.Close();
                    using (StreamReader sr = new StreamReader(Application.StartupPath + @"\DBScript.sql"))
                    {
                        st = sr.ReadToEnd();
                        Server server = new Server(new ServerConnection(ModCommonClasses.con));
                        server.ConnectionContext.ExecuteNonQuery(st);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if ((ModCommonClasses.con.State == ConnectionState.Open))
                    ModCommonClasses.con.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer2.Enabled = true;
                DataTable dataTable = SmoApplication.EnumAvailableSqlServers(true);
                cmbServerName.ValueMember = "Name";
                cmbServerName.DataSource = dataTable;
                string serverName = cmbServerName.SelectedValue.ToString();
                Server server = new Server(serverName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry unable to find SQL Server instance" + Constants.vbCrLf + "If you have installed SQL Server then enter name of SQL Server instance manually", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAuthentication.SelectedIndex == 0)
            {
                txtUserName.ReadOnly = true;
                txtPassword.ReadOnly = true;
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
            if (cmbAuthentication.SelectedIndex == 1)
            {
                txtUserName.ReadOnly = false;
                txtPassword.ReadOnly = false;
            }
        }

        private void cmbServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAuthentication.Enabled = true;
            cmbAuthentication.SelectedIndex = 0;
        }

        public void Reset()
        {
            txtPassword.Text = "";
            txtUserName.Text = "";
            cmbServerName.Text = "";
            cmbAuthentication.SelectedIndex = 0;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (cmbServerName.Text == "")
            {
                Interaction.MsgBox("Please select/enter Server Name", MsgBoxStyle.Information);
                cmbServerName.Focus();
                return;
            }
            if (cmbAuthentication.SelectedIndex == 1)
            {
                if (txtUserName.Text.Length == 0)
                {
                    Interaction.MsgBox("please enter user name", MsgBoxStyle.Information);
                    txtUserName.Focus();
                    return;
                }
                if (txtPassword.Text.Length == 0)
                {
                    Interaction.MsgBox("please enter password", MsgBoxStyle.Information);
                    txtPassword.Focus();
                    return;
                }
            }
            Cursor = Cursors.WaitCursor;
            Timer2.Enabled = true;
            SqlConnection SqlConn = new SqlConnection();

            if (cmbAuthentication.SelectedIndex == 0)
                SqlConnStr = "Data Source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True";
            if (cmbAuthentication.SelectedIndex == 1)
                SqlConnStr = "Data Source=" + cmbServerName.Text + ";Initial Catalog=master;User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text + "";
            if (SqlConn.State == ConnectionState.Closed)
            {
                SqlConn.ConnectionString = SqlConnStr;
                try
                {
                    SqlConn.Open();
                    MessageBox.Show("Succsessfull DB Connnection", "DB Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid DB SqlConnnection" + Constants.vbCrLf, "DB Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer2.Enabled = false;
        }



        public void CreateBlankDB()
    {
        try
        {
            ModCommonClasses.con = new SqlConnection("Data source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True");
            ModCommonClasses.con.Open();
            string cb2 = "Select * from sysdatabases where name='Inventory_DB'";
            ModCommonClasses.cmd = new SqlCommand(cb2);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
            if (ModCommonClasses.rdr.Read())
            {
                ModCommonClasses.con = new SqlConnection("Data source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True");
                ModCommonClasses.con.Open();
                string cb1 = "Drop Database Inventory_DB";
                ModCommonClasses.cmd = new SqlCommand(cb1);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                ModCommonClasses.con = new SqlConnection("Data source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True");
                ModCommonClasses.con.Open();
                string cb = "Create Database Inventory_DB";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                using (StreamReader sr = new StreamReader(Application.StartupPath + @"\BlankDBscript.sql"))
                {
                    st = sr.ReadToEnd();
                    Server server = new Server(new ServerConnection(ModCommonClasses.con));
                    server.ConnectionContext.ExecuteNonQuery(st);
                }
            }
            else
            {
                ModCommonClasses.con = new SqlConnection("Data source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True");
                ModCommonClasses.con.Open();
                string cb3 = "Create Database Inventory_DB";
                ModCommonClasses.cmd = new SqlCommand(cb3);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                using (StreamReader sr = new StreamReader(Application.StartupPath + @"\BlankDBscript.sql"))
                {
                    st = sr.ReadToEnd();
                    Server server = new Server(new ServerConnection(ModCommonClasses.con));
                    server.ConnectionContext.ExecuteNonQuery(st);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if ((ModCommonClasses.con.State == ConnectionState.Open))
                ModCommonClasses.con.Close();
        }


    }

        private void btnBlankDataDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbServerName.Text == "")
                {
                    Interaction.MsgBox("Please Select/Enter Server Name", MsgBoxStyle.Information);
                    cmbServerName.Focus();
                    return;
                }
                if (cmbAuthentication.SelectedIndex == 1)
                {
                    if (txtUserName.Text.Length == 0)
                    {
                        Interaction.MsgBox("please enter user name", MsgBoxStyle.Information);
                        txtUserName.Focus();
                        return;
                    }
                    if (txtPassword.Text.Length == 0)
                    {
                        Interaction.MsgBox("please enter password", MsgBoxStyle.Information);
                        txtPassword.Focus();
                        return;
                    }
                }
                Cursor = Cursors.WaitCursor;
                Timer2.Enabled = true;
                if (cmbAuthentication.SelectedIndex == 0)
                    ModCommonClasses.con = new SqlConnection("Data source=" + cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True");
                if (cmbAuthentication.SelectedIndex == 1)
                    ModCommonClasses.con = new SqlConnection("Data Source=" + cmbServerName.Text + ";Initial Catalog=master;User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text + ";MultipleActiveResultSets=True");
                ModCommonClasses.con.Open();
                if ((ModCommonClasses.con.State == ConnectionState.Open))
                {
                    if (MessageBox.Show("It will create the DB and configure the sql server, Do you want to proceed????", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (StreamWriter sw = new StreamWriter(Application.StartupPath + @"\SQLSettings.dat"))
                        {
                            if (cmbAuthentication.SelectedIndex == 0)
                            {
                                sw.WriteLine("Data Source=" + cmbServerName.Text + ";Initial Catalog=Inventory_DB;Integrated Security=True;MultipleActiveResultSets=True");
                                sw.Close();
                            }
                            if (cmbAuthentication.SelectedIndex == 1)
                            {
                                sw.WriteLine("Data Source=" + cmbServerName.Text + ";Initial Catalog=Inventory_DB;User ID=" + txtUserName.Text + ";Password=" + txtPassword.Text + ";MultipleActiveResultSets=True");
                                sw.Close();
                            }
                            CreateBlankDB();
                            MessageBox.Show("DB has been created and SQL Server setting has been saved successfully..." + Constants.vbCrLf + "Application will be closed,Please start it again", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Environment.Exit(0);
                        }
                    }
                    else
                        System.Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to sql server" + Constants.vbCrLf, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if ((ModCommonClasses.con.State == ConnectionState.Open))
                    ModCommonClasses.con.Close();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

    }


}