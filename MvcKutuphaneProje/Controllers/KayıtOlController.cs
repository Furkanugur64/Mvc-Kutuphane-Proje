using MvcKutuphaneProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcKutuphaneProje.Controllers
{
    public class KayıtOlController : Controller
    {
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        // GET: KayıtOl
        [HttpGet]
        public ActionResult Kayıt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayıt(TBL_UYELER t)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayıt");
            }
            db.TBL_UYELER.Add(t);
            db.SaveChanges();
            return View();
        }
    }
}