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
    public partial class Expense_Master : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Expense_Master()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_Expense_Type.Text != "")
            {

                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                ModCommonClasses.cmd = new SqlCommand("insert into tbl_ExpenseMaster(ExpenseType,Status,Notes) values(@ExpenseType,@Status,@Notes)", ModCommonClasses.con);

                ModCommonClasses.cmd.Parameters.AddWithValue("@ExpenseType", txt_Expense_Type.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Status", combo_Status.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@Notes", txt_des.Text);


                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();






                this.ActiveControl = txt_Expense_Type;
                txt_Expense_Type.Focus();

                MessageBox.Show("Record Inserted Successfully");
                ModFunc.LogFunc(lblUser.Text, "Save the ExpenseName '" + txt_Expense_Type.Text + "' Having ExpensesID '" + txtID.Text + "'");
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

            ModCommonClasses.cmd.CommandText = "select * from tbl_ExpenseMaster";
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

            txt_Expense_Type.Text = "";
            combo_Status.Text = "--- Select Status---";
            txt_des.Text = "NA";
        }

        private void Expense_Master_Load(object sender, EventArgs e)
        {
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_Expense_Type.Text == "")
            {
                MessageBox.Show("Please Select Record in Gridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Expense_Type.Focus();
                return;
            }

            try
            {
                ModCommonClasses.con = new SqlConnection(ModCS.cs);
                ModCommonClasses.con.Open();
                string cb = "Update tbl_ExpenseMaster set ExpenseType=@d1, Status=@d1, Notes=@d2 WHERE id=@id1";
                ModCommonClasses.cmd = new SqlCommand(cb);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;

                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", txtID.Text);

                ModCommonClasses.cmd.Parameters.AddWithValue("@d1", txt_Expense_Type.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", combo_Status.Text);
                ModCommonClasses.cmd.Parameters.AddWithValue("@d2", txt_des.Text);




                ModCommonClasses.cmd.ExecuteNonQuery();
                ModCommonClasses.con.Close();
                string st = "Updated the ExpenseName '" + txt_Expense_Type.Text + "' info";

                MessageBox.Show("Successfully Updated", "ExpenseName Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModFunc.LogFunc(lblUser.Text, "Updated the ExpenseName '" + txt_Expense_Type.Text + "' Having ExpenseID '" + txtID.Text + "'");
                DisplayData();
                ClearData();
                this.ActiveControl = txt_Expense_Type;
                txt_Expense_Type.Focus();

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
                string cq = "delete from tbl_ExpenseMaster where id=@id1";
                ModCommonClasses.cmd = new SqlCommand(cq);
                ModCommonClasses.cmd.Connection = ModCommonClasses.con;
                ModCommonClasses.cmd.Parameters.AddWithValue("@id1", (txtID.Text));
                RowsAffected = ModCommonClasses.cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    string st = "Deleted the ExpenseName '" + txtID.Text + "'";

                    MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayData();

                    ClearData();


                    this.ActiveControl = txt_Expense_Type;
                    txt_Expense_Type.Focus();
                    ModFunc.LogFunc(lblUser.Text, "Delete the ExpenseName '" + txt_Expense_Type.Text + "' Having ExpenseID '" + txtID.Text + "'");

                }
                else
                {
                    MessageBox.Show("No Record Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Expense_Type.Focus();
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

                    txt_Expense_Type.Text = dr.Cells[1].Value.ToString();
                    combo_Status.Text = dr.Cells[2].Value.ToString();

                    txt_des.Text = dr.Cells[3].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Expense_Master_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }

        private void Expense_Master_Load_1(object sender, EventArgs e)
        {
            this.ActiveControl = txt_Expense_Type;
            txt_Expense_Type.Focus();
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
