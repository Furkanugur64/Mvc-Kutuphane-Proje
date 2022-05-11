using MvcKutuphaneProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphaneProje.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKETLER.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TBL_UYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + ""+ x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in db.TBL_KITAPLAR.Where(x=>x.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in db.TBL_PERSONELLER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PERSONEL,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKETLER k)
        {
            var uye = db.TBL_UYELER.Where(x => x.ID == k.TBL_UYELER.ID).FirstOrDefault();
            var ktp = db.TBL_KITAPLAR.Where(x => x.ID == k.TBL_KITAPLAR.ID).FirstOrDefault();
            var per = db.TBL_PERSONELLER.Where(x => x.ID == k.TBL_PERSONELLER.ID).FirstOrDefault();
            k.TBL_UYELER = uye;
            k.TBL_KITAPLAR = ktp;
            k.TBL_PERSONELLER = per;
            db.TBL_HAREKETLER.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Odunciade(TBL_HAREKETLER p)
        {
            
            var odunc = db.TBL_HAREKETLER.Find(p.ID);
            DateTime d1 = DateTime.Parse(odunc.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Odunciade", odunc);
        }
        public ActionResult OduncGuncelle(TBL_HAREKETLER p)
        {
            var dgr = db.TBL_HAREKETLER.Find(p.ID);
            dgr.UYEGETIRTARIH = p.UYEGETIRTARIH;
            dgr.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}