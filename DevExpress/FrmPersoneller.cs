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

namespace DevExpress
{
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        PersonelVeritabani personelVt = new PersonelVeritabani();
        Personel personel = new Personel();

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            Listele();

            IllerOku();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            personel.PersonelAdi = TxtAd.Text;
            personel.PersonelSoyadi = TxtSoyad.Text;
            personel.PersonelTelefon = MskTlfn1.Text;
            personel.KimlikNumarasi = MskTc.Text;
            personel.MailAdresi = TxtMail.Text;
            personel.ILi = CmbIl.SelectedText;
            personel.Ilce = CmbIlce.SelectedText;
            personel.Adresi = RchAdres.Text;
            personel.Gorevi = TxtGorev.Text;


            if (personelVt.PersonelEkle(personel) == true)
            {
                LblBilgi.Text = String.Format("Ekleme İşlemi Başarıyla Kaydedildi");

                Listele();

                Temizle();
            }
            else
            {
                LblBilgi.Text = "Ekleme İşleminde bir sorun oluştu";
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (personelVt.PersonelSil(int.Parse(TxtId.Text)) == true)
            {
                LblBilgi.Text = "Veritabanindan Silme İşlemi Başarıyla Gerçekleşti";
                //MessageBox.Show("Müşteri Veritabanina Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Listele();

                //Temizle();
            }
            else
            {
                LblBilgi.Text = "Veritabanindan Silme İşleminde Sorun Oluştu";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            personel.PersonelID = int.Parse(TxtId.Text);
            personel.PersonelAdi = TxtAd.Text;
            personel.PersonelSoyadi = TxtSoyad.Text;
            personel.PersonelTelefon = MskTlfn1.Text;
            personel.KimlikNumarasi = MskTc.Text;
            personel.MailAdresi = TxtMail.Text;
            personel.ILi = CmbIl.SelectedText;
            personel.Ilce = CmbIlce.SelectedText;
            personel.Adresi = RchAdres.Text;
            personel.Gorevi = TxtGorev.Text;

            if (personelVt.PersonelGuncelle(personel) == true)
            {
                LblBilgi.Text = "Musteri Başarıyla Güncellendi";
                //MessageBox.Show("Müşteri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();

                Temizle();
            }
            else
            {
                LblBilgi.Text = "Musteri Güncellenemedi";
            }
        }

        private void gridView1_FocusedRowChanged(object sender, XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtId.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTlfn1.Text = dr["TELEFON"].ToString();
                MskTc.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                CmbIl.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtGorev.Text = dr["GOREV"].ToString();
            }
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            CmbIlce.Text = "";
            IlcelerOku();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        public void Temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtGorev.Text = "";
            MskTlfn1.Text = "";
            MskTc.Text = "";
            TxtSoyad.Text = "";
            TxtMail.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            RchAdres.Text = "";
            TxtGorev.Text = "";
        }

        public void Listele()
        {
            DataTable dtaTable = personelVt.Listele();

            gridControl1.DataSource = dtaTable;

        }

        public void IllerOku()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("Select SEHIR FROM TBL_ILLER", veritabani.BaglantiAc());
                SqlDataReader sqlRead = sqlKomut.ExecuteReader();

                if (sqlRead.HasRows)
                {
                    while (sqlRead.Read())
                    {
                        CmbIl.Properties.Items.Add(sqlRead[0]);
                    }
                    veritabani.BaglantiAc().Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void IlcelerOku()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("Select ILCE FROM TBL_ILCELER WHERE SEHIR=@sehir", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@sehir", CmbIl.SelectedIndex + 1);
                SqlDataReader sqlRead = sqlKomut.ExecuteReader();

                if (sqlRead.HasRows)
                {
                    while (sqlRead.Read())
                    {
                        CmbIlce.Properties.Items.Add(sqlRead[0]);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        } 

        

    }
}
