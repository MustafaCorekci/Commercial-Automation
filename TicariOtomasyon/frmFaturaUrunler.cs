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
    public partial class frmFaturaUrunler : Form
    {
        public frmFaturaUrunler()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_FaturaDetay where FaturaID='" + id + "'", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        public string id;

        private void frmFaturaUrunler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            frmFaturaUrunDuzenle frm = new frmFaturaUrunDuzenle();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                frm.UrunID = dr["FaturaUrunID"].ToString();
            }
            frm.ShowDialog();
        }
    }
}
