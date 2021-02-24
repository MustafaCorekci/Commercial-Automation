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
    public partial class frmBankalar : Form
    {
        public frmBankalar()
        {
            InitializeComponent();
        }

        void BankaTemizle()
        {
            txtID.Text = "";
            txtBankaAd.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtSube.Text = "";
            txtIBAN.Text = "";
            txtHesapNo.Text = "";
            txtYetkili.Text = "";
            txtTelefon.Text = "";
            txtTarih.Text = "";
            txtHesapTur.Text = "";
            cmbFirmaAd.Properties.NullText = "Lütfen Firma Seçiniz";
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;
        SqlDataAdapter da;
        SqlDataReader dr;

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
        //Seçilen ile göre ilçeleri combovox'a çekme kodu
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
        
        //Firma tablosundaki ID,Ad değerlerini lookUpEdit aracına çekme
        void FirmaListesi()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("Select ID,Ad From tbl_Firmalar", bag.baglanti());
            da.Fill(dt);
            cmbFirmaAd.Properties.ValueMember = "ID";
            cmbFirmaAd.Properties.DisplayMember = "Ad";
            cmbFirmaAd.Properties.DataSource = dt;
        }

        //Bankalar tablosundaki verileri çekmek için kullanılan fonksiyon
        void BankaListesi()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("Execute BankaBilgileri", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //Seçilen Verinin textbox veya combobox a verileri aktarma
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtBankaAd.Text = dr["BankaAdi"].ToString();
                cmbil.Text = dr["il"].ToString();
                cmbilce.Text = dr["ilce"].ToString();
                txtSube.Text = dr["Sube"].ToString();
                txtIBAN.Text = dr["Iban"].ToString();
                txtHesapNo.Text = dr["HesapNo"].ToString();
                txtYetkili.Text = dr["Yetkili"].ToString();
                txtTelefon.Text = dr["Telefon"].ToString();
                txtTarih.Text = dr["Tarih"].ToString();
                txtHesapTur.Text = dr["HesapTuru"].ToString();
            }
        }

        private void frmBankalar_Load(object sender, EventArgs e)
        {
            SehirListesi();

            BankaListesi();

            FirmaListesi();

            BankaTemizle();
        }

        //Kayıt işlemleri
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                bag.baglanti();
                komut = new SqlCommand("insert into tbl_Bankalar (BankaAdi, il, ilce, Sube, Iban, HesapNo, Yetkili, Telefon, Tarih, HesapTuru, FirmaID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11) ", bag.baglanti());
                komut.Parameters.AddWithValue("@p1", txtBankaAd.Text);
                komut.Parameters.AddWithValue("@p2", cmbil.Text);
                komut.Parameters.AddWithValue("@p3", cmbilce.Text);
                komut.Parameters.AddWithValue("@p4", txtSube.Text);
                komut.Parameters.AddWithValue("@p5", txtIBAN.Text);
                komut.Parameters.AddWithValue("@p6", txtHesapNo.Text);
                komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
                komut.Parameters.AddWithValue("@p8", txtTelefon.Text);
                komut.Parameters.AddWithValue("@p9", txtTarih.Text);
                komut.Parameters.AddWithValue("@p10", txtHesapTur.Text);
                komut.Parameters.AddWithValue("@p11", cmbFirmaAd.EditValue);
                komut.ExecuteNonQuery();
                bag.baglanti().Close();
                MessageBox.Show("Banka Kayıtlara Başarılı Bir Şekilde Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BankaListesi();
                BankaTemizle();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Boş Alanları Kontrol Ediniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Banka Kayıt Güncelleme
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("update tbl_Bankalar set BankaAdi=@p1, il=@p2, ilce=@p3, Sube=@p4, Iban=@p5, HesapNo=@p6, Yetkili=@p7, Telefon=@p8, Tarih=@p9, HesapTuru=@p10, FirmaID=@p11 where ID=@p12",bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", cmbil.Text);
            komut.Parameters.AddWithValue("@p3", cmbilce.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", txtIBAN.Text);
            komut.Parameters.AddWithValue("@p6", txtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", txtTelefon.Text);
            komut.Parameters.AddWithValue("@p9", txtTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtHesapTur.Text);
            komut.Parameters.AddWithValue("@p11", cmbFirmaAd.EditValue);
            komut.Parameters.AddWithValue("@p12", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Banka Kayıtları Başarılı Bir Şekilde Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BankaListesi();
            BankaTemizle();
        }

        //Banka Kayıt Silme
        private void btnSil_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Delete From tbl_Bankalar where ID=@p1",bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Banka Kayıtları Başarılı Bir Şekilde Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            BankaListesi();
            BankaTemizle();
        }

        //Textbox yada comboboaxdaki verileri temizleme
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            BankaTemizle();
        }
    }
}
