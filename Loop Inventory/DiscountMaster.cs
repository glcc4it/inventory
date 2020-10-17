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
    public partial class DiscountMaster : Form
    {
        public DiscountMaster()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_DiscountName.Text == "")
            {
                MessageBox.Show("Please Enter Discount Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_DiscountName.Focus();
                return;
            }


            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string ct = "select DiscountName from tbl_discount where DiscountName='" + txt_DiscountName.Text + "'";

                ModCommonClasses.cmd = new SqlCommand(ct);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader();

                if (ModCommonClasses.rdr.Read())
                {
                    MessageBox.Show("DiscountName Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_DiscountName.Text = "";
                    txt_DiscountName.Focus();


                    if (ModCommonClasses.rdr != null)
                    {
                        ModCommonClasses.rdr.Close();
                    }
                    return;
                }

                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();

                string cb = "insert into tbl_discount(DiscountName,DiscountPercentage,Status) VALUES ('" + txt_DiscountName.Text + "' ,'" + txt_DiscountPercent.Text + "' , '" + combo_status.Text + "')";

                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.ExecuteReader();
                ModCommonClasses.con.Close();
                MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ModFunc.LogFunc(lblUser.Text, "Add the Discount '" + txt_DiscountName.Text + "' Having DiscountID '" + txtID.Text + "'");
                this.ActiveControl = txt_DiscountName;
                txt_DiscountName.Focus();
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

            ModCommonClasses.cmd.CommandText = "select * from tbl_discount";
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

            txt_DiscountName.Text = "";
            txt_DiscountPercent.Text = "";
            combo_status.Text = "--- Select Status---";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_DiscountName.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DiscountName.Focus();
                return;
            }

            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_discount set DiscountName=@d1,DiscountPercentage=@d2,Status=@d3 WHERE id=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtID.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_DiscountName.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_DiscountPercent.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d3", combo_status.Text);




                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the Discount '" + txt_DiscountName.Text + "' info";

                MessageBox.Show("Successfully Updated", "Discount Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the Discount '" + txt_DiscountName.Text + "' Having DiscountID '" + txtID.Text + "'");
                DisplayData();
                ClearData();
                this.ActiveControl = txt_DiscountName;
                txt_DiscountName.Focus();

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
                string cq = "delete from tbl_discount where id=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the Discount '" + txtID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = txt_DiscountName;
                    txt_DiscountName.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the Discount '" + txt_DiscountName.Text + "' Having DiscountID '" + txtID.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_DiscountName.Focus();
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

        private void DiscountMaster_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventory_DBDataSet.tbl_discount' table. You can move, or remove it, as needed.
            this.tbl_discountTableAdapter.Fill(this.inventory_DBDataSet.tbl_discount);

            this.ActiveControl = txt_DiscountName;
            txt_DiscountName.Focus();
        }

        private void dgw_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgw.Rows.Count > 0)
                {
                    DataGridViewRow dr = dgw.SelectedRows[0];

                    txtID.Text = dr.Cells[0].Value.ToString();

                    txt_DiscountName.Text = dr.Cells[1].Value.ToString();
                    txt_DiscountPercent.Text = dr.Cells[2].Value.ToString();

                    combo_status.Text = dr.Cells[3].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DiscountMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }
    }

}


