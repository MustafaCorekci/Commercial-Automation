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
using Microsoft.Reporting.WinForms;

namespace TicariOtomasyon
{
    public partial class frmRaporlar : Form
    {
        public frmRaporlar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();

        //Musteri raporlarını çekme
        public void MusteriRaporDoldurYenile()
        {
            try
            {
                this.reportMusteri.Reset();
                this.reportMusteri.LocalReport.ReportPath = (Application.StartupPath + "\\MusteriRapor.rdlc");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Musteriler", bag.baglanti());
                da.Fill(dt);
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                this.reportMusteri.LocalReport.DataSources.Clear();
                this.reportMusteri.LocalReport.DataSources.Add(rds);
                this.reportMusteri.LocalReport.Refresh();
                this.reportMusteri.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu" + ex.ToString() + "HATA");
            }
        }

        //Firma raporlarını çekme
        public void FirmaRaporDoldurYenile()
        {
            try
            {
                this.reportFirma.Reset();
                this.reportFirma.LocalReport.ReportPath = (Application.StartupPath + "\\FirmaRapor.rdlc");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Firmalar", bag.baglanti());
                da.Fill(dt);
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                this.reportFirma.LocalReport.DataSources.Clear();
                this.reportFirma.LocalReport.DataSources.Add(rds);
                this.reportFirma.LocalReport.Refresh();
                this.reportFirma.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu" + ex.ToString() + "HATA");
            }
        }

        //Gider raporlarını çekme
        public void GiderRaporDoldurYenile()
        {
            try
            {
                this.reportGider.Reset();
                this.reportGider.LocalReport.ReportPath = (Application.StartupPath + "\\GiderRapor.rdlc");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Giderler", bag.baglanti());
                da.Fill(dt);
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                this.reportGider.LocalReport.DataSources.Clear();
                this.reportGider.LocalReport.DataSources.Add(rds);
                this.reportGider.LocalReport.Refresh();
                this.reportGider.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu" + ex.ToString() + "HATA");
            }
        }

        //Personel raporlarını çekme 
        public void PersonelRaporDoldurYenile()
        {
            try
            {
                this.reportPersonel.Reset();
                this.reportPersonel.LocalReport.ReportPath = (Application.StartupPath + "\\PersonelRapor.rdlc");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Personeller", bag.baglanti());
                da.Fill(dt);
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                this.reportPersonel.LocalReport.DataSources.Clear();
                this.reportPersonel.LocalReport.DataSources.Add(rds);
                this.reportPersonel.LocalReport.Refresh();
                this.reportPersonel.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu" + ex.ToString() + "HATA");
            }
        }

        private void frmRaporlar_Load(object sender, EventArgs e)
        {
            MusteriRaporDoldurYenile();

            FirmaRaporDoldurYenile();

            GiderRaporDoldurYenile();

            PersonelRaporDoldurYenile();
        }

        //Musteri Raporunu yeileme işlemi
        private void reportMusteri_ReportRefresh(object sender, CancelEventArgs e)
        {
            MusteriRaporDoldurYenile();
        }

        //Firma Raporunu yeileme işlemi
        private void reportFirma_ReportRefresh(object sender, CancelEventArgs e)
        {
            FirmaRaporDoldurYenile();
        }

        //Gider Raporunu yeileme işlemi
        private void reportGider_ReportRefresh(object sender, CancelEventArgs e)
        {
            GiderRaporDoldurYenile();
        }

        //Personel Raporunu yeileme işlemi
        private void reportPersonel_ReportRefresh(object sender, CancelEventArgs e)
        {
            PersonelRaporDoldurYenile();
        }
    }
}
