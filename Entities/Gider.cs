using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Gider
    {
        public int GiderID { get; set; }
        public string Aciklama { get; set; }
        public decimal Tutar { get; set; }
        public DateTime Tarih { get; set; }

        // Diğer özellikler eklenebilir

        public Gider()
        {
            // Boş kurucu metot
        }

        public Gider(int giderID, string aciklama, decimal tutar, DateTime tarih)
        {
            GiderID = giderID;
            Aciklama = aciklama;
            Tutar = tutar;
            Tarih = tarih;
        }
    }
}
