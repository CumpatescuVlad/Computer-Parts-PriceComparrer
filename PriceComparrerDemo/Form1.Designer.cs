namespace PriceComparrerDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchTab1 = new PriceComparrerDemo.SearchTab();
            this.SuspendLayout();
            // 
            // searchTab1
            // 
            this.searchTab1.AutoScroll = true;
            this.searchTab1.Location = new System.Drawing.Point(0, -3);
            this.searchTab1.Name = "searchTab1";
            this.searchTab1.Size = new System.Drawing.Size(1029, 508);
            this.searchTab1.TabIndex = 0;
            this.searchTab1.Load += new System.EventHandler(this.searchTab1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 500);
            this.Controls.Add(this.searchTab1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SearchTab searchTab1;
    }
}