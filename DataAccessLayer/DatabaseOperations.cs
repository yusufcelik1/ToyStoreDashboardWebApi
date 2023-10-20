using Entities;
using System;
using System.Data.SqlClient;
using static Entities.Gider;
using static Entities.Satis;
namespace DataAccessLayer
{
    public class DatabaseOperations
    {
        private string connectionString = @"Server=desktop-flojojc\sqlexpress;Database=OyuncakciDB;Trusted_Connection=SSPI; MultipleActiveResultSets=true; TrustServerCertificate=true;"; // SQL bağlantı dizesini buraya girin

        public void OyuncakEkle(Oyuncak oyuncak)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Oyuncaklar (Adi, YasKategorisi, Maliyet, StokDurumu) VALUES (@Adi, @YasKategorisi, @Maliyet, @StokDurumu)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Adi", oyuncak.Adi);
                    command.Parameters.AddWithValue("@YasKategorisi", oyuncak.YasKategorisi);
                    command.Parameters.AddWithValue("@Maliyet", oyuncak.Maliyet);
                    command.Parameters.AddWithValue("@StokDurumu", oyuncak.StokDurumu);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void OyuncakSil(int oyuncakID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Oyuncaklar WHERE OyuncakID = @OyuncakID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OyuncakID", oyuncakID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void OyuncakGuncelle(Oyuncak oyuncak)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Oyuncaklar SET Adi = @Adi, YasKategorisi = @YasKategorisi, Maliyet = @Maliyet, StokDurumu = @StokDurumu WHERE OyuncakID = @OyuncakID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OyuncakID", oyuncak.OyuncakID);
                    command.Parameters.AddWithValue("@Adi", oyuncak.Adi);
                    command.Parameters.AddWithValue("@YasKategorisi", oyuncak.YasKategorisi);
                    command.Parameters.AddWithValue("@Maliyet", oyuncak.Maliyet);
                    command.Parameters.AddWithValue("@StokDurumu", oyuncak.StokDurumu);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void StokDurumuGuncelle(int oyuncakID, int yeniStokDurumu, decimal maliyet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Oyuncaklar SET StokDurumu = @YeniStokDurumu, Maliyet = @Maliyet WHERE OyuncakID = @OyuncakID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OyuncakID", oyuncakID);
                    command.Parameters.AddWithValue("@YeniStokDurumu", yeniStokDurumu);
                    command.Parameters.AddWithValue("@Maliyet", maliyet);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void GelirGiderEkle(decimal gelir, decimal gider)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Muhasebe (Gelir, Gider, Tarih) VALUES (@Gelir, @Gider, @Tarih)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Gelir", gelir);
                    command.Parameters.AddWithValue("@Gider", gider);
                    command.Parameters.AddWithValue("@Tarih", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CalisanEkle(Calisan calisan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Calisanlar (KullaniciAdi, Sifre, Yetki) VALUES (@KullaniciAdi, @Sifre, @Yetki)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", calisan.KullaniciAdi);
                    command.Parameters.AddWithValue("@Sifre", calisan.Sifre);
                    command.Parameters.AddWithValue("@Yetki", calisan.Yetki);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Calisan CalisanGiris(string kullaniciAdi, string sifre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Calisanlar WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@Sifre", sifre);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Calisan
                            {
                                CalisanID = Convert.ToInt32(reader["CalisanID"]),
                                KullaniciAdi = reader["KullaniciAdi"].ToString(),
                                Sifre = reader["Sifre"].ToString(),
                                Yetki = reader["Yetki"].ToString()
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public List<Muhasebe> GelirGiderGoruntule()
        {
            List<Muhasebe> muhasebeListesi = new List<Muhasebe>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Muhasebe";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            muhasebeListesi.Add(new Muhasebe
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Gelir = Convert.ToDecimal(reader["Gelir"]),
                                Gider = Convert.ToDecimal(reader["Gider"]),
                                Tarih = Convert.ToDateTime(reader["Tarih"])
                            });
                        }
                    }
                }
            }
            return muhasebeListesi;
        }
        public void OyuncakSat(int oyuncakID, int adet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Oyuncak stok miktarını güncelle
                SqlCommand cmd = new SqlCommand("UPDATE Oyuncaklar SET StokDurumu = StokDurumu - @adet WHERE OyuncakID = @oyuncakID", conn);
                cmd.Parameters.AddWithValue("@oyuncakID", oyuncakID);
                cmd.Parameters.AddWithValue("@adet", adet);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    // Gelir-Gider tablosunu güncelle
                    // Burada birim başına gelir (örneğin 100 TL) kullanıldı
                    decimal gelir = adet * 100;

                    SqlCommand cmdGelir = new SqlCommand("INSERT INTO GelirGider (OyuncakID, Gelir, Gider, Tarih) VALUES (@oyuncakID, @gelir, 0, GETDATE())", conn);
                    cmdGelir.Parameters.AddWithValue("@oyuncakID", oyuncakID);
                    cmdGelir.Parameters.AddWithValue("@gelir", gelir);
                    cmdGelir.ExecuteNonQuery();
                }
            }
        }
        public void OyuncakTedarikEt(int oyuncakID, int adet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Oyuncak stok miktarını güncelle
                SqlCommand cmd = new SqlCommand("UPDATE Oyuncaklar SET Stok = Stok + @adet WHERE OyuncakID = @oyuncakID", conn);
                cmd.Parameters.AddWithValue("@oyuncakID", oyuncakID);
                cmd.Parameters.AddWithValue("@adet", adet);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    // Gelir-Gider tablosunu güncelle
                    // Burada birim başına maliyet (örneğin 50 TL) kullanıldı
                    decimal maliyet = adet * 50;

                    SqlCommand cmdGider = new SqlCommand("INSERT INTO GelirGider (OyuncakID, Gelir, Gider, Tarih) VALUES (@oyuncakID, 0, @maliyet, GETDATE())", conn);
                    cmdGider.Parameters.AddWithValue("@oyuncakID", oyuncakID);
                    cmdGider.Parameters.AddWithValue("@maliyet", maliyet);

                    cmdGider.ExecuteNonQuery();
                }
            }
        }
        public void StokDurumuGoruntule(int oyuncakID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT StokDurumu FROM Oyuncaklar WHERE OyuncakID = @OyuncakID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OyuncakID", oyuncakID);

                    connection.Open();
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        Console.WriteLine($"Oyuncak Stok Durumu: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Belirtilen ID ile eşleşen oyuncak bulunamadı.");
                    }
                }
            }
        }
        public decimal ToplamSatisGeliriHesapla()
        {
            decimal toplamGelir = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(Tutar) FROM Satislar"; // Satislar tablosundaki toplam tutarı al
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        toplamGelir = Convert.ToDecimal(result);
                    }
                }
            }

            return toplamGelir;
        }

        public decimal ToplamGiderHesapla()
        {
            decimal toplamGider = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(Tutar) FROM Giderler"; // Giderler tablosundaki toplam tutarı al
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        toplamGider = Convert.ToDecimal(result);
                    }
                }
            }

            return toplamGider;
        }

        public List<Satis> GetSatislar()
        {
            List<Satis> satislar = new List<Satis>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Satis";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            satislar.Add(new Satis
                            {
                                SatisID = Convert.ToInt32(reader["SatisID"]),
                                Tutar = Convert.ToDecimal(reader["Tutar"]),
                                Tarih = Convert.ToDateTime(reader["Tarih"])
                                // Diğer sütunlara göre ekleme yapılabilir
                            });
                        }
                    }
                }
            }

            return satislar;
        }

        // Giderleri getiren metot
        public List<Gider> GetGiderler()
        {
            List<Gider> giderler = new List<Gider>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Giderler";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            giderler.Add(new Gider
                            {
                                GiderID = Convert.ToInt32(reader["GiderID"]),
                                Tutar = Convert.ToDecimal(reader["Tutar"]),
                                Tarih = Convert.ToDateTime(reader["Tarih"])
                                // Diğer sütunlara göre ekleme yapılabilir
                            });
                        }
                    }
                }
            }

            return giderler;
        }

    }
}