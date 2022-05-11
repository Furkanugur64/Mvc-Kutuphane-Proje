using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcKutuphaneProje.Models.Entity;
using System.Web.UI.WebControls;

namespace MvcKutuphaneProje.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBL_UYELER.ToList().ToPagedList(sayfa,7);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBL_UYELER k)
        {
            
            db.TBL_UYELER.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBL_UYELER.Find(id);
            db.TBL_UYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBL_UYELER.Find(id);
            return View("UyeGetir", uye);

        }
        public ActionResult UyeGuncelle(TBL_UYELER p)
        {
            var uye = db.TBL_UYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitap (int id)
        {
            var kitaplar = db.TBL_HAREKETLER.Where(x => x.UYE == id).ToList();
            var uyead = db.TBL_UYELER.Where(x => x.ID == id).Select(y => y.AD + "" + y.SOYAD).FirstOrDefault();
            ViewBag.Uye = uyead;
            return View(kitaplar);
        }
    }
}