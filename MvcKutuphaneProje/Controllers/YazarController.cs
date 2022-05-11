using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProje.Models.Entity;

namespace MvcKutuphaneProje.Controllers
{
    public class YazarController : Controller
    {
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_YAZARLAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBL_YAZARLAR p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBL_YAZARLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBL_YAZARLAR.Find(id);
            db.TBL_YAZARLAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBL_YAZARLAR.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TBL_YAZARLAR t)
        {
            var yeni = db.TBL_YAZARLAR.Find(t.ID);
            yeni.AD = t.AD;
            yeni.SOYAD = t.SOYAD;
            yeni.DETAY = t.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Yazarkitap(int id)
        {
            var yazar = db.TBL_KITAPLAR.Where(x => x.YAZAR == id).ToList();
            var yazarad = db.TBL_YAZARLAR.Where(x => x.ID == id).Select(y => y.AD + " " + y.SOYAD).FirstOrDefault();
            ViewBag.Yazar = yazarad;
            return View(yazar);
        }
       
    }
}