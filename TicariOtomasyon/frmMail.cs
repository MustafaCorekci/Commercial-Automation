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
using System.Net;
using System.Net.Mail;

namespace TicariOtomasyon
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }

        sqlBaglantisi bag = new sqlBaglantisi();

        void SirketMail()
        {
            bag.baglanti();
            SqlCommand komut = new SqlCommand("Select * From tbl_e_Posta", bag.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                SirketMailAdres = dr[0].ToString();
            }
            bag.baglanti().Close();
        }

        public string mail;
        public string SirketMailAdres;

        private void frmMail_Load(object sender, EventArgs e)
        {
            txtMailAdres.Text = mail;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            SirketMail();

            MailMessage mail = new MailMessage();
            SmtpClient istemci = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(SirketMailAdres.ToString(), "Mustafa ÇÖREKCİ");
            mail.To.Add(txtMailAdres.Text);
            mail.Subject = txtKonu.Text;
            mail.Body = txtMesaj.Text;

            istemci.Port = 587;
            istemci.Credentials = new NetworkCredential(SirketMailAdres.ToString(), "M10zxcvb.");
            istemci.EnableSsl = true;

            try
            {
                istemci.Send(mail);
                MessageBox.Show("Mail Gönderildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
