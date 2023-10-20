using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Satis
    {
        public int SatisID { get; set; }
        public int OyuncakID { get; set; }
        public int Adet { get; set; }
        public decimal Tutar { get; set; }
        public DateTime Tarih { get; set; }

        // Diğer özellikler eklenebilir

        public Satis()
        {
            // Boş kurucu metot
        }

        public Satis(int satisID, int oyuncakID, int adet, decimal tutar, DateTime tarih)
        {
            SatisID = satisID;
            OyuncakID = oyuncakID;
            Adet = adet;
            Tutar = tutar;
            Tarih = tarih;
        }
    }
}
