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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }

        MusterilerVeritabani musterilerVt = new MusterilerVeritabani();
        FirmalarVeritabani firmalarVt = new FirmalarVeritabani();

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = musterilerVt.MusterilerRehber();
            gridControl2.DataSource = firmalarVt.FirmalarRehber();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frmMail = new FrmMail();

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frmMail.mail = dr["MAIL"].ToString();
            }
            frmMail.Show();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frmMail = new FrmMail();

            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                frmMail.mail = dr["MAIL"].ToString();
            }
            frmMail.Show();
        }
    }
}
