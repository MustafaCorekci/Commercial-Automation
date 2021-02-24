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
    public partial class frmNotlar : Form
    {
        public frmNotlar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;
        SqlDataAdapter da;

        void NotTemizle()
        {
            txtID.Text = "";
            txtTarih.Text = "";
            txtSaat.Text = "";
            txtBaslik.Text = "";
            txtDetay.Text = "";
            txtOlusturan.Text = "";
            txtHitap.Text = "";
            txtTarih.Focus();
        }

        //Notları Veri tabanında çekme işlemi
        void NotListesi()
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("Select * From tbl_Notlar Order By ID Asc", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //Nota çift tıklanınca geniş ekranda görme
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            frmNotDetay frm = new frmNotDetay();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                frm.metin = dr["Detay"].ToString();
            }
            frm.Show();
        }
        
        //griddeki veriler, textboxa çekme işlmei
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            txtID.Text = dr["ID"].ToString();
            txtTarih.Text = dr["Tarih"].ToString();
            txtSaat.Text = dr["Saat"].ToString();
            txtBaslik.Text = dr["Baslik"].ToString();
            txtDetay.Text = dr["Detay"].ToString();
            txtOlusturan.Text = dr["Olusturan"].ToString();
            txtHitap.Text = dr["Hitap"].ToString();
        }

        private void frmNotlar_Load(object sender, EventArgs e)
        {
            NotListesi();

            NotTemizle();
        }

        //Not ekleme
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("insert into tbl_Notlar (Tarih ,Saat ,Baslik ,Detay ,Olusturan ,Hitap) values (@p1 ,@p2 ,@p3 ,@p4 ,@p5 ,@p6)", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTarih.Text);
            komut.Parameters.AddWithValue("@p2", txtSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", txtDetay.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Not Sisteme Kaydedildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NotListesi();
            NotTemizle();
        }

        //Not güncelleme
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Update tbl_Notlar set Tarih=@p1 ,Saat=@p2 ,Baslik=@p3 ,Detay=@p4 ,Olusturan=@p5 ,Hitap=@p6 where ID=@p7", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTarih.Text);
            komut.Parameters.AddWithValue("@p2", txtSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", txtDetay.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.Parameters.AddWithValue("@p7", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Not Sistemde Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NotListesi();
            NotTemizle();
        }

        //Not Silme
        private void btnSil_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Delete From tbl_Notlar where ID=@p1", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Not Sistemden Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            NotListesi();
            NotTemizle();
        }

        //textboxları temizleme
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            NotTemizle();
        }
    }
}
