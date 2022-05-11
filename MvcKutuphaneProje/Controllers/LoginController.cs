using MvcKutuphaneProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphaneProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DB_KutuphaneEntities db = new DB_KutuphaneEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBL_UYELER p)
        {
            var bilgiler = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                Session["Adı"] = bilgiler.AD.ToString();
                Session["Soyadı"] = bilgiler.SOYAD.ToString();
                
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}