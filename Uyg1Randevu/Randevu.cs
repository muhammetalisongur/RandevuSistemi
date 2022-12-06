using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // StreamReader ve StreamWriter komutunu eklemek icin IO eklemek lazim
using System.Windows.Forms;
namespace Uyg1Randevu
{
    internal class Randevu
    {
        static string dosyaYolu = @"randevu.txt"; //@:(C:\XX\\YY)escape karakteri demek bunu cift ters slajdan kurtulmak icin kullanilir
                                                  //eger sadece randevu.txt yazarsak exe nin oldugu yere kayit yapar
        public static void Ekle(string satir)
        {
            //kimlik numarasi ad soyad... gibi islemleri burada ayri ayri parametre alarak buradada birlestirme islemi yapilabilirdi 
            /* read (StreamReader komutu kullanilir) eger olusturulmak istenen dosya yok ise kendisi olusturmaz hata verir
             * Write (StreamWriter komutu kullanilir) (her yeni eklemede mevcut icerik silinir, son yazilan tuturulur) eger olusturulmak istenen dosya yok ise kendisi otomatik olusturur
             * Append (StreamWriter komutu kullanilir) (her eklemede mevcut icerik korunur ve yeni eklenen dosyanin sonuna eklenir)
             */

            StreamWriter yazmaNesnesi = yazmaNesnesi = new StreamWriter(dosyaYolu, true); //true yaparsak append modunda acilir ve icerik silinmeden alt satira eklemek yapar
                                                                                          // false yapmamiz write modunda acildi ve bu yuzden en son eklenen tutuldu diger veriler silindi
            yazmaNesnesi.WriteLine(satir);
            MessageBox.Show("Eklendi");
            yazmaNesnesi.Close();// yazma nesnesini actigimiz zaman kapatmamiz lazim ki baska programlar bu dosyaya erisebilsin

        }

        public static string tumRandevular()
        {
            StreamReader okumaNesnesi = new StreamReader(dosyaYolu);
            //string icerik=okumaNesnesi.ReadToEnd();
            // ReadToEnd butun icerigi okur ve en dosyanin en sonunu gosterecek sekilde konumlanir
            //Read: sutun sutun  okuyup dosyanin sonunda okuma yapamaz //bunu dosyanin sonuna diyerek okuma yapmaliyiz
            //ReadLine: satir satir okur ve dosyanin sonunda okuma yapamaz //bunu dosyanin sonuna diyerek okuma yapmaliyiz

            //2. okuma sekli
            string icerik = "";
            while (okumaNesnesi.EndOfStream == false) // dosyanin sonuna gelene kadar dongu kurduk satir satir butun satirlari oku dedik
                                                      //dosyanin sonuna gelindginda enofstream ozelligi true degeri alir ve donguden cikar
            {
                icerik += okumaNesnesi.ReadLine() + Environment.NewLine; // enter ozelligi gelmedigi icin biz bunu +Environment.NewLine komutu ile ekleyebiliriz
            }


            okumaNesnesi.Close(); //dosyayi her zaman kapatiyoruz
            return icerik;
        }


        public static bool randevuVarMi(string bolum, string tarih, string saat)
        {
            StreamReader okumaNesnesi = new StreamReader(dosyaYolu);
            string satir = "";
            bool sonuc = false;
            while (okumaNesnesi.EndOfStream == false && sonuc == false) // donguden bulundugu anda cikmak icin break yerine while icine sonuc false degeri ekleriz
            {
                satir = okumaNesnesi.ReadLine();
                string[] parcalar = satir.Split('*');// bolumlemeyi split komutu ile yapiyoruz stringler uzerinden yildizlardan boler ve bunu satir satir okur ve boler
                
                if (parcalar[3] == bolum && parcalar[4] == tarih && parcalar[5] == saat)
                    sonuc = true;
            }
            okumaNesnesi.Close();
            return sonuc;

        }

    }
}
