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
    public partial class Categorymaster : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public Categorymaster()
        {
            InitializeComponent();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_cat_name.Text == "")
            {
                MessageBox.Show("Please Enter Category Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cat_name.Focus();
                return;
            }


            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string ct = "select Categoryname from tbl_category where Categoryname='" + txt_cat_name.Text + "'";

                ModCommonClasses.cmd = new SqlCommand(ct);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();
                
                if (ModCommonClasses.rdr.Read())
                {
                    MessageBox.Show("Category Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cat_name.Text = "";
                    txt_cat_name.Focus();


                    if (ModCommonClasses.rdr != null)
                    {
                        ModCommonClasses.rdr.Close();
                    }
                    return;
                }

                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();

                string cb = "insert into tbl_category(Categoryname,date,narration) VALUES ('" + txt_cat_name.Text + "' ,'" + txt_color.Text + "' , '" + combo_status.Text + "')";

                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteReader();
                ModCommonClasses.con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ModFunc.LogFunc(lblUser.Text, "Add the Category '" + txt_cat_name.Text + "' Having Category ID '" + txtID.Text + "'");
                this.ActiveControl = txt_cat_name;
                txt_cat_name.Focus();
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

            ModCommonClasses.cmd.CommandText = "select * from tbl_category";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            dgw.DataSource = dt;
            ModCommonClasses.con.Close();
        }
        //Clear Data 
        private void ClearData()
        {
            txt_color.Text = "";
            txt_cat_name.Text = "";
            combo_status.Text = "--- Select Status---";
        }

        private void Categorymaster_Load(object sender, EventArgs e)
        {
            
           

            


            this.ActiveControl = txt_cat_name;
            txt_cat_name.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_cat_name.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_cat_name.Focus();
                return;
            }

            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_category set Categoryname=@d1,date=@d2,narration=@d3 WHERE Sno=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_cat_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_color.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", combo_status.Text);
              


               
                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the Category '" + txt_cat_name.Text + "' info";

                MessageBox.Show("Successfully Updated", "Category Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the Category '" + txt_cat_name.Text + "' Having Category ID '" + txtID.Text + "'");
                DisplayData();
                ClearData();
                this.ActiveControl = txt_cat_name;
                txt_cat_name.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void ProductsGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
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
                string cq = "delete from tbl_category where Sno=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the Category '" + txtID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = txt_cat_name;
                    txt_cat_name.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the Category '" + txt_cat_name.Text + "' Having Category ID '" + txtID.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_cat_name.Focus();
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

         private void dgw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
         {
             try
             {
                 if (dgw.Rows.Count > 0)
                 {
                     DataGridViewRow dr = dgw.SelectedRows[0];

                     txtID.Text = dr.Cells[0].Value.ToString();
                     txt_cat_name.Text = dr.Cells[2].Value.ToString();

                     combo_status.Text = dr.Cells[3].Value.ToString();

                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

         }

         private void txt_cat_name_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter)
             {

                 btnSave.PerformClick();

             }
         }

         private void panel12_MouseDown(object sender, MouseEventArgs e)
         {
             drag = true;
             start_point = new Point(e.X, e.Y);

         }

         private void panel12_MouseMove(object sender, MouseEventArgs e)
         {
             if (drag)
             {


                 Point p = PointToScreen(e.Location);
                 this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

             }

         }

         private void panel12_MouseUp(object sender, MouseEventArgs e)
         {
             drag = false;
         }
    
}


}