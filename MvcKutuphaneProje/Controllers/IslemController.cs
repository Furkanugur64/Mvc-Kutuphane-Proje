using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneProje.Models.Entity;

namespace MvcKutuphaneProje.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKETLER.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}