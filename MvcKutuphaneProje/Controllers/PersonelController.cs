using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProje.Models.Entity;
namespace MvcKutuphaneProje.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_PERSONELLER.ToList();
            return View(degerler);
        }
        
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBL_PERSONELLER k)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBL_PERSONELLER.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var sil = db.TBL_PERSONELLER.Find(id);
            db.TBL_PERSONELLER.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var ktgr = db.TBL_PERSONELLER.Find(id);
            return View("PersonelGetir", ktgr);

        }
        public ActionResult PersonelGuncelle(TBL_PERSONELLER k)
        {
            var prs = db.TBL_PERSONELLER.Find(k.ID);
            prs.PERSONEL = k.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}