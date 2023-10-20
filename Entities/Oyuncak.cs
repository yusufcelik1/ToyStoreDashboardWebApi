using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Oyuncak
    {
        public int OyuncakID { get; set; }
        public string Adi { get; set; }
        public int YasKategorisi { get; set; }
        public decimal Maliyet { get; set; }
        public int StokDurumu { get; set; }
    }
}
