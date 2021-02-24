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
    public partial class frmMusteriler : Form
    {
        public frmMusteriler()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;
        SqlDataReader dr;

        void Temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTelefon1.Text = "";
            txtTelefon2.Text = "";
            txtMail.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtAdres.Text = "";
            txtVergiDaire.Text = "";
            txtTC.Text = "";
            txtAd.Focus();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["Ad"].ToString();
                txtSoyad.Text = dr["Soyad"].ToString();
                txtTelefon1.Text = dr["Telefon1"].ToString();
                txtTelefon2.Text = dr["Telefon2"].ToString();
                txtTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["Mail"].ToString();
                cmbil.Text = dr["il"].ToString();
                cmbilce.Text = dr["ilce"].ToString();
                txtAdres.Text = dr["Adres"].ToString();
                txtVergiDaire.Text = dr["VergiDaire"].ToString();
            }
        }

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Musteriler Order By ID Asc", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

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

        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            Listele();
            SehirListesi();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("insert into tbl_Musteriler (Ad,Soyad,Telefon1,Telefon2,TC,Mail,il,ilce,Adres,VergiDaire) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", txtTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", txtTC.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cmbil.Text);
            komut.Parameters.AddWithValue("@p8", cmbilce.Text);
            komut.Parameters.AddWithValue("@p9", txtAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergiDaire.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Müşteri Sisteme Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Update tbl_Musteriler set Ad=@p1, soyad=@p2, Telefon1=@p3, Telefon2=@p4, TC=@p5, Mail=@p6, il=@p7, ilce=@p8, Adres=@p9, VergiDaire=@p10 where ID=@p11", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", txtTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", txtTC.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cmbil.Text);
            komut.Parameters.AddWithValue("@p8", cmbilce.Text);
            komut.Parameters.AddWithValue("@p9", txtAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@p11", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Ürün Başarılı Bir Şekilde Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Delete From tbl_Musteriler where ID = @p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Müşteri Kaydı Başarılı Bir Şekilde Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
