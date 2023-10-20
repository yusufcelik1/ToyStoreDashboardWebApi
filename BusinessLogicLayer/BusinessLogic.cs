using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BusinessLogic
    {
        private readonly DatabaseOperations _dbOperations;

        public BusinessLogic()
        {
            _dbOperations = new DatabaseOperations();
        }

        public void OyuncakEkle(Oyuncak oyuncak)
        {
            try
            {
                // İş kuralları ve validasyonlar burada gerçekleştirilebilir
                _dbOperations.OyuncakEkle(oyuncak);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
            }
        }

        public void StokDurumuGoruntule(int oyuncakID)
        {
            try
            {
                // İş kuralları ve validasyonlar burada gerçekleştirilebilir
                _dbOperations.StokDurumuGoruntule(oyuncakID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
            }

        }

        
    public void OyuncakSil(int oyuncakID)
        {
            try
            {
            _dbOperations.OyuncakSil(oyuncakID);
        }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
            }
            // İş kuralları ve validasyonlar burada gerçekleştirilebilir
            
        }

        public void OyuncakGuncelle(Oyuncak oyuncak)
        {
            try
            {
                _dbOperations.OyuncakGuncelle(oyuncak);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
            }

        }

        public void StokDurumuGuncelle(int oyuncakID, int yeniStokMiktari, decimal maliyet)
        {
            try
            {
                _dbOperations.StokDurumuGuncelle(oyuncakID, yeniStokMiktari, maliyet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
            }
            // İş kuralları ve validasyonlar burada gerçekleştirilebilir

        }

        public void OyuncakSat(int oyuncakID, int adet)
        {

            try
            {
                _dbOperations.OyuncakSat(oyuncakID, adet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
            }
            // İş kuralları ve validasyonlar burada gerçekleştirilebilir

        }

        public void OyuncakTedarikEt(int oyuncakID, int adet)
        {
            try
            {
                _dbOperations.OyuncakTedarikEt(oyuncakID, adet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
            }
            // İş kuralları ve validasyonlar burada gerçekleştirilebilir

        }

        public void GelirGiderGoruntule()
        {
            try
            {
                var muhasebeListesi = _dbOperations.GelirGiderGoruntule();
                foreach (var muhasebe in muhasebeListesi)
                {
                    Console.WriteLine($"ID: {muhasebe.ID}, Gelir: {muhasebe.Gelir}, Gider: {muhasebe.Gider}, Tarih: {muhasebe.Tarih}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
            }
            // Gelir-Gider görüntüleme işlemleri burada gerçekleştirilebilir

        }
        //try
        //   {
        //   }
        //   catch (Exception ex)
        //   {
        //       Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
        //   }
        public decimal ToplamGelirHesapla()
        {
            try
            {
                decimal toplamGelir = 0;
                var satislar = _dbOperations.GetSatislar(); // Veritabanından satışları al
                foreach (var satis in satislar)
                {
                    toplamGelir += satis.Tutar; // Satışların tutarlarını topla
                }
                return toplamGelir;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
                return 0;
            }
            
        }

        public decimal ToplamGiderHesapla()
        {
            try
            {
                decimal toplamGider = 0;
                var giderler = _dbOperations.GetGiderler(); // Veritabanından giderleri al
                foreach (var gider in giderler)
                {
                    toplamGider += gider.Tutar; // Giderlerin tutarlarını topla
                }

                return toplamGider;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata meydana geldi: {ex.Message}");
                return 0;
            }

        }
        public Calisan CalisanGiris(string kullaniciAdi, string sifre)
        {
            return _dbOperations.CalisanGiris(kullaniciAdi, sifre);
        }
    }
}
