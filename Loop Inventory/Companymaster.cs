﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loop_Inventory
{
    public partial class Companymaster : Form
    {
        private string st1;
        bool drag = false;
        Point start_point = new Point(0, 0);


        public Companymaster()
        {
            InitializeComponent();
        }




        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Company_name.Text))
            {
                MessageBox.Show("Please Enter Company Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Company_name.Focus();
                return;
            }
           
            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string ct = "select count(*) from tbl_company Having count(*) >= 1";
                ModCommonClasses.cmd = new SqlCommand(ct);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                if (ModCommonClasses.rdr.Read())
                {
                    MessageBox.Show("Record Already Exists" + "\r\n" + "Please Update the Company Info", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (ModCommonClasses.rdr != null)
                    {
                        ModCommonClasses.rdr.Close();
                    }
                    return;
                }


                if (chkActive.Checked == true)
                    st1 = "Yes";
                else
                    st1 = "No";
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();

                string cb = "insert into tbl_company(CompanyName, Mailingname, Startwork, Accountyear, Addressline1,  Addressline2, Addressline3, Contact, Email, Website, Vatno, Capitalaccount, Basecurrencey, Currencycode, Footernotes, Image) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_Company_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_MailingName.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dateTimePicker2.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d5", txt_Address.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d6", txt_Address2.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d7", txt_Address3.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d8", txt_Contactno.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d9", txt_Email.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d10", txt_Website.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d11", txt_VatNumber.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d12", st1);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Combo_Currency.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Txt_CurrencyCode.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Txt_notes.Text);


                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox3.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d16", SqlDbType.Image);
                p.Value = data;
                ModCommonClasses.cmd.Parameters.Add(p);
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Added the Company '" + txt_Company_name.Text + "' info";
              
                MessageBox.Show("Successfully Saved", "Company Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
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

            ModCommonClasses.cmd.CommandText = "select * from tbl_company";
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
            txt_Company_name.Text = "";
            txt_MailingName.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            txt_Address.Text = "";
            txt_Address2.Text = "";

            txt_Address3.Text = "";
            txt_Contactno.Text = "";
            txt_Email.Text = "";


            txt_Website.Text = "";
            txt_VatNumber.Text = "";

            Combo_Currency.Text = "--- Select Currency---";

            Txt_CurrencyCode.Text = "";

            Txt_notes.Text = "";

            txt_VatNumber.Text = "";
            chkActive.Checked = false;

            pictureBox3.Image = null;



            txt_Company_name.Focus();
           
           
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }


       
        

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }


        

        private void Companymaster_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_company' table. You can move, or remove it, as needed.
            this.tbl_companyTableAdapter.Fill(this.inventory_DBDataSet.tbl_company);


            DisplayData();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;



            this.ActiveControl = txt_Company_name;
            txt_Company_name.Focus();



          

        }

       

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var _with1 = openFileDialog1;

                _with1.Filter = ("Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;
                //Reset the file name
                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void Companymaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox3.Image = null;
        }

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                    
                    txt_Company_name.Text = dr.Cells[1].Value.ToString();
                    txt_MailingName.Text = dr.Cells[2].Value.ToString();
                    dateTimePicker1.Text = dr.Cells[3].Value.ToString();
                    dateTimePicker1.Text = dr.Cells[4].Value.ToString();
                    txt_Address.Text = dr.Cells[5].Value.ToString();
                    txt_Address2.Text = dr.Cells[6].Value.ToString();
                    txt_Address3.Text = dr.Cells[7].Value.ToString();
                    txt_Contactno.Text = dr.Cells[8].Value.ToString();
                    txt_Email.Text = dr.Cells[9].Value.ToString();
                    txt_Website.Text = dr.Cells[10].Value.ToString();
                    txt_VatNumber.Text = dr.Cells[11].Value.ToString();
                    
                    Combo_Currency.Text = dr.Cells[13].Value.ToString();
                    Txt_CurrencyCode.Text = dr.Cells[14].Value.ToString();
                    Txt_notes.Text = dr.Cells[15].Value.ToString();




                    byte[] data = (byte[])dr.Cells[16].Value;
                    MemoryStream ms = new MemoryStream(data);
                    this.pictureBox3.Image = Image.FromStream(ms);
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

        private void panel27_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void panel27_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void panel27_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void txt_accountno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnSave.PerformClick();

            }
        }
    
}

}