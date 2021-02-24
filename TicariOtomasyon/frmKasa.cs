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

namespace TicariOtomasyon
{
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        void MusteriHareket()
        {
            dt = new DataTable();
            da = new SqlDataAdapter("Execute MusteriHareketler", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void FirmaHareket()
        {
            dt = new DataTable();
            da = new SqlDataAdapter("Execute FirmaHareketler", bag.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        void GiderListe()
        {
            dt = new DataTable();
            da = new SqlDataAdapter("Select * From tbl_Giderler  Order By ID asc", bag.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        public string ad;

        public void frmKasa_Load(object sender, EventArgs e)
        {
            MusteriHareket();

            FirmaHareket();

            GiderListe();


            bag.baglanti();

            //Aktif Kullanıcıyı Taşıma
            lblAktifKullanici.Text = ad;

            //Kasa toplamını hesaplama
            komut = new SqlCommand("Select sum(Tutar) From tbl_FaturaDetay", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblKasaToplam.Text = dr[0].ToString() +" TL";
            }

            //Son ayın faturaları toplamını hesaplama
            komut = new SqlCommand("Select (Elektrik + Su + Dogalgaz + Internet + Ekstra) From tbl_Giderler Order By ID asc", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblOdemeler.Text = dr[0].ToString() + " TL";
            }

            //Personel Maaşlarını Hesaplama
            komut = new SqlCommand("Select Maaslar From tbl_Giderler Order By ID asc", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblPersonelMaaslari.Text = dr[0].ToString() + " TL";
            }

            //Toplam Müşteri sayısı
            komut = new SqlCommand("Select count(*) From tbl_Musteriler", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblMüsteriSayisi.Text = dr[0].ToString();
            }

            //Toplam Firma sayısı
            komut = new SqlCommand("Select count(*) From tbl_Firmalar", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblFirmaSayisi.Text = dr[0].ToString();
            }

            //Müşteri sehir sayisi
            komut = new SqlCommand("Select count(Distinct(il)) From tbl_Musteriler", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblMusteriSehir.Text = dr[0].ToString();
            }

            //Firma Sehir Sayisi
            komut = new SqlCommand("Select count(Distinct(il)) From tbl_Firmalar", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblFirmaSehir.Text = dr[0].ToString();
            }

            //Personel Sayısı
            komut = new SqlCommand("Select Count(*) From tbl_Personeller", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblPersonelSayisi.Text = dr[0].ToString();
            }

            //Stok Sayısı
            komut = new SqlCommand("Select sum(Adet) From tbl_Urunler", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblStokSayisi.Text = dr[0].ToString();
            }
        }

        int sayac;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            //Elektrik
            if (sayac > 0 && sayac < 5)
            {
                chartFaturalar1.Series["AYLAR"].Points.Clear();
                groupFatura1.Text = "Elektrik";
                komut = new SqlCommand("Select top 4 Ay,Elektrik From tbl_Giderler Order By ID desc", bag.baglanti());
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartFaturalar1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
            }

            //Su
            if (sayac > 5 && sayac < 10)
            {
                chartFaturalar1.Series["AYLAR"].Points.Clear();
                groupFatura1.Text = "Su";
                komut = new SqlCommand("Select top 4 Ay,Su From tbl_Giderler Order By ID desc", bag.baglanti());
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartFaturalar1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
            }

            //Dogalgaz
            if (sayac > 10 && sayac < 15)
            {
                chartFaturalar1.Series["AYLAR"].Points.Clear();
                groupFatura1.Text = "Doğalgaz";
                komut = new SqlCommand("Select top 4 Ay,Dogalgaz From tbl_Giderler Order By ID desc", bag.baglanti());
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartFaturalar1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
            }

            //internet
            if (sayac > 15 && sayac < 20)
            {
                chartFaturalar1.Series["AYLAR"].Points.Clear();
                groupFatura1.Text = "İnternet";
                komut = new SqlCommand("Select top 4 Ay,Internet From tbl_Giderler Order By ID desc", bag.baglanti());
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartFaturalar1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
            }

            //Ekstra
            if (sayac > 20 && sayac < 25)
            {
                chartFaturalar1.Series["AYLAR"].Points.Clear();
                groupFatura1.Text = "Ekstra";
                komut = new SqlCommand("Select top 4 Ay,Ekstra From tbl_Giderler Order By ID desc", bag.baglanti());
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartFaturalar1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
            }

            if (sayac == 26)
            {
                sayac = 0;
            }
        }

        int sayac2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;

            //Elektrik
            if (sayac2 > 0 && sayac2 < 5)
            {
                chartFaturalar2.Series["AYLAR"].Points.Clear();
                groupFatura2.Text = "İnternet";
                komut = new SqlCommand("Select top 4 Ay,Internet From tbl_Giderler Order By ID desc", bag.baglanti());
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartFaturalar2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
            }

            //Su
            if (sayac2 > 5 && sayac2 < 10)
            {
                chartFaturalar2.Series["AYLAR"].Points.Clear();
                groupFatura2.Text = "Ekstra";
                komut = new SqlCommand("Select top 4 Ay,Ekstra From tbl_Giderler Order By ID desc", bag.baglanti());
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartFaturalar2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
            }

            //Dogalgaz
            if (sayac2 > 10 && sayac2 < 15)
            {
                chartFaturalar2.Series["AYLAR"].Points.Clear();
                groupFatura2.Text = "Doğalgaz";
                komut = new SqlCommand("Select top 4 Ay,Dogalgaz From tbl_Giderler Order By ID desc", bag.baglanti());
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartFaturalar2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
            }

            //internet
            if (sayac2 > 15 && sayac2 < 20)
            {
                chartFaturalar2.Series["AYLAR"].Points.Clear();
                groupFatura2.Text = "Elektrik";
                komut = new SqlCommand("Select top 4 Ay,Elektrik From tbl_Giderler Order By ID desc", bag.baglanti());
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartFaturalar2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
            }

            //Ekstra
            if (sayac2 > 20 && sayac2 < 25)
            {
                chartFaturalar2.Series["AYLAR"].Points.Clear();
                groupFatura2.Text = "Su";
                komut = new SqlCommand("Select top 4 Ay,Su From tbl_Giderler Order By ID desc", bag.baglanti());
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartFaturalar2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
            }

            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}
