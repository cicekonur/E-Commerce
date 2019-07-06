using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entities
{
    public class Login:EntityBase
    {
        public string EMail { get; set; }
        public string Sifre { get; set; }
        public bool Yetki { get; set; }
        public DateTime? KayitTarihi { get; set; }


        public ICollection<Urun> Urunler { get; set; }
    }
}
