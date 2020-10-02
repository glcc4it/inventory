using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loop_Inventory
{
    public partial class Splash_Screen : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);

        public Splash_Screen()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(Application.StartupPath + @"\SQLSettings.dat"))
                {
                    ProgressBar1.Visible = true;
                    ProgressBar1.Value = ProgressBar1.Value + 2;
                    if ((ProgressBar1.Value == 10))
                        lblSet.Text = "Reading modules..";
                    else if ((ProgressBar1.Value == 20))
                        lblSet.Text = "Turning on modules.";
                    else if ((ProgressBar1.Value == 40))
                        lblSet.Text = "Starting modules..";
                    else if ((ProgressBar1.Value == 60))
                        lblSet.Text = "Loading modules..";
                    else if ((ProgressBar1.Value == 80))
                        lblSet.Text = "Done Loading modules..";
                    else if ((ProgressBar1.Value == 100))
                    {
                        frmLogin ss = new frmLogin();
                        ss.Show();
                        Timer1.Enabled = false;
                        this.Hide();
                    }
                }
                else
                {
                    ProgressBar1.Visible = true;
                    ProgressBar1.Value = ProgressBar1.Value + 2;
                    if ((ProgressBar1.Value == 10))
                        lblSet.Text = "Reading modules..";
                    else if ((ProgressBar1.Value == 20))
                        lblSet.Text = "Turning on modules.";
                    else if ((ProgressBar1.Value == 40))
                        lblSet.Text = "Starting modules..";
                    else if ((ProgressBar1.Value == 60))
                        lblSet.Text = "Loading modules..";
                    else if ((ProgressBar1.Value == 80))
                        lblSet.Text = "Done Loading modules..";
                    else if ((ProgressBar1.Value == 100))
                    {

                        frmSqlServerSetting ss = new frmSqlServerSetting();
                        ss.Show();
                        Timer1.Enabled = false;
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!");
                System.Environment.Exit(0);
            }
        }

        private void Splash_Screen_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void Splash_Screen_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void Splash_Screen_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
