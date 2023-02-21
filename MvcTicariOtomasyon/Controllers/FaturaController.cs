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
            f.faturaTarih = DateTime.Parse(DateTime.Now.ToLongTimeString());
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
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult faturaDetay(int id)
        {
            var detaylar = c.faturaKalems.Where(x => x.faturaid == id).ToList();

            return View(detaylar);
        }

        [HttpGet]
        public ActionResult faturaKalemEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult faturaKalemEkle(FaturaKalem fke)
        {

            c.faturaKalems.Add(fke);
            c.SaveChanges();
            return RedirectToAction("faturaDetay");
        }



    }
}