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
    public partial class Brand_Master : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Brand_Master()
        {
            InitializeComponent();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Brand_Master_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_BrandMaster' table. You can move, or remove it, as needed.
            this.tbl_BrandMasterTableAdapter.Fill(this.inventory_DBDataSet.tbl_BrandMaster);

            this.ActiveControl = txt_BrandName;
            txt_BrandName.Focus();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_BrandName.Text == "")
            {
                MessageBox.Show("Please Enter Brand Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_BrandName.Focus();
                return;
            }


            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string ct = "select BrandName from tbl_BrandMaster where BrandName='" + txt_BrandName.Text + "'";

                ModCommonClasses.cmd = new SqlCommand(ct);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();

                if (ModCommonClasses.rdr.Read())
                {
                    MessageBox.Show("Brand Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_BrandName.Text = "";
                    txt_BrandName.Focus();


                    if (ModCommonClasses.rdr != null)
                    {
                        ModCommonClasses.rdr.Close();
                    }
                    return;
                }

                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();

                string cb = "insert into tbl_BrandMaster(BrandName,Manufacturer,Status) VALUES ('" + txt_BrandName.Text + "' ,'" + txt_Manufacturer.Text + "' , '" + combo_status.Text + "')";

                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteReader();
                ModCommonClasses.con.Close();
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ModFunc.LogFunc(lblUser.Text, "Add the Brand '" + txt_BrandName.Text + "' Having Brand ID '" + txtID.Text + "'");
                this.ActiveControl = txt_BrandName;
                txt_BrandName.Focus();
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

            ModCommonClasses.cmd.CommandText = "select * from tbl_BrandMaster";
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
            txt_BrandName.Text = "";
            txt_Manufacturer.Text = "";
            combo_status.Text = "--- Select Status---";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_BrandName.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_BrandName.Focus();
                return;
            }

            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_BrandMaster set BrandName=@d1,Manufacturer=@d2,Status=@d3 WHERE id=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_BrandName.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_Manufacturer.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", combo_status.Text);




                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the Brand '" + txt_BrandName.Text + "' info";

                MessageBox.Show("Successfully Updated", "Brand Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the Brand '" + txt_BrandName.Text + "' Having Brand ID '" + txtID.Text + "'");
                DisplayData();
                ClearData();
                this.ActiveControl = txt_BrandName;
                txt_BrandName.Focus();

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
                string cq = "delete from tbl_BrandMaster where id=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the Brand '" + txtID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = txt_BrandName;
                    txt_BrandName.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the Brand '" + txt_BrandName.Text + "' Having Brand ID '" + txtID.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_BrandName.Focus();
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

        private void dgw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgw.Rows.Count > 0)
                {
                    DataGridViewRow dr = dgw.SelectedRows[0];

                    txtID.Text = dr.Cells[0].Value.ToString();
                    txt_BrandName.Text = dr.Cells[1].Value.ToString();
                    txt_Manufacturer.Text = dr.Cells[2].Value.ToString();
                    combo_status.Text = dr.Cells[3].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

