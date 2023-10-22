using System;
using System.Collections.Generic;
using System.Linq;
using MvcWebTicariOtomasyon.Models.Siniflar;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MvcWebTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {

        // GET: CariPanel
        Context c = new Context();
        [Authorize] //authorize yapıldığında sistem kullancı adı ve şifre girmeden işlem yapmasın diye
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.mesajs.Where(x => x.Alici == mail).ToList();
            ViewBag.m = mail;
            var mailid=c.Caris.Where(x=>x.CariMail==mail).Select(y => y.CariId).FirstOrDefault(); //sisteme giriş yapan 
            //mail adresinin cariid bulma
            ViewBag.mid = mailid;
            var toplamsatis=c.SatisHareketis.Where(x=>x.CariId==mailid).Count();
            ViewBag.toplamsatis = toplamsatis;
            var toplamtutar = c.SatisHareketis.Where(x => x.CariId == mailid).Sum(y => (decimal?)y.ToplamTutar);
            ViewBag.toplamtutar = toplamtutar;
            var toplamurunsayisi = c.SatisHareketis.Where(x => x.CariId == mailid).Sum(y => (decimal?)y.Adet);
            ViewBag.toplamurunsayisi=toplamurunsayisi;
            var adsoyad = c.Caris.Where(x => x.CariId == mailid).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparişlerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var degerler = c.SatisHareketis.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajs.Where(x=>x.Alici==mail).OrderByDescending(x=>x.MesajID).ToList();
            var gelenmesajsayisi = c.mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;
            var gidenmesajsayisi = c.mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenmesajsayisi;
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajs.Where(x => x.Gonderici == mail).OrderByDescending(k=>k.MesajID).ToList();
            var gelenmesajsayisi = c.mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;
            var gidenmesajsayisi = c.mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenmesajsayisi;
            return View(mesajlar);
        }
        public ActionResult MesajDetayı(int id)
        {
            var degerler = c.mesajs.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelenmesajsayisi = c.mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;
            var gidenmesajsayisi = c.mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenmesajsayisi;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelenmesajsayisi = c.mesajs.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;
            var gidenmesajsayisi = c.mesajs.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenmesajsayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(mesaj m)
        {
            var mail = (string)Session["CariMail"];
            m.Gonderici = mail;
            m.Tarih = DateTime.Parse(DateTime.Now.ToString());
            c.mesajs.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult KargoTakip(string p)
        {
            var kargolar = from x in c.KargoDetays select x;
           
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));
            
            return View(kargolar.ToList()); //aramada kargolar çıksın diye listelemeye ihtiyaç duyuluyor
            //kargo tkip koduna göre ürün getirme
        }
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList(); //kargtakipten gelen kodu listele
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();//istekleri yerine getrirsin diye
            return RedirectToAction ("Index","Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id=c.Caris.Where(x=>x.CariMail==mail).Select(y=>y.CariId).FirstOrDefault();
            var caribul = c.Caris.Find(id);
            return PartialView("Partial1", caribul);
            
        }
        public PartialViewResult Partial2()
        {
            var veriler=c.mesajs.Where(x=>x.Gonderici=="admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariSifreGuncelle(Cari crr) //carilerden güncelleme olacağı için bu ismi yazdık
        {
            var car = c.Caris.Find(crr.CariId);
            car.CariAd=crr.CariAd;
            car.CariSoyad = crr.CariSoyad;
            car.CariMail = crr.CariMail;
            car.CariSifre = crr.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
