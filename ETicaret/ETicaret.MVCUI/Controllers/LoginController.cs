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
    public class LoginController : Controller
    {
        ILoginService _ls;

        public LoginController(ILoginService ls)
        {
            _ls = ls;
        }

        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult KisiEkle(LoginDTO kisi)
        {
            //kisi.KayitTarihi = DateTime.Now.Date;
            _ls.Add(kisi);

            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult GirisYap(LoginViewModel kisi)
        {


            return View("Index", "Home");
        }

    }
}