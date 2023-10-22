using MvcWebTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcWebTicariOtomasyon.Controllers
{
    [AllowAnonymous] //bu global sayfasındaki authorize yapmanda bu sayfayı muaf et demek
    public class LoginController : Controller
    {
        Context c=new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()  //neden partial eklemeye ihtiyaç duyuluyor
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cari p)  //neden partial eklemeye ihtiyaç duyuluyor
        {
            c.Caris.Add(p);
            c.SaveChanges();
            return PartialView();

        }
        [HttpGet]
        public ActionResult CariLogin1()  
        {
            
            return View();

        }
        [HttpPost]
        public ActionResult CariLogin1(Cari ca)
        {
            var bilgiler = c.Caris.FirstOrDefault(x => x.CariMail == ca.CariMail && x.CariSifre == ca.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"]=bilgiler.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }

        }

        [HttpGet]
        public ActionResult AdminLogin1()
        {

            return View();

        }
        [HttpPost]
        public ActionResult AdminLogin1(Admin adm)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAdi == adm.KullaniciAdi && x.AdminSifre == adm.AdminSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

    }
}