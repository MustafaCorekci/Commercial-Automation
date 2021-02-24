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
    public partial class frmStoklar : Form
    {
        public frmStoklar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select UrunAd,Sum(Adet) As 'Kalan' From tbl_Urunler Group By UrunAd", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //Charta stok miktarını listeleme
        void StokMiktarGoruntule()
        {
            bag.baglanti();
           SqlCommand komut = new SqlCommand("Select UrunAd,Sum(Adet) As 'Miktar' From tbl_Urunler Group By UrunAd", bag.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            bag.baglanti().Close();
        }

        //Charta firma şehir sayısını çekme
        void FirmaSehirGoruntule()
        {
            bag.baglanti();
            SqlCommand komut = new SqlCommand("Select il,Count(*) From tbl_Firmalar Group By il", bag.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            bag.baglanti().Close();
        }

        private void frmStoklar_Load(object sender, EventArgs e)
        {
            Listele();

            StokMiktarGoruntule();

            FirmaSehirGoruntule();
        }

        //stok tablomuzdaki stokaların detaylarını listeleme
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmStokDetay frm = new frmStokDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.urunAd = dr["UrunAd"].ToString();
            }

            frm.ShowDialog();
        }
    }
}
