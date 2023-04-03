using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class istatistiklerController : Controller
    {
        // GET: istatistikler
        Context c = new Context();
        public ActionResult Index()
        {
            var cariler = c.Carilers.Count().ToString();
            ViewBag.cari = cariler;

            var urunler = c.Uruns.Count().ToString();
            ViewBag.urun = urunler;

            var personel = c.Personels.Count().ToString();
            ViewBag.person = personel;

            var kategori = c.Kategoris.Count().ToString();
            ViewBag.ktgr = kategori;



            var urunStok = c.Uruns.Sum(x => x.urunStok).ToString();
            ViewBag.urunSTK = urunStok;

            var markaSayısı = (from x in c.Uruns select x.urunmarka).Distinct().Count().ToString();
            ViewBag.marka = markaSayısı;

            var kritikSeviye = c.Uruns.Count(x => x.urunStok < 10).ToString();
            ViewBag.kritik = kritikSeviye;

            var maxUrun = (from x in c.Uruns orderby x.urunSatisFiyat descending select x.urunAd).FirstOrDefault();
            ViewBag.max = maxUrun;

            var minUrun = (from x in c.Uruns orderby x.urunSatisFiyat ascending select x.urunAd).FirstOrDefault();
            ViewBag.min = minUrun;




            var buzdolabıSayisi = c.Uruns.Count(x => x.urunAd == "Buzdolabı").ToString();
            ViewBag.bDolabıSayisi = buzdolabıSayisi;

            var leptopSayisi = c.Uruns.Count(x => x.urunAd == "Leptop").ToString();
            ViewBag.lptpSayisi = leptopSayisi;



            var maxMarka = c.Uruns.GroupBy(x => x.urunmarka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.mxMarka = maxMarka;


            var enCokSATAN = c.Uruns.Where(u => u.urunID == (c.SatisHarekets.GroupBy(x => x.urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.urunAd).FirstOrDefault();
            ViewBag.enSatan = enCokSATAN;



            var kasadakiTutar = c.SatisHarekets.Sum(x => x.satisHateketToplamTutar).ToString();
            ViewBag.kasaToplam = kasadakiTutar;


            
            var bugunsts = c.SatisHarekets.Count(x => x.satisHateketTarih == DateTime.Today).ToString();
            ViewBag.bugunSatis = bugunsts;



            try
            {
                var bugunStsToplam = c.SatisHarekets.Where(x => x.satisHateketTarih == DateTime.Today).Sum(y => y.satisHateketToplamTutar).ToString();
                ViewBag.bugunToplam = bugunStsToplam;
            }
            catch (System.InvalidOperationException)
            {
                ViewBag.bugunToplam = 0;

            }



           

           
                








            return View();
        }
    }
}