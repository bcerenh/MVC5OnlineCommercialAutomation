using MvcWebTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context c = new Context();
        // GET: Kargo
        public ActionResult Index(string p)
        {
            var kargolar = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargolar.ToList()); //aramada kargolar çıksın diye listelemeye ihtiyaç duyuluyor
            //kargo tkip koduna göre ürün getirme
           
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D" ,"E","F"};
            int k1, k2, k3;
            k1=random.Next(0,karakterler.Length);
            k2=random.Next(0,karakterler.Length);
            k3=random.Next(0,karakterler.Length);
            int s1, s2, s3;
            s1=random.Next(100,1000); //10 karakter olması gerekecek
            s2 =random.Next(10,99);
            s3 =random.Next(10,99);
            string takipkod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2]+s3+karakterler[k3];
            ViewBag.takipkod = takipkod;
            return View();
            //10 haneli rastegele takip kodu oluştruma
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoDetay(string  id)

            //BURASI ÇOK ÖNEMLİ ROUTE CONFİG AYARINDA "id" OLDUĞU İÇİN BURADA DA "id" TANIMLANDI
            //GLOBAL.ASAX.CS DOSYASINDA ROUTECONFIG TANIMA GİT DEDĞİNDE "id" görürsün 
            //o yüzden globalde id olmak zorunda
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList(); //kargtakipten gelen kodu listele
            return View(degerler);
        }
    }

}