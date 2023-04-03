using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Uruns.Where(x => x.urunID == 1).ToList();
            return View(degerler);
        }
    }
}