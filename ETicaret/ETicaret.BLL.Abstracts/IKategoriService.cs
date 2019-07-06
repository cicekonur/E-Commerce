using CommonType.Classes;
using ETicaret.DTO;
using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Abstracts
{
    public interface IKategoriService
    {
        ServiceResult<List<KategoriDTO>> GetCategories();
        ServiceResult<KategoriDTO> Get(Guid Id);
        ServiceResult Add(KategoriDTO kategori);
        ServiceResult Update(KategoriDTO kategori);
    }
}
