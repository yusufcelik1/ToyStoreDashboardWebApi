using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Calisan
    {
        public int CalisanID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Yetki { get; set; }  // 'Yönetici' veya 'Kasiyer' gibi değerler alabilir
    }
}
