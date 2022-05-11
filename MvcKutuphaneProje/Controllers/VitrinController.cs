using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProje.Models.Entity;
using MvcKutuphaneProje.Models.Siniflarim;
namespace MvcKutuphaneProje.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Kıtap = db.TBL_KITAPLAR.ToList();
            cs.Bılgı = db.TBL_HAKKIMIZDA.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBL_ILETISIM p)
        {
            db.TBL_ILETISIM.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}