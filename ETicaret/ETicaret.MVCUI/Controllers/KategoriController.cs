using ETicaret.BLL.Abstracts;
using ETicaret.DTO;
using ETicaret.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.MVCUI.Controllers
{
    public class KategoriController : Controller
    {
        IKategoriService _ks;
        public KategoriController(IKategoriService ks)
        {
            _ks = ks;
        }
        // GET: Kategori


        public ActionResult KategoriGoster()
        {
            var kategoriler = _ks.GetCategories().Data;

            return View(kategoriler);
        }




        public ActionResult KategoriEkle()
        {
            var kategoriler = new KategoriViewModel()
            {
                Kategori = new KategoriDTO(),
                Kategoriler = _ks.GetCategories().Data
            };


            return View(kategoriler);
        }


        [HttpPost]
        public ActionResult KategoriEkle(KategoriDTO kategoriDTO)
        {

            //TO DO form bilgi göndermiyor niyeyse. Düzelt

            if (!ModelState.IsValid)
            {
                var viewModel = new KategoriViewModel()
                {
                    Kategori = kategoriDTO,
                    Kategoriler = _ks.GetCategories().Data
                };
                return View(viewModel);
            }


            if (kategoriDTO.Id == Guid.Parse("00000000-0000-0000-0000-000000000000") && kategoriDTO.KategoriAdi != null)
            {
                _ks.Add(kategoriDTO);
            }

          

            return View();
        }
    }
}