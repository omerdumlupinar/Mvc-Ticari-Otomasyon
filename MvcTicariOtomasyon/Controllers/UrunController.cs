using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunlist = c.Uruns.Where(x => x.urunDurum == true ).ToList();
            return View(urunlist);
        }

        [HttpGet]
        public ActionResult urunEkle()
        {
            List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {

                                              Text = x.kategoriAd,
                                              Value = x.kategoriID.ToString()


                                          }).ToList();
            ViewBag.dgr = deger;
            return View();
        }

        [HttpPost]
        public ActionResult urunEkle(Urun u)
        {
            u.urunDurum = true;
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult urunSil(int id)
        {
            var urunbul = c.Uruns.Find(id);
            c.Uruns.Remove(urunbul);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult urunGetir(int id)
        {

            List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {

                                              Text = x.kategoriAd,
                                              Value = x.kategoriID.ToString()


                                          }).ToList();
            ViewBag.dgr = deger;




            var urundeger = c.Uruns.Find(id);   
            return View("UrunGetir", urundeger);

        }



        public ActionResult urunGuncelle(Urun u)
        {
            var urn = c.Uruns.Find(u.urunID);
            urn.urunAd = u.urunAd;
            urn.urunmarka = u.urunmarka;
            urn.urunAlisFiyat = u.urunAlisFiyat;
            urn.urunSatisFiyat = u.urunSatisFiyat;
            urn.urunStok = u.urunStok;
            urn.urunDurum = u.urunDurum;
            urn.urunGorsel = u.urunGorsel;
            urn.kategoriid = u.kategoriid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult urunListesi()
        {
            var list = c.Uruns.ToList();
            return View(list);
        }



    }

    
}