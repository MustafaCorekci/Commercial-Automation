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
    public partial class frmFirmalar : Form
    {
        public frmFirmalar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;
        SqlDataReader dr;

        //textboxları temizleme
        void FirmaTemizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtYetkiliGorev.Text = "";
            txtYetkili.Text = "";
            txtYetkiliTC.Text = "";
            txtSektor.Text = "";
            txtTelefon1.Text = "";
            txtTelefon2.Text = "";
            txtTelefon3.Text = "";
            txtMail.Text = "";
            txtFax.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtVergiDaire.Text = "";
            txtAdres.Text = "";
            txtKod1.Text = "";
            txtKod2.Text = "";
            txtKod3.Text = "";
            txtAd.Focus();
        }

        //listele
        void FirmaListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Firmalar Order By ID Asc", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //combobox'a il verilerini çekme
        void SehirListesi()
        {
            bag.baglanti();
            komut = new SqlCommand("Select Sehir From tbl_iller", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bag.baglanti().Close();
        }
        
        //combobax'ta seçilen ile göre ilçeleri getirme
        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Text = "";
            cmbilce.Properties.Items.Clear();

            komut = new SqlCommand("Select ilce from tbl_ilceler where sehir=@p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[0]);
            }
            bag.baglanti().Close();
        }

        //Firmalara verilecek olan kodların açıklma verilerini çekme
        void FirmaKodAciklamalar()
        {
            bag.baglanti();

            komut = new SqlCommand("Select FirmaKod1 From tbl_Kodlar", bag.baglanti());
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rtxtKod1.Text = dr[0].ToString();
            }
            bag.baglanti().Close();
        }

        //gridvievden verileri textboxlara çekme
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["Ad"].ToString();
                txtYetkiliGorev.Text = dr["YetkiliStatu"].ToString();
                txtYetkili.Text = dr["YetkiliAdSoyad"].ToString();
                txtYetkiliTC.Text = dr["YetkiliTC"].ToString();
                txtSektor.Text = dr["Sektor"].ToString();
                txtTelefon1.Text = dr["Telefon1"].ToString();
                txtTelefon2.Text = dr["Telefon2"].ToString();
                txtTelefon3.Text = dr["Telefon3"].ToString();
                txtMail.Text = dr["Mail"].ToString();
                txtFax.Text = dr["Fax"].ToString();
                cmbil.Text = dr["il"].ToString();
                cmbilce.Text = dr["ilce"].ToString();
                txtVergiDaire.Text = dr["VergiDaire"].ToString();
                txtAdres.Text = dr["Adres"].ToString();
            }
        }

        private void frmFirmalar_Load(object sender, EventArgs e)
        {
            FirmaListele();
            SehirListesi();
            FirmaKodAciklamalar();
            FirmaTemizle();
        }

        //firmayı ekleme
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand("insert into tbl_Firmalar (Ad,YetkiliStatu,YetkiliAdSoyad,YetkiliTC,Sektor,Telefon1,Telefon2,Telefon3,Mail,Fax,il,ilce,VergiDaire,Adres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", txtYetkiliTC.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", txtTelefon1.Text);
            komut.Parameters.AddWithValue("@p7", txtTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", txtTelefon3.Text);
            komut.Parameters.AddWithValue("@p9", txtMail.Text);
            komut.Parameters.AddWithValue("@p10", txtFax.Text);
            komut.Parameters.AddWithValue("@p11", cmbil.Text);
            komut.Parameters.AddWithValue("@p12", cmbilce.Text);
            komut.Parameters.AddWithValue("@p13", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@p14", txtAdres.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Firma Sisteme Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListele();
            FirmaTemizle();
        }

        //firmayı bilgilerini silme
        private void btnSil_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Delete From tbl_Firmalar Where ID = @p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Firma Listeden Silinidi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            FirmaListele();
            FirmaTemizle();
        }

        //firma bilgilerini güncelleme 
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Update tbl_Firmalar set Ad=@p1, YetkiliStatu=@p2, YetkiliAdSoyad=@p3, YetkiliTC=@p4, Sektor=@p5, Telefon1=@p6, Telefon2=@p7, Telefon3=@p8, Mail=@p9, Fax=@p10, il=@p11, ilce=@p12, VergiDaire=@p13, Adres=@p14 Where ID=@p18",bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", txtYetkiliTC.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", txtTelefon1.Text);
            komut.Parameters.AddWithValue("@p7", txtTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", txtTelefon3.Text);
            komut.Parameters.AddWithValue("@p9", txtMail.Text);
            komut.Parameters.AddWithValue("@p10", txtFax.Text);
            komut.Parameters.AddWithValue("@p11", cmbil.Text);
            komut.Parameters.AddWithValue("@p12", cmbilce.Text);
            komut.Parameters.AddWithValue("@p13", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@p14", txtAdres.Text);
            komut.Parameters.AddWithValue("@p18", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Firma Bilgileri Başarılı Bir Şekilde Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListele();
            FirmaTemizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FirmaTemizle();
        }
    }
}
