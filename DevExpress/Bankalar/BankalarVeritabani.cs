using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class BankalarVeritabani
    {
        Veritabani veritabani = new Veritabani();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable Listele()
        {
            DataTable dataTable = new DataTable();

            string sorgu = String.Format("Exec BankaBilgileri");

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="banka"></param>
        /// <returns></returns>
        public bool BankaEkle(Bankalar banka)
        {
            FirmalarVeritabani firmaVt = new FirmalarVeritabani();
            try
            {
                string sorgu = "INSERT INTO TBL_BANKALAR(BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID)"+
                    " VALUES(@bankaadi,@il,@ilce,@sube,@iban,@hesapno,@yetkili,@telefon,@tarih,@hesapturu,@firmaid)";

                SqlCommand sqlKomut = new SqlCommand(sorgu, veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@bankaadi", banka.BankaAdi);
                sqlKomut.Parameters.AddWithValue("@il", banka.BankaIli);
                sqlKomut.Parameters.AddWithValue("@ilce", banka.BankaIlce);
                sqlKomut.Parameters.AddWithValue("@sube", banka.BankaSube);
                sqlKomut.Parameters.AddWithValue("@iban", banka.IbanNumarasi);
                sqlKomut.Parameters.AddWithValue("@hesapno", banka.HesapNumarasi);
                sqlKomut.Parameters.AddWithValue("@yetkili", banka.BankaYetkilisi);
                sqlKomut.Parameters.AddWithValue("@telefon", banka.BankaTelefon);
                sqlKomut.Parameters.AddWithValue("@tarih", banka.KayitTarihi);
                sqlKomut.Parameters.AddWithValue("@hesapturu", banka.HesapTuru);
                sqlKomut.Parameters.AddWithValue("@firmaid", banka.FirmaAdi);

                sqlKomut.ExecuteNonQuery();

                veritabani.BaglantiAc().Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool BankaSil(int id)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("DELETE FROM TBL_BANKALAR WHERE ID=@ID", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@ID", id);
                sqlKomut.ExecuteNonQuery();

                veritabani.BaglantiAc().Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="musteri"></param>
        /// <returns></returns>
        public bool BankaGuncelle(Bankalar banka)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("UPDATE TBL_BANKALAR SET BANKAADI=@bankaadi,IL=@il,ILCE=@ilce,SUBE=@sube,IBAN=@iban,HESAPNO=@hesapno,YETKILI=@yetkili,TELEFON=@telefon,TARIH=@tarih,HESAPTURU=@hesapturu,FIRMAID=@firmaid WHERE ID=@id", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@bankaadi", banka.BankaAdi);
                sqlKomut.Parameters.AddWithValue("@il", banka.BankaIli);
                sqlKomut.Parameters.AddWithValue("@ilce", banka.BankaIlce);
                sqlKomut.Parameters.AddWithValue("@sube", banka.BankaSube);
                sqlKomut.Parameters.AddWithValue("@iban", banka.IbanNumarasi);
                sqlKomut.Parameters.AddWithValue("@hesapno", banka.HesapNumarasi);
                sqlKomut.Parameters.AddWithValue("@yetkili", banka.BankaYetkilisi);
                sqlKomut.Parameters.AddWithValue("@telefon", banka.BankaTelefon);
                sqlKomut.Parameters.AddWithValue("@tarih", banka.KayitTarihi);
                sqlKomut.Parameters.AddWithValue("@hesapturu", banka.HesapTuru);
                sqlKomut.Parameters.AddWithValue("@firmaid", banka.FirmaAdi);
                sqlKomut.Parameters.AddWithValue("@id", banka.BankaID);

                sqlKomut.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

    }
}
