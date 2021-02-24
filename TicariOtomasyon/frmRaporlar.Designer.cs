namespace TicariOtomasyon
{
    partial class frmRaporlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRaporlar));
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.reportMusteri = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.reportFirma = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.reportGider = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.reportPersonel = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.reportMusteri);
            this.xtraTabPage1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPage1.ImageOptions.SvgImage")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1582, 817);
            this.xtraTabPage1.Text = "Müşteri Raporları";
            // 
            // reportMusteri
            // 
            this.reportMusteri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportMusteri.Font = new System.Drawing.Font("Tahoma", 12F);
            this.reportMusteri.Location = new System.Drawing.Point(0, 0);
            this.reportMusteri.Name = "reportMusteri";
            this.reportMusteri.ServerReport.BearerToken = null;
            this.reportMusteri.Size = new System.Drawing.Size(1582, 817);
            this.reportMusteri.TabIndex = 0;
            this.reportMusteri.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportMusteri_ReportRefresh);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.reportFirma);
            this.xtraTabPage2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPage2.ImageOptions.SvgImage")));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1582, 817);
            this.xtraTabPage2.Text = "Firma Raporları";
            // 
            // reportFirma
            // 
            this.reportFirma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportFirma.Location = new System.Drawing.Point(0, 0);
            this.reportFirma.Name = "reportFirma";
            this.reportFirma.ServerReport.BearerToken = null;
            this.reportFirma.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportFirma.Size = new System.Drawing.Size(1582, 817);
            this.reportFirma.TabIndex = 1;
            this.reportFirma.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportFirma_ReportRefresh);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 10F);
            this.xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1584, 861);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage4,
            this.xtraTabPage5});
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.reportGider);
            this.xtraTabPage4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPage4.ImageOptions.SvgImage")));
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(1582, 817);
            this.xtraTabPage4.Text = "Gider Raporları";
            // 
            // reportGider
            // 
            this.reportGider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportGider.Location = new System.Drawing.Point(0, 0);
            this.reportGider.Name = "reportGider";
            this.reportGider.ServerReport.BearerToken = null;
            this.reportGider.Size = new System.Drawing.Size(1582, 817);
            this.reportGider.TabIndex = 1;
            this.reportGider.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportGider_ReportRefresh);
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.reportPersonel);
            this.xtraTabPage5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPage5.ImageOptions.SvgImage")));
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(1582, 817);
            this.xtraTabPage5.Text = "Personel Raporları";
            // 
            // reportPersonel
            // 
            this.reportPersonel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportPersonel.Location = new System.Drawing.Point(0, 0);
            this.reportPersonel.Name = "reportPersonel";
            this.reportPersonel.ServerReport.BearerToken = null;
            this.reportPersonel.Size = new System.Drawing.Size(1582, 817);
            this.reportPersonel.TabIndex = 1;
            this.reportPersonel.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportPersonel_ReportRefresh);
            // 
            // frmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "frmRaporlar";
            this.Text = "Raporlar";
            this.Load += new System.EventHandler(this.frmRaporlar_Load);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer reportMusteri;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private Microsoft.Reporting.WinForms.ReportViewer reportFirma;
        private Microsoft.Reporting.WinForms.ReportViewer reportGider;
        private Microsoft.Reporting.WinForms.ReportViewer reportPersonel;
        private System.Windows.Forms.BindingSource tbl_MusterilerBindingSource;
    }
}