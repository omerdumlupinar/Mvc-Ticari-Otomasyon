using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Sınıflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel

        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["cariMail"];

            var degerler = c.Carilers.FirstOrDefault(x => x.cariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }

        [Authorize]
        public ActionResult siparişlerim()
        {
            var mail = (string)Session["cariMail"];
            var id = c.Carilers.Where(x => x.cariMail == mail).Select(y => y.cariID).FirstOrDefault();
            var liste = c.SatisHarekets.Where(x => x.cariid == id).ToList();
            return View(liste);
        }
    }
}