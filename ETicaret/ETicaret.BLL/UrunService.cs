using CommonType.Classes;
using CommonType.Enums;
using Core.DataAccess;
using ETicaret.BLL.Abstracts;
using ETicaret.DTO;
using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL
{
    public class UrunService : IUrunService
    {
        IUnitOfWork _uow;
        List<UrunDTO> dtoList = new List<UrunDTO>();
        Urun urun = new Urun();
        public UrunService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ServiceResult Add(UrunDTO urunDTO)
        {
            urunDTO.Id = Guid.NewGuid();
            urunDTO.IsDeleted = false;

            DtoToEntity(urunDTO);

            _uow.GetRepository<Urun>().Add(urun);
            int ess = _uow.Save();
            if (ess > 0)
            {
                return new ServiceResult("Kayıt Başarılıdır.", ResultState.Success);
            }
            return new ServiceResult("Bir hata nedeniyle kayıt gerçekleşemedi.", ResultState.Error);
        }

       
        public ServiceResult Update(UrunDTO urunDTO)
        {
            DtoToEntity(urunDTO);

            Urun det = _uow.GetRepository<Urun>().Get(i => i.Id == urun.Id);
            _uow.GetRepository<Urun>().Detach(det);
            _uow.GetRepository<Urun>().Update(urun);
            int ess = _uow.Save();

            if (ess > 0)
            {
                return new ServiceResult("Kayıt başarılıdır", ResultState.Success);
            }
            return new ServiceResult("Bir hata nedeniyle kayıt gerçekleşmedi.", ResultState.Error);
        }
        public ServiceResult<UrunDTO> Get(Guid Id)
        {
            var urun = _uow.GetRepository<Urun>().Get(u => u.Id == Id);
            var urunDto = EntityToDto(urun);
            return new ServiceResult<UrunDTO>("Okuma Başarılı", ResultState.Success, urunDto);
        }

        public ServiceResult<List<UrunDTO>> GetProducts()
        {
            List<Urun> urunler = _uow.GetRepository<Urun>().GetList();
            var dtoUrun = EntityToDto(urunler);
            return new ServiceResult<List<UrunDTO>>("Okuma Başarılı", ResultState.Success, dtoUrun);
        }


        #region EntityToDTO
        private UrunDTO EntityToDto(Urun urun)
        {
            UrunDTO dto = new UrunDTO();
            dto.Id = urun.Id;
            dto.IsDeleted = urun.IsDeleted;
            dto.EklemeTarihi = urun.EklemeTarihi;
            dto.Aciklama = urun.Aciklama;
            dto.Fiyat = urun.Fiyat;
            dto.KategoriId = urun.KategoriId;
            dto.Stok = urun.Stok;
            dto.UrunAdi = urun.UrunAdi;
            dto.ResimYolu = urun.ResimYolu;


            return dto;
        }
        private List<UrunDTO> EntityToDto(List<Urun> urunler)
        {
            
            foreach (var item in urunler)
            {
                var urunDTO = EntityToDto(item);
                dtoList.Add(urunDTO);
            }
            return dtoList;
        }


        #endregion


        private void DtoToEntity(UrunDTO urunDTO)
        {
            urun.Id = urunDTO.Id;
            urun.IsDeleted = urunDTO.IsDeleted;
            urun.EklemeTarihi = urunDTO.EklemeTarihi;
            urun.Aciklama = urunDTO.Aciklama;
            urun.KategoriId = urunDTO.KategoriId;
            urun.Stok = urunDTO.Stok;
            urun.Fiyat = urunDTO.Fiyat;
            urun.UrunAdi = urunDTO.UrunAdi;
            urun.ResimYolu = urunDTO.ResimYolu;
        }
    }
}
