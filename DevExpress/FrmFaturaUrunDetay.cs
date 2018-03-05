using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DevExpress
{
    public partial class FrmFaturaUrunDetay : Form
    {
        public FrmFaturaUrunDetay()
        {
            InitializeComponent();
        }

        Veritabani veritabani = new Veritabani();
        FaturalarVeritabani faturalarVt = new FaturalarVeritabani();

        public string id;

        private void FrmFaturaUrunDetay_Load(object sender, EventArgs e)
        {
            Listele();
        }

        public void Listele()
        {
            DataTable dtaTable = faturalarVt.ListeleFaturaDetaylari(id);

            gridControl1.DataSource = dtaTable;
        }

        private void gridView1_FocusedRowChanged(object sender, XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDuzenleme frmFtrUrnDznleme = new FrmFaturaUrunDuzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frmFtrUrnDznleme.faturaUrunId = dr["FATURAURUNID"].ToString();
            }

            frmFtrUrnDznleme.Show();
        }
    }
}
