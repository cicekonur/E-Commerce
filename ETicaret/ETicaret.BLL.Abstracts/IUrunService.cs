using CommonType.Classes;
using ETicaret.DTO;
using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Abstracts
{
    public interface IUrunService
    {
        ServiceResult<List<UrunDTO>> GetProducts();
        ServiceResult<UrunDTO> Get(Guid Id);
        ServiceResult Add(UrunDTO urun);

        ServiceResult Update(UrunDTO urun);

        
    }
}
