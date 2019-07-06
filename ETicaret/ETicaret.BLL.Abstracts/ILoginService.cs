using CommonType.Classes;
using ETicaret.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Abstracts
{
    public interface ILoginService
    {
        ServiceResult<List<LoginDTO>> GetKisiler();
        ServiceResult<LoginDTO> Get(Guid Id);
        ServiceResult Add(LoginDTO kisi);

        ServiceResult Update(LoginDTO kisi);
    }
}
