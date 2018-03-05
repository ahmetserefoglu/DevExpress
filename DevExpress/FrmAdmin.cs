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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        Veritabani vt = new Veritabani();

        private void BtnGirisYap_MouseHover(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = Color.Red;
        }

        private void BtnGirisYap_MouseLeave(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = Color.PaleGreen;
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            if (vt.GirisYap(TxtKullaniciAdi.Text, TxtPassword.Text) == true)
            {
                FrmAnaModul frmAnaModul = new FrmAnaModul();
                frmAnaModul.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanici Adi ve Sifresi Hatali","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            vt.BaglantiKapat();
        }
    }
}
