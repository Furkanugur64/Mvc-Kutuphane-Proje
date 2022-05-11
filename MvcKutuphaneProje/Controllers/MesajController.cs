using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProje.Models.Entity;

namespace MvcKutuphaneProje.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var degerler = db.TBL_MESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Yenimesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yenimesaj(TBL_MESAJLAR t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.GONDEREN = uyemail.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_MESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("Gidenmesaj");
        }
        public ActionResult Gidenmesaj()
        {
            var mailim = (string)Session["Mail"].ToString();
            var degerler = db.TBL_MESAJLAR.Where(x => x.GONDEREN == mailim.ToString()).ToList();
            return View(degerler);
        }
    }
}