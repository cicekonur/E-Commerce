using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entities
{
    public class Kategori : EntityBase
    {
       
        public string KategoriAdi { get; set; }

        public Guid? UstKategori { get; set; }


        public Kategori Kategoriler { get; set; }

        public ICollection<Urun> Urunler { get; set; }

    }
}
