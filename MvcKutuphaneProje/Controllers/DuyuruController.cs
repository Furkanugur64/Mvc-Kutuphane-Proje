using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProje.Models.Entity;

namespace MvcKutuphaneProje.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_DUYURULAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(TBL_DUYURULAR p)
        {
            db.TBL_DUYURULAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruGetir(TBL_DUYURULAR p)
        {
            var duyuru = db.TBL_DUYURULAR.Find(p.ID);
            return View("DuyuruGetir",duyuru);
        }
        public ActionResult DuyuruGuncelle(TBL_DUYURULAR t)
        {
            var duyuru = db.TBL_DUYURULAR.Find(t.ID);
            duyuru.KATEGORI = t.KATEGORI;
            duyuru.TARIH = t.TARIH;
            duyuru.ICERIK = t.ICERIK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Duyurusil(int id)
        {
            var silinecek = db.TBL_DUYURULAR.Find(id);
            db.TBL_DUYURULAR.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}