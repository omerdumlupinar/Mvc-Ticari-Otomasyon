using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{

    
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var deparmanList = c.Departmen.Where(x=>x.departmanDurum==true).ToList();
            return View(deparmanList);
        }
        [HttpGet]
        public ActionResult departmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult departmanEkle(Departman d)
        {
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult departmanSil(int id)
        {
            var dprtBul = c.Departmen.Find(id);
            dprtBul.departmanDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult departmanGetir(int id)
        {
            var dprtGetir = c.Departmen.Find(id);
            return View ("departmanGetir", dprtGetir);
        }

        public ActionResult departmanGuncelle(Departman d)
        {
            var dprtGuncel = c.Departmen.Find(d.departmanID);
            dprtGuncel.departmanAd = d.departmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult departmanDetay(int id)
        {
            var departmanDetayList = c.Personels.Where(x => x.departmanid == id).ToList();
            var dprt = c.Departmen.Where(x => x.departmanID == id).Select(x => x.departmanAd).FirstOrDefault();
            ViewBag.d = dprt;
            return View(departmanDetayList);
        }

        public ActionResult departmanPersoneSatıslar(int id)
        {
            var dprtprsnlsts = c.SatisHarekets.Where(x => x.personelid == id).ToList();
            var dprtcariad = c.Personels.Where(x => x.personelID == id).Select(x=>x.personelAd+" "+x.personelSoyad).FirstOrDefault();
            ViewBag.ad = dprtcariad;
            return View(dprtprsnlsts);
        }
    }
}