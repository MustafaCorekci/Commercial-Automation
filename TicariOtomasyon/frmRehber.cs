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
    public partial class frmRehber : Form
    {
        public frmRehber()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();

        private void frmRehber_Load(object sender, EventArgs e)
        {
            //Müşteri Bilgileri
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,Soyad,Telefon1,Telefon2,Mail From tbl_Musteriler", bag.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Firma Bilgileri
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select Ad,YetkiliAdSoyad,Telefon1,Telefon2,Telefon3,Mail,Fax From tbl_Firmalar", bag.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            frmMail frm = new frmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["Mail"].ToString();
            }
            frm.ShowDialog();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmMail frm = new frmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["Mail"].ToString();
            }
            frm.ShowDialog();
        }
    }
}
