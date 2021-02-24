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
    public partial class frmHareketler : Form
    {
        public frmHareketler()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlDataAdapter da;
        DataTable dt;

        //Firma Harketler listesini çekme
        void FirmaHareketListele()
        {
            dt = new DataTable();
            da = new SqlDataAdapter("Execute FirmaHareketler", bag.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        //Musteri hareketler listesini çekme
        void MusteriHareketListele()
        {
            dt = new DataTable();
            da = new SqlDataAdapter("Execute MusteriHareketler", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void frmHareketler_Load(object sender, EventArgs e)
        {
            FirmaHareketListele();

            MusteriHareketListele();
        }
    }
}
