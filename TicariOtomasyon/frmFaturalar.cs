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
    public partial class frmFaturalar : Form
    {
        public frmFaturalar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;
        SqlDataAdapter da;


        private void frmFaturalar_Load(object sender, EventArgs e)
        {
            FaturaListesi();

            FaturaBilgiTemizle();

            FirmaListele();

            PersonelListele();

            MusteriListele();
        }

        //*****************************************************************************************************************************//
        //
        //Fatura Bilgi Tablosu Kodaları
        //

        void FaturaBilgiTemizle()
        {
            txtSeri.Text = "";
            txtSiraNo.Text = "";
            txtTarih.Text = "";
            txtSaat.Text = "";
            txtVergiDaire.Text = "";
            txtAlici.Text = "";
            txtT_Eden.Text = "";
            txtT_Alan.Text = "";
            txtSeri.Focus();
        }

        //FaturaBilgilerindeki tablo verilerini çekme fonksiyonu
        void FaturaListesi()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("Select * From  tbl_FaturaBilgi Order By FaturaBilgiID Asc", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //Fatura bilgilerini ilgili texbox lara doldurma işlemi
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["FaturaBilgiID"].ToString();
                txtSeri.Text = dr["Seri"].ToString();
                txtSiraNo.Text = dr["SiraNo"].ToString();
                txtTarih.Text = dr["Tarih"].ToString();
                txtSaat.Text = dr["Saat"].ToString();
                txtVergiDaire.Text = dr["VergiDaire"].ToString();
                txtAlici.Text = dr["Alici"].ToString();
                txtT_Eden.Text = dr["TeslimEden"].ToString();
                txtT_Alan.Text = dr["TeslimAlan"].ToString();

                txtFaturaID.Text = dr["FaturaBilgiID"].ToString();
            }
        }

        //Kesilen Faturanın üzerine çift tıkladığımızda faturanın detayını görmek için yazılan kod
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            frmFaturaUrunler frm = new frmFaturaUrunler();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                frm.id = dr["FaturaBilgiID"].ToString();
            }
            frm.ShowDialog();
        }
        
        //Fatura Bilgi Kayıt işlemi
        private void btnBilgiKaydet_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("insert into tbl_FaturaBilgi (Seri ,SiraNo ,Tarih ,Saat ,VergiDaire ,Alici ,TeslimEden ,TeslimAlan) values (@p1 ,@p2 ,@p3 ,@p4 ,@p5 ,@p6 ,@p7 ,@p8)", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtSeri.Text);
            komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            komut.Parameters.AddWithValue("@p3", txtTarih.Text);
            komut.Parameters.AddWithValue("@p4", txtSaat.Text);
            komut.Parameters.AddWithValue("@p5", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@p6", txtAlici.Text);
            komut.Parameters.AddWithValue("@p7", txtT_Eden.Text);
            komut.Parameters.AddWithValue("@p8", txtT_Alan.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Fatura Başarılı Bir Şekilde Oluşturuldu", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FaturaListesi();
            FaturaBilgiTemizle();
        }

        //Fatura bilgilerini guncelleme
        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Update tbl_FaturaBilgi set Seri=@p1 ,SiraNo=@p2 ,Tarih=@p3 ,Saat=@p4 ,VergiDaire=@p5 ,Alici=@p6 ,TeslimEden=@p7 ,TeslimAlan=@p8 where FaturaBilgiID=@p9",bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtSeri.Text);
            komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            komut.Parameters.AddWithValue("@p3", txtTarih.Text);
            komut.Parameters.AddWithValue("@p4", txtSaat.Text);
            komut.Parameters.AddWithValue("@p5", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@p6", txtAlici.Text);
            komut.Parameters.AddWithValue("@p7", txtT_Eden.Text);
            komut.Parameters.AddWithValue("@p8", txtT_Alan.Text);
            komut.Parameters.AddWithValue("@p9", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Fatura Bilgileri Başarılı Bir Şekilde Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FaturaListesi();
            FaturaBilgiTemizle();
        }

        //Fatura Bilgilerini Silme
        private void btnBilgiSil_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Delete From tbl_FaturaBilgi where FaturaBilgiID=@p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Fatura Bilgileri Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            FaturaListesi();
            FaturaBilgiTemizle();
        }

        //textbox daki verileri temizleme
        private void btnBilgiTemizle_Click(object sender, EventArgs e)
        {
            FaturaBilgiTemizle();
        }
        //*****************************************************************************************************************************//

        //Kod KARIŞMASIN

        //*****************************************************************************************************************************//
        //
        //Fatura Detay Tablosu İşlemleri
        //

        //

        void FaturaDetayTemizle()
        {
            txtUrunID.Text = "";
            txtUrunAd.Text = "";
            txtTutar.Text = "";
            txtMiktar.Text = "";
            txtFiyat.Text = "";
            txtUrunAd.Focus();
        }

        double miktar, tutar, fiyat;

        private void txtFiyat_EditValueChanged(object sender, EventArgs e)
        {
            if (txtFiyat.Text == "")
            {
                txtMiktar.Text = "0";
            }
            if (txtMiktar.Text != "" && txtFiyat.Text != "")
            {
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = fiyat * miktar;
                txtTutar.Text = tutar.ToString();
            }
        }

        private void txtMiktar_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMiktar.Text == "")
            {
                txtTutar.Text = "0";
            }
            if (txtFiyat.Text != "" && txtMiktar.Text != "")
            {
                miktar = Convert.ToDouble(txtMiktar.Text);
                fiyat = Convert.ToDouble(txtFiyat.Text);
                tutar = fiyat * miktar;
                txtTutar.Text = tutar.ToString();
            }
        }

        //lookedite firma adını id değerini çekme
        void FirmaListele()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("Select ID,Ad From tbl_Firmalar", bag.baglanti());
            da.Fill(dt);
            cmbFirmaAd.Properties.ValueMember = "ID";
            cmbFirmaAd.Properties.DisplayMember = "Ad";
            cmbFirmaAd.Properties.DataSource = dt;
        }

        //Lookedite personel ad id değerini çekme
        void PersonelListele()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("Select ID,Ad From tbl_Personeller", bag.baglanti());
            da.Fill(dt);
            cmbPersonel.Properties.ValueMember = "ID";
            cmbPersonel.Properties.DisplayMember = "Ad";
            cmbPersonel.Properties.DataSource = dt;
        }

        //Lookedite Müşteri ad id değerini çekme
        void MusteriListele()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("Select ID,Ad From tbl_Musteriler", bag.baglanti());
            da.Fill(dt);
            cmbMusteriAd.Properties.ValueMember = "ID";
            cmbMusteriAd.Properties.DisplayMember = "Ad";
            cmbMusteriAd.Properties.DataSource = dt;
        }

        private void cmbFaturaTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFaturaTur.Text == "Müşteri")
            {
                lblSecim.Text = "Müşteri";
                cmbFirmaAd.Visible = false;
                cmbMusteriAd.Visible = true;
            }
            if (cmbFaturaTur.Text == "Firma")
            {
                lblSecim.Text = "Firma";
                cmbFirmaAd.Visible = true;
                cmbMusteriAd.Visible = false;
            }
        }

        //Fatura Detay Kayıt işlemi
        private void btnDetayKaydet_Click(object sender, EventArgs e)
        {
            //Firmaysa kesilecek fatura
            if (cmbFaturaTur.Text == "Firma")
            {
                bag.baglanti();
                komut = new SqlCommand("insert into tbl_FaturaDetay (UrunAd ,Miktar ,Fiyat ,Tutar ,FaturaID) values (@p1 ,@p2 ,@p3 ,@p4 ,@p5)", bag.baglanti());
                komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                komut.Parameters.AddWithValue("@p2", txtMiktar.Text);
                komut.Parameters.AddWithValue("@p3", txtFiyat.Text);
                komut.Parameters.AddWithValue("@p4", txtTutar.Text);
                komut.Parameters.AddWithValue("@p5", txtFaturaID.Text);
                komut.ExecuteNonQuery();

                // firma Hareket tablosuna veri girişi
                komut = new SqlCommand("insert into tbl_FirmaHareketler (UrunID ,Adet ,Personel ,Firma ,Fiyat ,Toplam ,FaturaID ,Tarih) values (@h1 ,@h2 ,@h3 ,@h4 ,@h5 ,@h6 ,@h7 ,@h8)", bag.baglanti());
                komut.Parameters.AddWithValue("@h1", txtUrunID.Text);
                komut.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut.Parameters.AddWithValue("@h3", cmbPersonel.EditValue);
                komut.Parameters.AddWithValue("@h4", cmbFirmaAd.EditValue);
                komut.Parameters.AddWithValue("@h5", decimal.Parse(txtFiyat.Text));
                komut.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut.Parameters.AddWithValue("@h7", txtFaturaID.Text);
                komut.Parameters.AddWithValue("@h8", txtTarih.Text);
                komut.ExecuteNonQuery();

                //Stok sayısını azaltma
                komut = new SqlCommand("Update tbl_Urunler set adet = adet - @s1 where ID = @s2", bag.baglanti());
                komut.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut.Parameters.AddWithValue("@s2", txtUrunID.Text);
                komut.ExecuteNonQuery();
                bag.baglanti().Close();
                MessageBox.Show("Fatura Ürün Detayları Başarılı Bir Şekilde Oluşturuldu", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FaturaDetayTemizle();
            }

            //Müşteriyse kesilecek fatura
            if (cmbFaturaTur.Text == "Müşteri")
            {
                bag.baglanti();
                komut = new SqlCommand("insert into tbl_FaturaDetay (UrunAd ,Miktar ,Fiyat ,Tutar ,FaturaID) values (@p1 ,@p2 ,@p3 ,@p4 ,@p5)", bag.baglanti());
                komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                komut.Parameters.AddWithValue("@p2", txtMiktar.Text);
                komut.Parameters.AddWithValue("@p3", txtFiyat.Text);
                komut.Parameters.AddWithValue("@p4", txtTutar.Text);
                komut.Parameters.AddWithValue("@p5", txtFaturaID.Text);
                komut.ExecuteNonQuery();

                //müşteri Hareket tablosuna veri girişi
                komut = new SqlCommand("insert into tbl_MusteriHareketler (UrunID ,Adet ,Personel ,Musteri ,Fiyat ,Toplam ,FaturaID ,Tarih) values (@h1 ,@h2 ,@h3 ,@h4 ,@h5 ,@h6 ,@h7 ,@h8)", bag.baglanti());
                komut.Parameters.AddWithValue("@h1", txtUrunID.Text);
                komut.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut.Parameters.AddWithValue("@h3", cmbPersonel.EditValue);
                komut.Parameters.AddWithValue("@h4", cmbMusteriAd.EditValue);
                komut.Parameters.AddWithValue("@h5", decimal.Parse(txtFiyat.Text));
                komut.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut.Parameters.AddWithValue("@h7", txtFaturaID.Text);
                komut.Parameters.AddWithValue("@h8", txtTarih.Text);
                komut.ExecuteNonQuery();

                //Stok sayısını azaltma
                komut = new SqlCommand("Update tbl_Urunler set adet = adet - @s1 where ID = @s2", bag.baglanti());
                komut.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut.Parameters.AddWithValue("@s2", txtUrunID.Text);
                komut.ExecuteNonQuery();
                bag.baglanti().Close();
                MessageBox.Show("Fatura Ürün Detayları Başarılı Bir Şekilde Oluşturuldu", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FaturaDetayTemizle();
            }
        }

        //UrunID girildiği zaman urun detaylarrını bulma
        private void btnBul_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Select UrunAd,SatisFiyat From tbl_Urunler where ID = @p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunID.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    txtUrunAd.Text = dr[0].ToString();
                    txtFiyat.Text = dr[1].ToString();
                }
            }
            bag.baglanti().Close();
        }

        //*****************************************************************************************************************************//
    }
}
