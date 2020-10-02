namespace Loop_Inventory
{
    partial class Daybook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label12 = new System.Windows.Forms.Label();
            this.txtcDirectDiscount = new System.Windows.Forms.TextBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcDefultdiscount = new System.Windows.Forms.TextBox();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel15.SuspendLayout();
            this.panel19.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(153, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 18);
            this.label12.TabIndex = 953;
            this.label12.Text = "Direct Discount:";
            // 
            // txtcDirectDiscount
            // 
            this.txtcDirectDiscount.BackColor = System.Drawing.Color.White;
            this.txtcDirectDiscount.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtcDirectDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcDirectDiscount.Location = new System.Drawing.Point(2, 2);
            this.txtcDirectDiscount.Name = "txtcDirectDiscount";
            this.txtcDirectDiscount.Size = new System.Drawing.Size(182, 25);
            this.txtcDirectDiscount.TabIndex = 0;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Gainsboro;
            this.panel15.Controls.Add(this.txtcDirectDiscount);
            this.panel15.Location = new System.Drawing.Point(266, 228);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(186, 29);
            this.panel15.TabIndex = 954;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(145, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 18);
            this.label11.TabIndex = 946;
            this.label11.Text = "Defult Discount%:";
            // 
            // txtcDefultdiscount
            // 
            this.txtcDefultdiscount.BackColor = System.Drawing.Color.White;
            this.txtcDefultdiscount.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtcDefultdiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcDefultdiscount.Location = new System.Drawing.Point(2, 2);
            this.txtcDefultdiscount.Name = "txtcDefultdiscount";
            this.txtcDefultdiscount.Size = new System.Drawing.Size(182, 25);
            this.txtcDefultdiscount.TabIndex = 0;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.Gainsboro;
            this.panel19.Controls.Add(this.txtcDefultdiscount);
            this.panel19.Location = new System.Drawing.Point(267, 188);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(186, 29);
            this.panel19.TabIndex = 952;
            // 
            // Daybook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 642);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel19);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Daybook";
            this.Text = "Daybook";
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtcDirectDiscount;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtcDefultdiscount;
        private System.Windows.Forms.Panel panel19;



    }
}