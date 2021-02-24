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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();
        SqlCommand komut;
        SqlDataReader dr;

        private void pbCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGiris_MouseHover(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.Green;
            btnGiris.ForeColor = Color.White;
        }

        private void btnGiris_MouseLeave(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.White;
            btnGiris.ForeColor = Color.Black;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            bag.baglanti();
            komut = new SqlCommand("Select * From tbl_Admin Where Kullanici = @p1 and Sifre = @p2", bag.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullanici.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmAnaModul fr = new frmAnaModul();
                fr.kullanici = txtKullanici.Text;
                this.Hide();
                fr.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı Veya Şifre Hatalı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bag.baglanti().Close();
        }
    }
}
