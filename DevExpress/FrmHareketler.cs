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
    public partial class FrmHareketler : Form
    {
        public FrmHareketler()
        {
            InitializeComponent();
        }

        HareketlerVeritabani hareketVt = new HareketlerVeritabani();
        
        private void FrmHareketler_Load(object sender, EventArgs e)
        {
            FirmaListele();

            MusteriListele();
        }

        public void FirmaListele()
        {
            DataTable dtaTable = hareketVt.FirmaHareketListele();

            gridControl2.DataSource = dtaTable;
        }

        public void MusteriListele()
        {
            DataTable dtaTable = hareketVt.MusteriHareketListele();

            gridControl1.DataSource = dtaTable;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }

    }
}
