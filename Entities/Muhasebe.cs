using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Muhasebe
    {
        public int ID { get; set; }
        public decimal Gelir { get; set; }
        public decimal Gider { get; set; }
        public DateTime Tarih { get; set; }
    }
}
