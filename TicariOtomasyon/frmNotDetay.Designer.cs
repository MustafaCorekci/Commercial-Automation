namespace TicariOtomasyon
{
    partial class frmNotDetay
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
            this.txtNot = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtNot
            // 
            this.txtNot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNot.Location = new System.Drawing.Point(0, 0);
            this.txtNot.Name = "txtNot";
            this.txtNot.ReadOnly = true;
            this.txtNot.Size = new System.Drawing.Size(796, 479);
            this.txtNot.TabIndex = 0;
            this.txtNot.Text = "";
            // 
            // frmNotDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(796, 479);
            this.Controls.Add(this.txtNot);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotDetay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Not Detay";
            this.Load += new System.EventHandler(this.frmNotDetay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtNot;
    }
}