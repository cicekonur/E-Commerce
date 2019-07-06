using CommonType.Classes;
using CommonType.Enums;
using Core.DataAccess;
using ETicaret.BLL.Abstracts;
using ETicaret.DTO;
using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL
{
    public class LoginService : ILoginService
    {
        IUnitOfWork _uow;
        List<LoginDTO> logins = new List<LoginDTO>();
        Login login = new Login();
        public LoginService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ServiceResult Add(LoginDTO loginDTO)
        {
            loginDTO.Id = Guid.NewGuid();
            loginDTO.IsDeleted = false;
            loginDTO.KayitTarihi = DateTime.Now.Date;
            DtoToEntity(loginDTO);

            _uow.GetRepository<Login>().Add(login);
            int ess = _uow.Save();
            if (ess > 0)
            {
                return new ServiceResult("Kayıt Başarılıdır.", ResultState.Success);
            }


            return new ServiceResult("Bir hata nedeniyle kayıt gerçekleşemedi.", ResultState.Error);

        }
        


        public ServiceResult Update(LoginDTO loginDTO)
        {
            DtoToEntity(loginDTO);

            Login det = _uow.GetRepository<Login>().Get(i => i.Id == login.Id);
            _uow.GetRepository<Login>().Detach(det);
            _uow.GetRepository<Login>().Update(login);
            int ess = _uow.Save();

            if (ess > 0)
            {
                return new ServiceResult("Kayıt başarılıdır", ResultState.Success);
            }
            return new ServiceResult("Bir hata nedeniyle kayıt gerçekleşmedi.", ResultState.Error);
        }


        public ServiceResult<LoginDTO> Get(Guid Id)
        {
            var kullanici = _uow.GetRepository<Login>().Get(u => u.Id == Id);
            var loginDTO = EntityToDto(kullanici);
            return new ServiceResult<LoginDTO>("Okuma Başarılı", ResultState.Success, loginDTO);
        }
               


        public ServiceResult<List<LoginDTO>> GetKisiler()
        {
            List<Login> kullanicilar = _uow.GetRepository<Login>().GetList();
            var loginDTO = EntityToDto(kullanicilar);
            return new ServiceResult<List<LoginDTO>>("Okuma Başarılı", ResultState.Success, loginDTO);
        }
                                 


        private LoginDTO EntityToDto(Login kullanici)
        {
            LoginDTO dto = new LoginDTO();
            dto.Id = kullanici.Id;
            dto.IsDeleted = kullanici.IsDeleted;
            dto.EMail = kullanici.EMail;
            dto.Sifre = kullanici.Sifre;
            dto.Yetki = kullanici.Yetki;

            return dto;
        }



        private List<LoginDTO> EntityToDto(List<Login> kullnicilar)
        {

            foreach (var kullanici in kullnicilar)
            {
                var loginDTO = EntityToDto(kullanici);
                logins.Add(loginDTO);
            }
            return logins;
        }



        private void DtoToEntity(LoginDTO kullaniciDTO)
        {
            login.Id = kullaniciDTO.Id;
            login.IsDeleted = kullaniciDTO.IsDeleted;
            login.EMail = kullaniciDTO.EMail;
            login.Sifre = kullaniciDTO.Sifre;
            login.Yetki = kullaniciDTO.Yetki;
        }

    }

}
