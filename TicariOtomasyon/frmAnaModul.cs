using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyon
{
    public partial class frmAnaModul : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmAnaModul()
        {
            InitializeComponent();
        }

        public string kullanici;

        frmUrunler frm1;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm1 == null || frm1.IsDisposed)
            {
                frm1 = new frmUrunler();
                frm1.MdiParent = this;
                frm1.Show();
            }
        }

        frmMusteriler frm2;
        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new frmMusteriler();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        frmFirmalar frm3;
        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new frmFirmalar();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }

        pbArcelik frm4;
        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new pbArcelik();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }

        frmRehber frm5;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new frmRehber();
                frm5.MdiParent = this;
                frm5.Show();
            }
        }

        frmGiderler frm6;
        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6 == null || frm6.IsDisposed)
            {
                frm6 = new frmGiderler();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }

        frmBankalar frm7;
        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm7 == null ||frm7.IsDisposed)
            {
                frm7 = new frmBankalar();
                frm7.MdiParent = this;
                frm7.Show();
            }
        }

        frmFaturalar frm8;
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm8 == null || frm8.IsDisposed)
            {
                frm8 = new frmFaturalar();
                frm8.MdiParent = this;
                frm8.Show();
            }
        }

        frmNotlar frm9;
        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm9 == null || frm9.IsDisposed)
            {
                frm9 = new frmNotlar();
                frm9.MdiParent = this;
                frm9.Show();
            }
        }

        frmHareketler frm10;
        private void btnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm10 == null || frm10.IsDisposed)
            {
                frm10 = new frmHareketler();
                frm10.MdiParent = this;
                frm10.Show();
            }
        }

        frmRaporlar frm11;
        private void btnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm11 == null || frm11.IsDisposed)
            {
                frm11 = new frmRaporlar();
                frm11.MdiParent = this;
                frm11.Show();
            }
        }

        frmStoklar frm12;
        private void btnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm12 == null ||frm12.IsDisposed)
            {
                frm12 = new frmStoklar();
                frm12.MdiParent = this;
                frm12.Show();
            }
        }

        frmAyarlar frm13;
        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm13 = new frmAyarlar();
            frm13.ShowDialog();
        }

        frmKasa frm14;
        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm14 == null || frm14.IsDisposed)
            {
                frm14 = new frmKasa();
                frm14.ad = kullanici;
                frm14.MdiParent = this;
                frm14.Show();
            }
        }

        frmAnaSayfa frm15;
        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm15 == null || frm15.IsDisposed)
            {
                frm15 = new frmAnaSayfa();
                frm15.MdiParent = this;
                frm15.Show();
            }
        }
        private void frmAnaModul_Load(object sender, EventArgs e)
        {
            frm15 = new frmAnaSayfa();
            frm15.MdiParent = this;
            frm15.Show();
        }
    }
}
