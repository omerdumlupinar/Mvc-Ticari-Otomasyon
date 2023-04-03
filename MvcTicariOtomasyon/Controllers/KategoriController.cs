using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;
using PagedList;

namespace MvcTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context c = new Context();
        public ActionResult Index()
        {
            var ktgrList = c.Kategoris.ToList();
            return View(ktgrList);
        }

        [HttpGet]
        public ActionResult kategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult kategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult kategoriSil(int id)
        {
            var ktgrIdBul = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktgrIdBul);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult kategoriGetir(int id)
        {
            var ktgr = c.Kategoris.Find(id);
            return View("kategoriGetir", ktgr);
        }


        public ActionResult kategoriGuncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.kategoriID);
            ktgr.kategoriAd = k.kategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}