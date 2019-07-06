using CommonType.Classes;
using CommonType.Enums;
using Core.DataAccess;
using ETicaret.BLL.Abstracts;
using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DTO;
using AutoMapper;

namespace ETicaret.BLL
{
    public class KategoriService : IKategoriService
    {
        IUnitOfWork _uow;

        List<KategoriDTO> dtoList = new List<KategoriDTO>();
        Kategori kategori = new Kategori();
        public KategoriService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ServiceResult Add(KategoriDTO kategoriDTO)
        {
            kategoriDTO.Id = Guid.NewGuid();
            kategoriDTO.IsDeleted = false;
            DtoToEntity(kategoriDTO);

            _uow.GetRepository<Kategori>().Add(kategori);
            int ess = _uow.Save();

            if (ess > 0)
            {
                return new ServiceResult("Kayıt başarılıdır", ResultState.Success);
            }
            return new ServiceResult("Bir hata nedeniyle kayıt gerçekleşmedi.", ResultState.Error);

        }



        public ServiceResult<KategoriDTO> Get(Guid Id)
        {
            var kategori = _uow.GetRepository<Kategori>().Get(k => k.Id == Id);
            var kategoriDto = EntityToDto(kategori);


            return new ServiceResult<KategoriDTO>("Okuma Başarılı", ResultState.Success, kategoriDto);

        }

        public ServiceResult<List<KategoriDTO>> GetCategories()
        {
            List<Kategori> kategoriler = _uow.GetRepository<Kategori>().GetList();
            var dtoKategori = EntityToDto(kategoriler);

            return new ServiceResult<List<KategoriDTO>>("Okuma Başarılı", ResultState.Success, dtoKategori);
        }



        public ServiceResult Update(KategoriDTO kategoriDTO)
        {
            DtoToEntity(kategoriDTO);

            Kategori det = _uow.GetRepository<Kategori>().Get(i => i.Id == kategoriDTO.Id);
            _uow.GetRepository<Kategori>().Detach(det);
            _uow.GetRepository<Kategori>().Update(kategori);
            int ess = _uow.Save();

            if (ess > 0)
            {
                return new ServiceResult("Güncelleme başarılıdır", ResultState.Success);
            }
            return new ServiceResult("Bir hata nedeniyle güncelleştirme gerçekleşmedi.", ResultState.Error);
        }


        #region EntityToDTO
        public KategoriDTO EntityToDto(Kategori kategori)
        {
            KategoriDTO dto = new KategoriDTO();
            dto.Id = kategori.Id;
            dto.IsDeleted = kategori.IsDeleted;
            dto.KategoriAdi = kategori.KategoriAdi;
            dto.UstKategori = kategori.UstKategori;
            return dto;
        }
        public List<KategoriDTO> EntityToDto(List<Kategori> kategoriler)
        {

            foreach (var item in kategoriler)
            {
                var kategoriDTO = EntityToDto(item);
                dtoList.Add(kategoriDTO);

            }
            return dtoList;
        }


        #endregion
        private void DtoToEntity(KategoriDTO kategoriDTO)
        {
            kategori.Id = kategoriDTO.Id;
            kategori.IsDeleted = kategoriDTO.IsDeleted;
            kategori.KategoriAdi = kategoriDTO.KategoriAdi;
            kategori.UstKategori = kategoriDTO.UstKategori;
        }
    }
}
