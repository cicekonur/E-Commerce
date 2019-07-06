using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DTO
{
    public class LoginDTO
    {
        public Guid Id { get; set; }
        public string EMail { get; set; }
        public string Sifre { get; set; }
        public bool Yetki { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? KayitTarihi { get; set; }
    }
}
