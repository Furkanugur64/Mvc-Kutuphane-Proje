using Microsoft.Win32;
using MvcKutuphaneProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphaneProje.Controllers
{
    public class PanelimController : Controller
    {
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        // GET: Panelim
        
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBL_UYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var uyeid = db.TBL_UYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var kitap = db.TBL_HAREKETLER.Where(x => x.UYE == uyeid).ToList();
            return View(kitap);
        }
        public ActionResult Duyurular()
        {
            var duyuru = db.TBL_DUYURULAR.ToList();
            return View(duyuru);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}