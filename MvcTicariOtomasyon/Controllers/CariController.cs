using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cariList = c.Carilers.Where(x => x.cariDurum == true).ToList();
            return View(cariList);
        }
        [HttpGet]
        public ActionResult cariEkle()
        {
            return View();
        }

        public ActionResult cariEkle(Cariler cr)
        {
            if (!ModelState.IsValid)
            {
                return View("cariEkle");
            }
            cr.cariDurum = true;
            c.Carilers.Add(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult cariSil(int id)
        {
            var cariBul = c.Carilers.Find(id);
            cariBul.cariDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult cariGetir(int id)
        {
            var carigtr = c.Carilers.Find(id);
            return View("cariGetir", carigtr);

        }


        public ActionResult cariGuncelle(Cariler cr)
        {
            if (!ModelState.IsValid)
            {
                return View("cariGetir");
            }

            var cariidbul = c.Carilers.Find(cr.cariID);

            cariidbul.cariAd = cr.cariAd;
            cariidbul.cariSoyad = cr.cariSoyad;
            cariidbul.cariSehir = cr.cariSehir;
            cariidbul.cariMail = cr.cariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult cariSatis(int id)

        {
            var deger = c.SatisHarekets.Where(x => x.cariid == id).ToList();
            var cariad = c.Carilers.Where(x => x.cariID == id).Select(x => x.cariAd + " " + x.cariSoyad).FirstOrDefault();
            ViewBag.ad = cariad;
            return View(deger);
        }
    }
}