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
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;
        SqlDataReader dr;
        SqlDataAdapter da;

        string SirketMailAdres;

        //şirketin kayıtlı mail verisini çekme
        void SirketMailGetir()
        {
            bag.baglanti();
            komut = new SqlCommand("Select * From tbl_e_Posta", bag.baglanti());
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                SirketMailAdres = dr[0].ToString();
            }
            bag.baglanti().Close();
        }

        //sisteme kayıtlı kişilerin verilerini çekme
        void KullaniciListe()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("Select Kullanici,Sifre From tbl_Admin", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            txtKullanici.Text = null;
            txtSifre.Text = null;
            txtKullanici.Focus();
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            KullaniciListe();

            SirketMailGetir();

            Temizle();

            btnMailDegistir.Enabled = false;
            txtMail.Enabled = false;
            txtMail.Text = SirketMailAdres;
        }

        private void checkBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                btnMailDegistir.Enabled = true;
                txtMail.Enabled = true;
            }
            else
            {
                btnMailDegistir.Enabled = false;
                txtMail.Enabled = false;
            }
        }

        //Mail Adresini değiştirme
        private void btnMailDegistir_Click(object sender, EventArgs e)
        {
            if (txtMail.Text != "")
            {
                txtMail.Enabled = false;
                btnMailDegistir.Enabled = false;
                checkBox.Checked = false;

                bag.baglanti();
                komut = new SqlCommand("Update tbl_e_Posta set e_Posta = @p1", bag.baglanti());
                komut.Parameters.AddWithValue("@p1", txtMail.Text);
                komut.ExecuteNonQuery();
                bag.baglanti().Close();
                MessageBox.Show("Şirket e-Postası Başarılı Bir Şekilde Değiştirildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Yeni Mail Adresini Giriniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //sisteme yeni kişi tanımlama
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKullanici.Text != "" && txtSifre.Text != "")
            {
                bag.baglanti();
                komut = new SqlCommand("insert into tbl_Admin (Kullanici ,Sifre) values (@p1 ,@p2)", bag.baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullanici.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.ExecuteNonQuery();
                bag.baglanti().Close();
                MessageBox.Show("Kişi Sisteme Başarılı Bir Şekilde Tanımlandı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KullaniciListe();
                Temizle();
            }
            else
            {
                MessageBox.Show("Lütfen Metin Kutularını Kontrol Edin", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Sistemdeki kayıtlı kişiyi güncelleme
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtKullanici.Text != "" && txtSifre.Text != "")
            {
                bag.baglanti();
                komut = new SqlCommand("Update tbl_Admin set Kullanici = @p1 , Sifre = @p2 Where Kullanici = @p1", bag.baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullanici.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.ExecuteNonQuery();
                bag.baglanti().Close();
                MessageBox.Show("Kişi Başarılı Bir Şekilde Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KullaniciListe();
                Temizle();
            }
            else
            {
                MessageBox.Show("Lütfen Güncellenicek Kişinin Bilgilerini Girin","HATA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        //Sistemdeki kayıtlı kişiyi silme
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtKullanici.Text != "")
            {
                bag.baglanti();
                komut = new SqlCommand("Delete From tbl_Admin Where Kullanici = @p1", bag.baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullanici.Text);
                komut.ExecuteNonQuery();
                bag.baglanti().Close();
                MessageBox.Show("Kişi Başarılı Bir Şekilde Sistemden Silidi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KullaniciListe();
                Temizle();
            }
            else
            {
                MessageBox.Show("Lütfen Sileceğiniz Kaydın Adını Girin", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
