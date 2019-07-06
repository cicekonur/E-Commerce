using ETicaret.BLL.Abstracts;
using ETicaret.DTO;
using ETicaret.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.MVCUI.Controllers
{
    public class UrunController : Controller
    {
        IUrunService _us;
        IKategoriService _ks;

        public UrunController(IUrunService us, IKategoriService ks)
        {
            _us = us;
            _ks = ks;
        }


        /// <summary>
        /// Partial Navbarda kullanılıyor. Dikkat edin.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UrunleriGoster(Guid id)
        {
            var urunler = _us.GetProducts().Data;

            var data = (from d in urunler
                        where d.KategoriId == id
                        select d);
            List<UrunViewModel> urunViewModels = new List<UrunViewModel>();

            foreach (var item in data)
            {
                var viewModel = new UrunViewModel()
                {
                    Urun = item
                };
                urunViewModels.Add(viewModel);
            }
            return View(urunViewModels);
        }


        public ActionResult UrunuGoster(Guid id)
        {
            var urun = _us.Get(id).Data;
            return View(urun);
        }

        public ActionResult New()
        {
            var kategoriler = _ks.GetCategories().Data;
            var viewModel = new UrunViewModel
            {
                Urun = new UrunDTO(),
                Kategoriler = kategoriler
            };
            return View("urunForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(UrunDTO urun)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UrunViewModel
                {
                    Urun = urun,
                    Kategoriler = _ks.GetCategories().Data
                };
                return View("urunForm", viewModel);
            }

            #region  resim kaydetme ve yol verme

            if (urun.ResimDosyasi != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(urun.ResimDosyasi.FileName);
                string extension = Path.GetExtension(urun.ResimDosyasi.FileName);
                fileName = urun.UrunAdi + fileName + DateTime.Now.ToString("ddmmyyyy") + extension;
                urun.ResimYolu = "/img/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/img/"), fileName);
                urun.ResimDosyasi.SaveAs(fileName);
            }
            #endregion

            if (urun.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                urun.EklemeTarihi = DateTime.Now.Date;
                _us.Add(urun);
            }
            else
            {
                _us.Update(urun);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(Guid id)
        {
            var urun = _us.Get(id).Data;

            var viewModel = new UrunViewModel()
            {
                Urun = urun,
                Kategoriler = _ks.GetCategories().Data
            };


            if (urun == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("urunForm", viewModel);
            }
        }

    }

}