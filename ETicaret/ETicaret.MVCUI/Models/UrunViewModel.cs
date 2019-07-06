using ETicaret.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaret.MVCUI.Models
{
    public class UrunViewModel
    {
        public UrunDTO Urun { get; set; }
        public IEnumerable<KategoriDTO> Kategoriler { get; set; }

    }
}