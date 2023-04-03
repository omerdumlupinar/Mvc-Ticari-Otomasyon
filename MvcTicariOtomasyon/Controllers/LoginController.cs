using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult partial1(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult cariLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult cariLogin(Cariler ca)
        {
            var bilgi = c.Carilers.FirstOrDefault(x => x.cariMail == ca.cariMail && x.cariSifre == ca.cariSifre);
            if (bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.cariMail, false);
                Session["cariMail"] = bilgi.cariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
                
        }

        [HttpGet]
        public ActionResult personelLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult personelLogin(Admin adm)
        {
            var bilgi = c.Admins.FirstOrDefault(x => x.adminKullaniciAd == adm.adminKullaniciAd && x.adminSifre == adm.adminSifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.adminKullaniciAd, false);
                Session["adminKullaniciAd"] = bilgi.adminKullaniciAd.ToString();
                return RedirectToAction("Index", "Yapilacaklar");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}