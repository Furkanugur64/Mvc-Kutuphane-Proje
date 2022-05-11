using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProje.Models.Entity;

namespace MvcKutuphaneProje.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBL_UYELER.Count();
            var deger2 = db.TBL_KITAPLAR.Count();
            var deger3 = db.TBL_HAREKETLER.Where(x=>x.ISLEMDURUM==false).Count();
            var deger4 = db.TBL_CEZALAR.Sum(x => x.PARA);
            ViewBag.Uye = deger1;
            ViewBag.Kitap = deger2;
            ViewBag.Emanet = deger3;
            ViewBag.Para = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        public ActionResult LinqKartlar()
        {
            var deger1 = db.TBL_KITAPLAR.Count();
            var deger2 = db.TBL_UYELER.Count();
            var deger3 = db.TBL_CEZALAR.Sum(x => x.PARA);
            var deger4 = db.TBL_HAREKETLER.Where(x => x.ISLEMDURUM == false).Count();
            var deger5 = db.TBL_KATEGORILER.Count();
            var deger6 = db.TBL_ILETISIM.Count();
            var deger7 = db.Eniyipersonel().FirstOrDefault();
            var deger8 = db.Enaktifuye().FirstOrDefault();
            var deger9 = db.Eniyikitap().FirstOrDefault();
            var deger10 = db.Yazar().FirstOrDefault();
            var deger11 = db.YAYINEVI().FirstOrDefault();
            var deger12 = db.KATEGORI().FirstOrDefault();
            
            ViewBag.Kıtap = deger1;
            ViewBag.Uye = deger2;
            ViewBag.Kasa = deger3;
            ViewBag.Emanet = deger4;
            ViewBag.Kategori = deger5;
            ViewBag.Iletisim = deger6;
            ViewBag.Personel = deger7;
            ViewBag.Aktıfuye = deger8;
            ViewBag.Kıtap2 = deger9;
            ViewBag.Yazar = deger10;
            ViewBag.Yayınevi = deger11;
            ViewBag.Kategori = deger12;
            return View();
        }
    }
}