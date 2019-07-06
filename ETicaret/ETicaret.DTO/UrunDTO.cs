using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ETicaret.DTO
{
    public class UrunDTO
    {
        public Guid Id { get; set; }
        public string UrunAdi { get; set; }
        public bool IsDeleted { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public int? Stok { get; set; }
        public string ResimYolu { get; set; }
        public Guid KategoriId { get; set; }

        public HttpPostedFileBase ResimDosyasi { get; set; }
    }
}
