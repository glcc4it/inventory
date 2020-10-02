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
    public partial class Logs : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        SqlDataReader rdr = null;
        public Logs()
        {
            InitializeComponent();
        }



        

        private void Logs_Load(object sender, EventArgs e)
        {
           
            GetData();

            dgw.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;

            dgw.EnableHeadersVisualStyles = false;
        }


        private void GetData()
        {
            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                ModCommonClasses.cmd = new SqlCommand("SELECT RTRIM(UserID),Date,RTRIM(Operation) from Logs order by Date", ModCommonClasses.con);
                rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dgw.Rows.Clear();
                while ((rdr.Read() == true))
                    dgw.Rows.Add(rdr[0], rdr[1], rdr[2]);
                ModCommonClasses.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                ModCommonClasses.cmd = new SqlCommand("SELECT RTRIM(UserID),Date,RTRIM(Operation) from Logs where Date >=@d1 and Date < @d2 order by Date", ModCommonClasses.con);
                ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date;
                ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1);
                rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dgw.Rows.Clear();
                while ((rdr.Read() == true))
                    dgw.Rows.Add(rdr[0], rdr[1], rdr[2]);
                ModCommonClasses.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                ModCommonClasses.con.Open();
                string ct = "delete from Logs";
                ModCommonClasses.cmd = new SqlCommand(ct);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    ModCommonClasses.con = new SqlConnection(ModCS.cs);
                    ModCommonClasses.con.Open();
                    string st = "Deleted the All Logs Till Date '" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + "'";
                    ModFunc.LogFunc(lblUser.Text, st);
                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    GetData();
                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                ModCommonClasses.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnTestConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpDateFrom.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            dtpDateTo.CustomFormat = "dd/MM/yyyy";
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel46_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void panel46_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void panel46_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }

}
