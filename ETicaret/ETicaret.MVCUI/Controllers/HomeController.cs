using ETicaret.BLL.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        IKategoriService _ks;
        public HomeController(IKategoriService ks)
        {
            _ks = ks;
        }
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult NavbarKategoriler()
        {
            var kategoriler = _ks.GetCategories().Data;

            return PartialView("_PartialNavbarKategoriler",kategoriler);
        }

    }
}