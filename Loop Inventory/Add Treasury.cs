﻿using System;
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
    public partial class Add_Treasury : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Add_Treasury()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Treasury_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                SendKeys.Send("{TAB}");


            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {


                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Add_Treasury_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtTresuryName;
            txtTresuryName.Focus();
        }

        private void add1_Click(object sender, EventArgs e)
        {
            Account_Master ss = new Account_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }

        private void add2_Click(object sender, EventArgs e)
        {
            Currency_Master ss = new Currency_Master();
            ss.Show();
            ss.lblUser.Text = lblUser.Text;
        }
    }
}
