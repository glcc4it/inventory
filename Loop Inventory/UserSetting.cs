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
    public partial class UserSetting : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public UserSetting()
        {
            InitializeComponent();
        }


        

        public void Filluser()
        {
            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string ct1 = "SELECT distinct RTRIM(Name) FROM tbl_login";
                ModCommonClasses.cmd = new SqlCommand(ct1);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                while (ModCommonClasses.rdr.Read())
                {
                    Cmb_field.Items.Add(ModCommonClasses.rdr[0]);
                }
                ModCommonClasses.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {

        }

        private void btnget_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel32_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void panel32_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void panel32_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void UserSetting_Load(object sender, EventArgs e)
        {
            Filluser();
            
        }
    }
}
