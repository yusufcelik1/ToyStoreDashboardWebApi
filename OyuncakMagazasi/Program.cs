using System;
using BusinessLogicLayer; // Bu, Business Logic Layer katmanınızın adı olmalıdır
using Entities;
// Diğer gerekli using direktifleri

namespace OyuncakMagazasiConsoleApp
{
    class Program
    {
        private static Calisan currentCalisan;
        static void Main(string[] args)
        {
            // İlgili sınıfları burada oluşturabilirsiniz
            BusinessLogic businessLogic = new BusinessLogic();


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Oyuncak Mağazası Otomasyonu");
                Console.WriteLine("1. Admin Girişi");
                Console.WriteLine("2. Kasiyer Girişi");
                Console.WriteLine("3. Çıkış");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        if (CalisanGiris(businessLogic) && currentCalisan.Yetki == "1")
                        {
                            AdminMenu(businessLogic);
                        }
                        else
                        {
                            Console.WriteLine("Yetkiniz yok ya da hatalı giriş bilgisi.");
                        }
                        break;

                    case "2":
                        if (CalisanGiris(businessLogic) && (currentCalisan.Yetki == "1" || currentCalisan.Yetki == "2"))
                        {
                            KasiyerMenu(businessLogic);
                        }
                        else
                        {
                            Console.WriteLine("Yetkiniz yok ya da hatalı giriş bilgisi.");
                        }
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lütfen geçerli bir seçenek giriniz.");
                        break;
                }
            }
        }

        static void AdminMenu(BusinessLogic businessLogic)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Admin Menüsü");
                Console.WriteLine("1. Oyuncak Ekle");
                Console.WriteLine("2. Oyuncak Sil");
                Console.WriteLine("3. Stok Durumu Görüntüle");
                Console.WriteLine("4. Gelir-Gider Raporu");
                Console.WriteLine("5. Geri");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Oyuncak Adı: ");
                        string oyuncakAdi = Console.ReadLine();
                        Console.Write("Oyuncak Yaş Kategorisi: "); // Yaş Kategorisi bilgisini de almalısınız.
                        int yasKategorisi = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Oyuncak Stok Miktarı: ");
                        int stokMiktari;
                        while (!int.TryParse(Console.ReadLine(), out stokMiktari))
                        {
                            Console.Write("Lütfen geçerli bir stok miktarı giriniz: ");
                        }
                        Console.Write("Oyuncak Fiyatı: ");
                        decimal fiyat;
                        while (!decimal.TryParse(Console.ReadLine(), out fiyat))
                        {
                            Console.Write("Lütfen geçerli bir fiyat giriniz: ");
                        }

                        Oyuncak yeniOyuncak = new Oyuncak
                        {
                            Adi = oyuncakAdi,
                            YasKategorisi = yasKategorisi, // Yaş kategorisi bilgisini doldurmalısınız.
                            Maliyet = fiyat, // Maliyet bilgisini doldurmalısınız.
                            StokDurumu = stokMiktari // Stok durumu bilgisini doldurmalısınız.
                        };

                        businessLogic.OyuncakEkle(yeniOyuncak);
                        Console.WriteLine("Oyuncak başarıyla eklendi.");
                        break;
                    case "2":
                        Console.Write("Silmek istediğiniz oyuncak ID'sini giriniz: ");
                        int oyuncakID2;
                        while (!int.TryParse(Console.ReadLine(), out oyuncakID2))
                        {
                            Console.Write("Lütfen geçerli bir oyuncak ID'si giriniz: ");
                        }
                        businessLogic.OyuncakSil(oyuncakID2);
                        Console.WriteLine("Oyuncak başarıyla silindi.");
                        break;
                    case "3":
                        Console.WriteLine("Stok durumunu görüntülemek için oyuncak ID'sini giriniz:");
                        int oyuncakID3;
                        while (!int.TryParse(Console.ReadLine(), out oyuncakID3))
                        {
                            Console.WriteLine("Lütfen geçerli bir oyuncak ID'si giriniz:");
                        }
                        businessLogic.StokDurumuGoruntule(oyuncakID3);
                        break;


                    case "4":
                        // Gelir-gider raporu işlemleri burada gerçekleştirilecek
                        Console.WriteLine("Gelir-gider raporu hesaplanıyor...");

                        decimal gelir = businessLogic.ToplamGelirHesapla();
                        decimal gider = businessLogic.ToplamGiderHesapla();
                        decimal kar = gelir - gider;

                        Console.WriteLine($"Toplam Gelir: {gelir} TL");
                        Console.WriteLine($"Toplam Gider: {gider} TL");
                        Console.WriteLine($"Kar: {kar} TL");

                        Console.WriteLine("Gelir-gider raporu başarıyla hesaplandı.");
                        break;
                    case "5":
                        return; // Ana menüye geri dön
                    default:
                        Console.WriteLine("Lütfen geçerli bir seçenek giriniz.");
                        break;
                }

                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }

        static void KasiyerMenu(BusinessLogic businessLogic)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Kasiyer Menüsü");
                Console.WriteLine("1. Oyuncak Sat");
                Console.WriteLine("2. Stok Durumu Görüntüle");
                Console.WriteLine("3. Geri");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Oyuncak ID'sini giriniz:");
                        int oyuncakID;
                        while (!int.TryParse(Console.ReadLine(), out oyuncakID))
                        {
                            Console.WriteLine("Lütfen geçerli bir oyuncak ID'si giriniz:");
                        }

                        Console.WriteLine("Satış adedini giriniz:");
                        int adet;
                        while (!int.TryParse(Console.ReadLine(), out adet))
                        {
                            Console.WriteLine("Lütfen geçerli bir adet giriniz:");
                        }

                        // Oyuncak satışı işlemini burada gerçekleştirin ve stok miktarını güncelleyin
                        businessLogic.OyuncakSat(oyuncakID, adet);
                        Console.WriteLine("Oyuncak satışı başarıyla gerçekleştirildi.");
                        break;
                    case "2":
                        Console.WriteLine("Stok durumunu görüntülemek için oyuncak ID'sini giriniz:");
                        int stokOyuncakID;
                        while (!int.TryParse(Console.ReadLine(), out stokOyuncakID))
                        {
                            Console.WriteLine("Lütfen geçerli bir oyuncak ID'si giriniz:");
                        }

                        // Stok durumunu görüntüleme işlemini burada gerçekleştirin
                        businessLogic.StokDurumuGoruntule(stokOyuncakID);
                        break;
                    case "3":
                        return; // Ana menüye geri dön
                    default:
                        Console.WriteLine("Lütfen geçerli bir seçenek giriniz.");
                        break;
                }

                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }
        private static bool CalisanGiris(BusinessLogic businessLogic)
        {
            Console.Write("Kullanıcı Adı: ");
            string kullaniciAdi = Console.ReadLine();

            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();

            currentCalisan = businessLogic.CalisanGiris(kullaniciAdi, sifre);

            if (currentCalisan != null)
            {
                return true;
            }

            Console.WriteLine("Hatalı kullanıcı adı veya şifre. Tekrar deneyin.");
            return false;
        }

    }
}
