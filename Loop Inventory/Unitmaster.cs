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
    public partial class Unitmaster : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public Unitmaster()
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
            if (txt_unit.Text == "")
            {
                MessageBox.Show("Please Enter Unit Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_unit.Focus();
                return;
            }


            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string ct = "select Unit_type from tbl_unitmaster where Unit_type='" + txt_unit.Text + "'";

                ModCommonClasses.cmd = new SqlCommand(ct);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();

                if (ModCommonClasses.rdr.Read())
                {
                    MessageBox.Show("Unit Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_unit.Text = "";
                    txt_unit.Focus();


                    if (ModCommonClasses.rdr != null)
                    {
                        ModCommonClasses.rdr.Close();
                    }
                    return;
                }

                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();

                string cb = "insert into tbl_unitmaster(Date,Unit_type) VALUES ('" + dateTimePicker1.Text + "' , '" + txt_unit.Text + "')";

                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteReader();
                ModCommonClasses.con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ModFunc.LogFunc(lblUser.Text, "Add the Unitname '" + txt_unit.Text + "' Having Unit ID '" + txtID.Text + "'");
                this.ActiveControl = txt_unit;
                txt_unit.Focus();
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

            ModCommonClasses.cmd.CommandText = "select * from tbl_unitmaster";
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
            dateTimePicker1.Text = "";
            txt_unit.Text = "";
        }

        private void Unitmaster_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_unitmaster' table. You can move, or remove it, as needed.
            this.tbl_unitmasterTableAdapter.Fill(this.inventory_DBDataSet.tbl_unitmaster);


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver;

            dataGridView1.EnableHeadersVisualStyles = false;

            this.ActiveControl = txt_unit;
            txt_unit.Focus();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_unit.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_unit.Focus();
                return;
            }

            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_unitmaster set Unit_type=@d1 WHERE Sno=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtID.Text);

               
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_unit.Text);
                




                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the Unit '" + txt_unit.Text + "' info";

                MessageBox.Show("Successfully Updated", "Unit Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the Unitname '" + txt_unit.Text + "' Having Unit ID '" + txtID.Text + "'");
                DisplayData();
                ClearData();
                this.ActiveControl = txt_unit;
                txt_unit.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];

                    txtID.Text = dr.Cells[0].Value.ToString();
                   
                    txt_unit.Text = dr.Cells[1].Value.ToString();
                   

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
                string cq = "delete from tbl_unitmaster where Sno=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the Unit '" + txtID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = txt_unit;
                    txt_unit.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the Unitname '" + txt_unit.Text + "' Having Unit ID '" + txtID.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_unit.Focus();
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

        private void txt_unit_KeyDown(object sender, KeyEventArgs e)
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