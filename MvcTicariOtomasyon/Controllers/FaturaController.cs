using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var faturaList = c.Faturalars.ToList();
            return View(faturaList);
        }

        [HttpGet]
        public ActionResult faturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult faturaEkle(Faturalar f)
        {
            //uzun tarih formatını almak için datetime.now kullandık..
            f.faturaTarih = DateTime.Parse(DateTime.Now.ToLongDateString());
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult faturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("faturaGetir", fatura);
        }


        public ActionResult faturaGuncelle(Faturalar ftr)
        {
            var faturabul = c.Faturalars.Find(ftr.faturaID);

            faturabul.faturaSeriNo = ftr.faturaSeriNo;
            faturabul.faturaSıraNo = ftr.faturaSıraNo;
            faturabul.faturaToplam = ftr.faturaToplam;
            faturabul.faturaVergiDairesi = ftr.faturaVergiDairesi;
            faturabul.faturaTeslimAlan = ftr.faturaTeslimAlan;
            faturabul.faturaTeslimEden = ftr.faturaTeslimEden;
            faturabul.faturaTarih = ftr.faturaTarih;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult faturaDetay(int id)
        {
            var detaylar = c.faturaKalems.Where(x => x.faturaid == id).ToList();

            var seri = c.Faturalars.Where(x => x.faturaID == id).Select(y => y.faturaSeriNo).FirstOrDefault();

            var sira = c.Faturalars.Where(x => x.faturaID == id).Select(y => y.faturaSıraNo).FirstOrDefault();
            ViewBag.gelenSeri = seri;
            ViewBag.gelenSira = sira;

            ViewBag.gelenID = id;
            return View(detaylar);
        }

        [HttpGet]
        public ActionResult faturaKalemEkle(int id)
        {
            ViewBag.gelenID = id;

            return View();
        }

        [HttpPost]
        public ActionResult faturaKalemEkle(FaturaKalem fke ,int id)
        {
            //fke.faturaid = id;          
            c.faturaKalems.Add(fke);
            c.SaveChanges();
            return RedirectToAction("faturaDetay/"+id);
        }



    }
}