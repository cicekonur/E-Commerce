using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entities
{
    public class Urun : EntityBase
    {
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public int? Stok { get; set; }
        public string ResimYolu { get; set; }
        public Guid KategoriId { get; set; }


        public ICollection<Login> Login { get; set; }
        public Kategori Kategori { get; set; }
    }
}
