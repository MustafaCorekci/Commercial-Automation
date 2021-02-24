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
    public partial class frmUrunler : Form
    {
        public frmUrunler()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;

        void temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            txtYil.Text = "";
            numAdet.Value = 0;
            txtAlisFiyat.Text = "";
            txtSatisFiyat.Text = "";
            txtDetay.Text = "";
            txtAd.Focus();
        }

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select* From tbl_Urunler Order By ID Asc", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["UrunAd"].ToString();
                txtMarka.Text = dr["Marka"].ToString();
                txtModel.Text = dr["Model"].ToString();
                txtYil.Text = dr["Yil"].ToString();
                numAdet.Value = int.Parse(dr["Adet"].ToString());
                txtAlisFiyat.Text = dr["AlisFiyat"].ToString();
                txtSatisFiyat.Text = dr["SatisFiyat"].ToString();
                txtDetay.Text = dr["Detay"].ToString();
            }
        }

        private void frmUrunler_Load(object sender, EventArgs e)
        {
            Listele();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("insert into tbl_urunler (UrunAd,Marka,Model,Yil,Adet,AlisFiyat,SatisFiyat,Detay) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", txtYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(numAdet.Value.ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p8", txtDetay.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Ürün Başarılı Bir Şekilde Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Update tbl_Urunler set UrunAd=@p1, Marka=@p2, Model=@p3, Yil=@p4, Adet=@p5, AlisFiyat=@p6, SatisFiyat=@p7, Detay=@p8 where ID=@p9",bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", txtYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(numAdet.Value.ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p8", txtDetay.Text);
            komut.Parameters.AddWithValue("@p9", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Ürün Başarılı Bir Şekilde Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Delete From tbl_Urunler where ID = @p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Ürün Başarılı Bir Şekilde Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
