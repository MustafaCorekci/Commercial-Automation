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
    public partial class pbArcelik : Form
    {
        public pbArcelik()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;
        SqlDataAdapter da;
        SqlDataReader dr;

        //Textboxta kş verileri temizleme fonksiyonu
        void Temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTelefon.Text = "";
            txtTC.Text = "";
            txtMail.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtAdres.Text = "";
            txtGorev.Text = "";
            txtAd.Focus();
        }

        //Personel listesini çağırma fonksiyonu
        void PersonelListesi()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("Select * From tbl_Personeller Order By ID Asc", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //İller varilerini combobox'a çekme fonksiyonu
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

        //Seçilen ile göre ilçeleri combobox'a çekme kodu
        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void frmPersoneller_Load(object sender, EventArgs e)
        {
            PersonelListesi();
            SehirListesi();
            Temizle();
        }

        //Seçilen Verinin textbox veya combobox a verileri aktarma
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["Ad"].ToString();
                txtSoyad.Text = dr["Soyad"].ToString();
                txtTelefon.Text = dr["Telefon"].ToString();
                txtTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["Mail"].ToString();
                cmbil.Text = dr["il"].ToString();
                cmbilce.Text = dr["ilce"].ToString();
                txtAdres.Text = dr["Adres"].ToString();
                txtGorev.Text = dr["Gorev"].ToString();
            }
        }

        //Kaydetme işlemi
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("insert into tbl_Personeller (Ad,Soyad,Telefon,TC,Mail,il,ilce,Adres,Gorev) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtTelefon.Text);
            komut.Parameters.AddWithValue("@p4", txtTC.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbil.Text);
            komut.Parameters.AddWithValue("@p7", cmbilce.Text);
            komut.Parameters.AddWithValue("@p8", txtAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Personel Kaydı Başarılı Bir Şekilde Oluşturuldu", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PersonelListesi();
            Temizle();
        }

        //Güncelleme İşlemi
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Update tbl_Personeller set Ad=@p1, Soyad=@p2, Telefon=@p3, TC=@p4, Mail=@p5, il=@p6, ilce=@p7, Adres=@p8, Gorev=@p9 where ID=@p10", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtTelefon.Text);
            komut.Parameters.AddWithValue("@p4", txtTC.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbil.Text);
            komut.Parameters.AddWithValue("@p7", cmbilce.Text);
            komut.Parameters.AddWithValue("@p8", txtAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.Parameters.AddWithValue("@p10", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Başarılı Bir Şekilde Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PersonelListesi();
            Temizle();
        }

        //Silme İşlemi
        private void btnSil_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Delete From tbl_Personeller where ID=@p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Personel Kaydı Başarılı Bir Şekilde Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            PersonelListesi();
            Temizle();
        }

        //Temizleme İşlmei
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
