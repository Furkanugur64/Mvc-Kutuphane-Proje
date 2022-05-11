using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProje.Models.Entity;
namespace MvcKutuphaneProje.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBL_KITAPLAR select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            }
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBL_KATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from i in db.TBL_YAZARLAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBL_KITAPLAR k)
        {
            var ktg = db.TBL_KATEGORILER.Where(x => x.ID == k.TBL_KATEGORILER.ID).FirstOrDefault();
            var yzr = db.TBL_YAZARLAR.Where(x => x.ID == k.TBL_YAZARLAR.ID).FirstOrDefault();
            k.TBL_KATEGORILER = ktg;
            k.TBL_YAZARLAR = yzr;
            db.TBL_KITAPLAR.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var sil = db.TBL_KITAPLAR.Find(id);
            db.TBL_KITAPLAR.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TBL_KITAPLAR.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBL_KATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from i in db.TBL_YAZARLAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGuncelle(TBL_KITAPLAR k)
        {
            var kitap = db.TBL_KITAPLAR.Find(k.ID);
            kitap.AD = k.AD;
            kitap.BASIMYIL = k.BASIMYIL;
            kitap.SAYFA = k.SAYFA;
            kitap.YAYINEVI = k.YAYINEVI;
            k.DURUM = true;
            var ktg = db.TBL_KATEGORILER.Where(x => x.ID == k.TBL_KATEGORILER.ID).FirstOrDefault();
            var yzr = db.TBL_YAZARLAR.Where(x => x.ID == k.TBL_YAZARLAR.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}