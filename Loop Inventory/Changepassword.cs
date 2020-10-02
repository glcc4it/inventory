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
    public partial class Changepassword : Form
    {
        public Changepassword()
        {
            InitializeComponent();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo, "Exit System") == MsgBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Changepassword_Load(object sender, EventArgs e)
        {
            combo_user_type.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd1 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd1.CommandType = CommandType.Text;

            ModCommonClasses.cmd1.CommandText = "SELECT *FROM tbl_login";
            ModCommonClasses.cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(ModCommonClasses.cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {


                combo_user_type.Items.Add(dr1["UserType"].ToString());

            }


            ModCommonClasses.con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
