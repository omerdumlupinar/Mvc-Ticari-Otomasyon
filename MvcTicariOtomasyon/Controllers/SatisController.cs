using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;


namespace MvcTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var satisList = c.SatisHarekets.ToList();
            return View(satisList);
        }

        [HttpGet]
        public ActionResult satisYap()
        {
            List<SelectListItem> cri = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariAd,
                                               Value = x.cariID.ToString()
                                           }).ToList() ;


            List<SelectListItem> prsnl = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelAd+" "+x.personelSoyad,
                                               Value = x.personelID.ToString()
                                           }).ToList();

            List<SelectListItem> urn = (from x in c.Uruns.Where(x=>x.urunStok>0).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.urunAd,
                                               Value = x.urunID.ToString()
                                           }).ToList();




            ViewBag.c = cri;
            ViewBag.p = prsnl;
            ViewBag.u = urn;

            


            return View();
        }


        [HttpPost]
        public ActionResult satisYap(SatisHareket s)
        {
            s.satisHateketTarih = DateTime.Parse(DateTime.Now.ToLongTimeString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult satisGetir(int id)
        {


            List<SelectListItem> cri = (from x in c.Carilers.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.cariAd,
                                            Value = x.cariID.ToString()
                                        }).ToList();


            List<SelectListItem> prsnl = (from x in c.Personels.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.personelAd + " " + x.personelSoyad,
                                              Value = x.personelID.ToString()
                                          }).ToList();

            List<SelectListItem> urn = (from x in c.Uruns.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.urunAd,
                                            Value = x.urunID.ToString()
                                        }).ToList();




            ViewBag.c = cri;
            ViewBag.p = prsnl;
            ViewBag.u = urn;






            var bul = c.SatisHarekets.Find(id);
            return View("satisGetir", bul);
        }


        public ActionResult satisGuncelle(SatisHareket s)
        {
            var stsguncel = c.SatisHarekets.Find(s.satisHateketID);
            stsguncel.urunid = s.urunid;
            stsguncel.personelid = s.personelid;
            stsguncel.cariid = s.cariid;
            stsguncel.satisHateketFiyat = s.satisHateketFiyat;
            stsguncel.satisHateketAdet = s.satisHateketAdet;
            stsguncel.satisHateketToplamTutar = s.satisHateketToplamTutar;
            stsguncel.satisHateketTarih = s.satisHateketTarih;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult satisDetay(int id)
        {

            var stsdty = c.SatisHarekets.Where(x => x.satisHateketID == id).ToList();

            var stsad = c.SatisHarekets.Where(x => x.satisHateketID == id).Select(y => y.Personel.personelAd + " " + y.Personel.personelSoyad).FirstOrDefault();

            ViewBag.ad = stsad;


            return View(stsdty);
        }
    }
}