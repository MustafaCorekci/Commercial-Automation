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
    public partial class frmStokDetay : Form
    {
        public frmStokDetay()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();

        public string urunAd;
        private void frmStokDetay_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_Urunler Where UrunAd = '" + urunAd + "'", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
