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
using System.Xml;

namespace TicariOtomasyon
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlDataAdapter da;
        DataTable dt;

        //Azalan stokları listeleme
        void AzalanStoklar()
        {
            dt = new DataTable();
            da = new SqlDataAdapter("Select UrunAd,sum(Adet) as 'Adet' From tbl_Urunler Group By UrunAd Having sum(Adet) <= 20 Order By sum(Adet)", bag.baglanti());
            da.Fill(dt);
            gridControlStoklar.DataSource = dt;
        }

        //Ajanda verilerini çekme
        void Ajanda()
        {
            dt = new DataTable();
            da = new SqlDataAdapter("Select top 10 Tarih,Saat,Baslik From tbl_Notlar Order By ID desc", bag.baglanti());
            da.Fill(dt);
            gridControlAjanda.DataSource = dt;
        }

        //Firma son 10 hareket listeleme
        void FirmaHareketListe()
        {
            dt = new DataTable();
            da = new SqlDataAdapter("Execute FirmaSon10Hareket", bag.baglanti());
            da.Fill(dt);
            gridControlFirmaHareket.DataSource = dt;
        }

        //Firma fihrist listeleme
        void FirmaFihrist()
        {
            dt = new DataTable();
            da = new SqlDataAdapter("Select Ad,Telefon1 From tbl_Firmalar", bag.baglanti());
            da.Fill(dt);
            gridControlFihrist.DataSource = dt;
        }

        //Haberleri çekme
        void Haberler()
        {
            XmlTextReader xmlOku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmlOku.Read())
            {
                if (xmlOku.Name == "title")
                {
                    listBoxHaberler.Items.Add(xmlOku.ReadString());
                }
            }
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            AzalanStoklar();

            Ajanda();

            FirmaHareketListe();

            FirmaFihrist();

            Haberler();

            //döviz kurlarını çekme
            webBrowserDoviz.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");

            //youtube çağırma
            webBrowserYoutube.Navigate("https://www.youtube.com/");
        }
    }
}
