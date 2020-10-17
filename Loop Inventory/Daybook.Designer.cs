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
            this.txt_TaxPercentage = new System.Windows.Forms.TextBox();
            this.combo_Brand = new System.Windows.Forms.ComboBox();
            this.txt_ProductnameArabic = new System.Windows.Forms.TextBox();
            this.txt_Barcode1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_TaxPercentage
            // 
            this.txt_TaxPercentage.BackColor = System.Drawing.Color.MintCream;
            this.txt_TaxPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TaxPercentage.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.txt_TaxPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_TaxPercentage.Location = new System.Drawing.Point(55, 190);
            this.txt_TaxPercentage.Name = "txt_TaxPercentage";
            this.txt_TaxPercentage.Size = new System.Drawing.Size(133, 25);
            this.txt_TaxPercentage.TabIndex = 979;
            // 
            // combo_Brand
            // 
            this.combo_Brand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_Brand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_Brand.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.combo_Brand.FormattingEnabled = true;
            this.combo_Brand.Location = new System.Drawing.Point(229, 175);
            this.combo_Brand.Name = "combo_Brand";
            this.combo_Brand.Size = new System.Drawing.Size(114, 25);
            this.combo_Brand.TabIndex = 999;
            this.combo_Brand.Text = "-Select Brand-";
            // 
            // txt_ProductnameArabic
            // 
            this.txt_ProductnameArabic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_ProductnameArabic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ProductnameArabic.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.txt_ProductnameArabic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_ProductnameArabic.Location = new System.Drawing.Point(137, 93);
            this.txt_ProductnameArabic.Name = "txt_ProductnameArabic";
            this.txt_ProductnameArabic.Size = new System.Drawing.Size(133, 25);
            this.txt_ProductnameArabic.TabIndex = 976;
            // 
            // txt_Barcode1
            // 
            this.txt_Barcode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_Barcode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Barcode1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.txt_Barcode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Barcode1.Location = new System.Drawing.Point(409, 174);
            this.txt_Barcode1.Name = "txt_Barcode1";
            this.txt_Barcode1.Size = new System.Drawing.Size(180, 25);
            this.txt_Barcode1.TabIndex = 975;
            // 
            // Daybook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1029, 539);
            this.Controls.Add(this.txt_TaxPercentage);
            this.Controls.Add(this.combo_Brand);
            this.Controls.Add(this.txt_ProductnameArabic);
            this.Controls.Add(this.txt_Barcode1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Daybook";
            this.Text = "Daybook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }














        #endregion
        private System.Windows.Forms.TextBox txt_TaxPercentage;
        private System.Windows.Forms.ComboBox combo_Brand;
        private System.Windows.Forms.TextBox txt_ProductnameArabic;
        private System.Windows.Forms.TextBox txt_Barcode1;
    }
}