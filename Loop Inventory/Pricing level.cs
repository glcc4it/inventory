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
    public partial class Pricing_level : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public Pricing_level()
        {
            InitializeComponent();
        }

        private void Pricing_level_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_pricinglevel' table. You can move, or remove it, as needed.
            this.tbl_pricinglevelTableAdapter.Fill(this.inventory_DBDataSet.tbl_pricinglevel);


            this.ActiveControl = txt_price_name;
            txt_price_name.Focus();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_price_name.Text != "")
            {

                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                ModCommonClasses.cmd = new SqlCommand("insert into tbl_pricinglevel(Pricingname,Date,narration) values(@Pricingname,@Date,@narration)", ModCommonClasses.con);

                ModCommonClasses.cmd.Parameters.AddWithValue("@Pricingname", txt_price_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@narration", txt_des.Text);


                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();






                this.ActiveControl = txt_price_name;
                txt_price_name.Focus();

                MessageBox.Show("Record Inserted Successfully");
                ModFunc.LogFunc(lblUser.Text, "Save the Pricinglevel '" + txt_price_name.Text + "' Having Pricinglevel ID '" + txtID.Text + "'");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }
        //Display Data in DataGridView
        private void DisplayData()
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();

            ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand();
            ModCommonClasses.cmd.CommandType = CommandType.Text;

            ModCommonClasses.cmd.CommandText = "select * from tbl_pricinglevel";
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

            txt_price_name.Text = "";
            dateTimePicker1.Text = "";
            txt_des.Text = "NA";
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_price_name.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_price_name.Focus();
                return;
            }

            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_pricinglevel set Pricingname=@d1, narration=@d2 WHERE Sno=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtID.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_price_name.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_des.Text);




                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the Pricinglevel '" + txt_price_name.Text + "' info";

                MessageBox.Show("Successfully Updated", "Pricinglevel Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the Pricinglevel '" + txt_price_name.Text + "' Having Pricinglevel ID '" + txtID.Text + "'");
                DisplayData();
                ClearData();
                this.ActiveControl = txt_price_name;
                txt_price_name.Focus();

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
                string cq = "delete from tbl_pricinglevel where Sno=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the Pricinglevel '" + txtID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = txt_price_name;
                    txt_price_name.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the Pricinglevel '" + txt_price_name.Text + "' Having Pricinglevel ID '" + txtID.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_price_name.Focus();
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
                    txt_price_name.Text = dr.Cells[1].Value.ToString();
                    txt_des.Text = dr.Cells[2].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_price_name_KeyDown(object sender, KeyEventArgs e)
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
