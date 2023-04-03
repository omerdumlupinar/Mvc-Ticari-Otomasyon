using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;
using System.IO;

namespace MvcTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var personelList = c.Personels.ToList();
            return View(personelList);
        }
        [HttpGet]
        public ActionResult personelEkle()
        {
            List<SelectListItem> deger = (from x in c.Departmen.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.departmanAd,
                                              Value = x.departmanID.ToString()
                                          }).ToList();
            ViewBag.departmanAdi = deger;

            return View();
        }
        [HttpPost]
        public ActionResult personelEkle(Personel p)
        {


            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.personelGorsel = "/image/" + dosyaAdi + uzanti;
            }

            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelGetir(int id)
        {
            List<SelectListItem> deger = (from x in c.Departmen.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.departmanAd,
                                              Value = x.departmanID.ToString()
                                          }).ToList();
            ViewBag.departmanAdi = deger;



            var personelidgetir = c.Personels.Find(id);
            return View("personelGetir", personelidgetir);
        }

        public ActionResult personelGuncelle(Personel p)
        {

            var personelbul = c.Personels.Find(p.personelID);


            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.personelGorsel = "/image/" + dosyaAdi + uzanti;
            }





            
            personelbul.personelAd = p.personelAd;
            personelbul.personelSoyad = p.personelSoyad;
            personelbul.personelGorsel = p.personelGorsel;
            personelbul.departmanid = p.departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelSatıs(int id)
        {
            var prsnlsts = c.SatisHarekets.Where(x => x.personelid == id).ToList();
            var prsnlad = c.SatisHarekets.Where(x => x.personelid == id).Select(x => x.Personel.personelAd + " " + x.Personel.personelSoyad).FirstOrDefault();
            ViewBag.ad = prsnlad;
            return View(prsnlsts);
        }

        public ActionResult PersonelListe()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
    }
}


