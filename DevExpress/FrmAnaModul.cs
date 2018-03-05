using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpress
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        FrmUrunler frmUrunler;
        private void BtnUrunler_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
           
            //Urunler nesnesi boş ise açılsın(üst üste açılmasının engellenmesi)
            if (frmUrunler == null)
            {
                frmUrunler = new FrmUrunler();
                frmUrunler.MdiParent = this;
                frmUrunler.Show();
            }
            
        }

        FrmMusteriler frmMusteriler;
        private void BtnMusteriler_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
            if (frmMusteriler == null)
            {
                frmMusteriler = new FrmMusteriler();
                frmMusteriler.MdiParent = this;
                frmMusteriler.Show();
            }
        }

        FrmFirmalar frmFirmalar;
        private void BtnFirmalar_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
            if (frmFirmalar == null)
            {
                frmFirmalar = new FrmFirmalar();
                frmFirmalar.MdiParent = this;
                frmFirmalar.Show();
            }

        }

        FrmPersoneller frmPersonel;
        private void BtnPersoneller_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
            if (frmPersonel == null)
            {
                frmPersonel = new FrmPersoneller();
                frmPersonel.MdiParent = this;
                frmPersonel.Show();
            }
        }

        FrmRehber frmRehber;
        private void BtnRehber_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
            if (frmRehber == null)
            {
                frmRehber = new FrmRehber();
                frmRehber.MdiParent = this;
                frmRehber.Show();
            }
        }

        FrmGiderler frmGider;
        private void BtnGiderler_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
            if (frmGider == null)
            {
                frmGider = new FrmGiderler();
                frmGider.MdiParent = this;
                frmGider.Show();
            }
        }

        FrmBankalar frmBankalar;
        private void BtnBankalar_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
            if (frmBankalar == null)
            {
                frmBankalar = new FrmBankalar();
                frmBankalar.MdiParent = this;
                frmBankalar.Show();
            }
        }

        FrmFaturalar frmFaturalar;
        private void BtnFaturalar_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
            if (frmFaturalar == null)
            {
                frmFaturalar = new FrmFaturalar();
                frmFaturalar.MdiParent = this;
                frmFaturalar.Show();
            }

        }

        FrmNotlar frmNotlar;
        private void BtnNotlar_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
            if (frmNotlar == null)
            {
                frmNotlar = new FrmNotlar();
                frmNotlar.MdiParent = this;
                frmNotlar.Show();
            }
        }

        FrmHareketler frmHareketler;
        private void btnHareketler_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
            if (frmHareketler == null)
            {
                frmHareketler = new FrmHareketler();
                frmHareketler.MdiParent = this;
                frmHareketler.Show();
            }
        }

        FrmRaporlar frmRaporlar;
        private void barButtonItem1_ItemClick(object sender, XtraBars.ItemClickEventArgs e)
        {
            if (frmRaporlar == null)
            {
                frmRaporlar = new FrmRaporlar();
                frmRaporlar.MdiParent = this;
                frmRaporlar.Show();
            }
        }

    }
}
