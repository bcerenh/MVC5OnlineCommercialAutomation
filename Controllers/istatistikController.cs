using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcWebTicariOtomasyon.Models.Siniflar;

namespace MvcWebTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context c =new Context();
        public ActionResult Index()
        {
            var deger1=c.Caris.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString(); 
            ViewBag.d4 = deger4;
            var deger5 = c.Uruns.Sum(x => x.UrunStok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Uruns select x.UrunMarka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Uruns.Count(x => x.UrunStok <=20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Uruns orderby x.UrunSatisFiyat descending select x.UrunAd).FirstOrDefault();
            //Firstordefault ilk ürün çek demek
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Uruns orderby x.UrunSatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.Uruns.GroupBy(x => x.UrunMarka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = c.Uruns.Where(u => u.UrunID == c.SatisHareketis.GroupBy(x => x.UrunID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.SatisHareketis.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;
            //bugünkü satışlar için 
            DateTime today = DateTime.Today;
            var deger15 = c.SatisHareketis.Count(x=>x.SatisTarihi==today).ToString();
            ViewBag.d15 = deger15;

            var deger16 = c.SatisHareketis.Where(x => x.SatisTarihi == today).Sum(y => (decimal?)y.ToplamTutar).ToString();
            //bir önceki satırda (decimal?) kullanılmasının nedeni nullable type yani kasa günlük satış yapmadıysa null olarak hata döndürmesin diye
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            //var sorgu = from x in c.Caris
            //            group x by x.CariSehir into g
            //            select new SinifGrup
            //            {
            //                Sehir = g.Key,
            //                Sayi = g.Count()
            //            };
            //return View(sorgu.ToList());
            //ŞEHİRLERİ alfabetik sıraya göre sıralama
            var sorgu = from x in c.Caris
                       group x by x.CariSehir into g
                       orderby g.Count() descending // Şehir sayısına göre sıralama
                       select new SinifGrup
                       {
                           Sehir = g.Key,
                           Sayi = g.Count()
                       };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departmant.DepartmantAd into g
                         select new SinifGrup2
                         {
                             Departmant = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu3=c.Caris.ToList();
            return PartialView(sorgu3);
        }
        public PartialViewResult Partial3()
        {
            var sorgu4 = c.Uruns.ToList();
            return PartialView(sorgu4);
        }
        public PartialViewResult Partial4()
        {
            var sorgu5 = from x in c.Uruns
                         group x by x.UrunMarka into g
                         select new SinifGrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu5.ToList());
        }
    }
}