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
    public partial class Rackmaster : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public Rackmaster()
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
            if (txt_rack_name.Text == "")
            {
                MessageBox.Show("Please enter rack name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_rack_name.Focus();
                return;
            }


            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string ct = "select rackname from tbl_rackmaster where rackname='" + txt_rack_name.Text + "'";

                ModCommonClasses.cmd = new SqlCommand(ct);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();

                if (ModCommonClasses.rdr.Read())
                {
                    MessageBox.Show("Rack Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_rack_name.Text = "";
                    txt_rack_name.Focus();


                    if (ModCommonClasses.rdr != null)
                    {
                        ModCommonClasses.rdr.Close();
                    }
                    return;
                }

                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();

                string cb = "insert into tbl_rackmaster(rackname,godown,narration) VALUES ('" + txt_rack_name.Text + "' ,'" + combo_godown.Text + "' , '" + txt_des.Text + "')";

                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteReader();
                ModCommonClasses.con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ModFunc.LogFunc(lblUser.Text, "Add the Rackname '" + txt_rack_name.Text + "' Having Rack ID '" + txtID.Text + "'");
                DisplayData();
                ClearData();

                this.ActiveControl = txt_rack_name;
                txt_rack_name.Focus();

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

            ModCommonClasses.cmd.CommandText = "select * from tbl_rackmaster";
            ModCommonClasses.cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ModCommonClasses.cmd);
            da.Fill(dt);
            ProductsGridView.DataSource = dt;
            ModCommonClasses.con.Close();
        }
        //Clear Data 
        private void ClearData()
        {
            txt_rack_name.Text = "";
            combo_godown.Text = "--- Select Godown---";
            txt_des.Text = "NA";
        }

        private void Rackmaster_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_rackmaster' table. You can move, or remove it, as needed.
            this.tbl_rackmasterTableAdapter.Fill(this.inventory_DBDataSet.tbl_rackmaster);
            


            ProductsGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;

            ProductsGridView.EnableHeadersVisualStyles = false;

            this.ActiveControl = txt_rack_name;
            txt_rack_name.Focus();




            combo_godown.Items.Clear();
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            ModCommonClasses.cmd1 = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd1.CommandType = CommandType.Text;

            ModCommonClasses.cmd1.CommandText = "SELECT *FROM tbl_godown";
            ModCommonClasses.cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(ModCommonClasses.cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {


                combo_godown.Items.Add(dr1["godownname"].ToString());

            }


            ModCommonClasses.con.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_rack_name.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_rack_name.Focus();
                return;
            }

            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_rackmaster set rackname=@d1, godown=@d2, narration=@d3 WHERE Sno=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtID.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_rack_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", combo_godown.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", txt_des.Text);




                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the Rackno '" + txt_rack_name.Text + "' info";

                MessageBox.Show("Successfully Updated", "Rack Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the Rackname '" + txt_rack_name.Text + "' Having Rack ID '" + txtID.Text + "'");
                DisplayData();
                ClearData();
                this.ActiveControl = txt_rack_name;
                txt_rack_name.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductsGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (ProductsGridView.Rows.Count > 0)
                {
                    DataGridViewRow dr = ProductsGridView.SelectedRows[0];

                    txtID.Text = dr.Cells[0].Value.ToString();
                    txt_rack_name.Text = dr.Cells[1].Value.ToString();
                    combo_godown.Text = dr.Cells[2].Value.ToString();
                    txt_des.Text = dr.Cells[3].Value.ToString();

                }
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
                string cq = "delete from tbl_rackmaster where Sno=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the Rackno '" + txtID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = txt_rack_name;
                    txt_rack_name.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the Rackno '" + txt_rack_name.Text + "' Having Rack ID '" + txtID.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_rack_name.Focus();
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

        private void panel9_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void panel9_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void panel9_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void combo_godown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnSave.PerformClick();

            }
        }

        private void Rackmaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }
}

}