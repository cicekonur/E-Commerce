using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DTO
{
    public class KategoriDTO
    {
        //public IEnumerable<Urun> Urunler { get; set; }

        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string KategoriAdi { get; set; }
        public Guid? UstKategori { get; set; }
    }
}
