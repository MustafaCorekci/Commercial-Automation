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
    public partial class frmGiderler : Form
    {
        public frmGiderler()
        {
            InitializeComponent();
        }

        SqlCommand komut;
        SqlDataAdapter da;
        sqlBaglantisi bag = new sqlBaglantisi();

        //Textbox veya combobox taki verileri temizle fonksiyonu
        void GiderTemizle()
        {
            txtID.Text = "";
            cmbAy.Text = "";
            cmbYil.Text = "";
            txtElektrik.Text = "";
            txtSu.Text = "";
            txtDogalgaz.Text = "";
            txtInternet.Text = "";
            txtMaaslar.Text = "";
            txtEkstra.Text = "";
            txtNotlar.Text = "";
            cmbAy.Focus();
        }

        //Giderler tablosundaki verileri çekme fonksiyonu
        void GiderListesi()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("Select * From tbl_Giderler Order By ID Asc", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //Seçilen satırdaki verileri textbox yada combobox a aktarma fonksiyonu
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                cmbAy.Text = dr["Ay"].ToString();
                cmbYil.Text = dr["Yil"].ToString();
                txtElektrik.Text = dr["Elektrik"].ToString();
                txtSu.Text = dr["Su"].ToString();
                txtDogalgaz.Text = dr["Dogalgaz"].ToString();
                txtInternet.Text = dr["Internet"].ToString();
                txtMaaslar.Text = dr["Maaslar"].ToString();
                txtEkstra.Text = dr["Ekstra"].ToString();
                txtNotlar.Text = dr["Notlar"].ToString();
            }
        }

        private void frmGiderler_Load(object sender, EventArgs e)
        {
            GiderListesi();
            GiderTemizle();
        }

        //kaydetme işlemi
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                bag.baglanti();
                komut = new SqlCommand("insert into tbl_Giderler (Ay,Yil,Elektrik,Su,Dogalgaz,Internet,Maaslar,Ekstra,Notlar) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bag.baglanti());
                komut.Parameters.AddWithValue("@p1", cmbAy.Text);
                komut.Parameters.AddWithValue("@p2", cmbYil.Text);
                komut.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
                komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
                komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
                komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
                komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaslar.Text));
                komut.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
                komut.Parameters.AddWithValue("@p9", txtNotlar.Text);
                komut.ExecuteNonQuery();
                bag.baglanti().Close();
                MessageBox.Show("Bu Ay ki Gider Başarılı Bir Şekilde Sisteme Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GiderListesi();
                GiderTemizle();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Faturalar Yerine Girdiğiniz Alanı Kontrol Ediniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Güncelleme işlemi
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                bag.baglanti();
                komut = new SqlCommand("Update tbl_Giderler set Ay=@p1, Yil=@p2, Elektrik=@p3, Su=@p4, Dogalgaz=@p5, Internet=@p6, Maaslar=@p7, Ekstra=@p8, Notlar=@p9 where ID=@p10", bag.baglanti());
                komut.Parameters.AddWithValue("@p1", cmbAy.Text);
                komut.Parameters.AddWithValue("@p2", cmbYil.Text);
                komut.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
                komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
                komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
                komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
                komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaslar.Text));
                komut.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
                komut.Parameters.AddWithValue("@p9", txtNotlar.Text);
                komut.Parameters.AddWithValue("@p10", txtID.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Gider Başarılı Bir Şekilde Sistemde Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GiderTemizle();
                GiderListesi();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Faturalar Yerine Girdiğiniz Alanı Kontrol Ediniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Silme işlemi
        private void btnSil_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Delete From tbl_Giderler where ID=@p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Gider Tablosundaki Veri Başarıyla Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GiderListesi();
            GiderTemizle();
        }

        //Temizleme işlemi
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            GiderTemizle();
        }
    }
}
