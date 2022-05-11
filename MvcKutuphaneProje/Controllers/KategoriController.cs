using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProje.Models.Entity;

namespace MvcKutuphaneProje.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_KATEGORILER.Where(x => x.DURUM == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBL_KATEGORILER k)
        {
            db.TBL_KATEGORILER.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
          var kategori=  db.TBL_KATEGORILER.Find(id);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_KATEGORILER.Find(id);
            return View("KategoriGetir", ktgr);

        }
        public ActionResult KategoriGuncelle(TBL_KATEGORILER k)
        {
           var ktg= db.TBL_KATEGORILER.Find(k.ID);
            ktg.AD = k.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}