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
    public partial class frmFaturaUrunDuzenle : Form
    {
        public frmFaturaUrunDuzenle()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;
        SqlDataReader dr;

        public string UrunID;

        private void frmFaturaUrunDuzenle_Load(object sender, EventArgs e)
        {
            txtUrunID.Text = UrunID;

            //Çift Tıkladığımız ürünün verilerinini textboxlara çekme işlemi
            bag.baglanti();
            komut = new SqlCommand("Select * From tbl_FaturaDetay where FaturaUrunID=@p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunID.Text);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtUrunAd.Text = dr[1].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtFiyat.Text = dr[3].ToString();
                txtTutar.Text = dr[4].ToString();
            }
            bag.baglanti().Close();
        }

        //Güncelleme işlemi
        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Update tbl_FaturaDetay set UrunAd=@p1 ,Fiyat=@p2 ,Miktar=@p3 ,Tutar=@p4 where FaturaUrunID=@p5", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtMiktar.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@p5", txtUrunID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Değişiklikler Kaydedildi","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        //Silme İşlemi
        private void btnBilgiSil_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Delete From tbl_FaturaDetay where FaturaUrunID=@p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Değişiklikler Kaydedildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        double miktar, fiyat, tutar;
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
    
    }
}
