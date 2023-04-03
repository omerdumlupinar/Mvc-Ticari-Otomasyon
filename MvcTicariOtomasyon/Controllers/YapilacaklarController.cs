using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class YapilacaklarController : Controller
    {
        // GET: Yapilacaklar
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var musteriSayisi = c.Carilers.Count();
            ViewBag.musteri = musteriSayisi;

            var urunSayisi = c.Uruns.Count();
            ViewBag.urunsayi = urunSayisi;


            var kategorisayisi = c.Kategoris.Count();
            ViewBag.kategori = kategorisayisi;

            var cariSehir = (from x in c.Carilers select x.cariSehir).Distinct().Count().ToString();
            ViewBag.sehir = cariSehir;




            var deger = c.Yapilacaklars.ToList();
            var deger2 = c.Yapilacaklars;





            return View(deger);
        }
    }
}