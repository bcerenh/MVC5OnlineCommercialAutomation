using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using MvcWebTicariOtomasyon.Models.Siniflar;

namespace MvcWebTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c =new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHareketis.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
           
            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd +" "+x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
           


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
                       return View();
           
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareketi s)
        {
            s.SatisTarihi = DateTime.Parse(DateTime.Now.ToString());
            c.SatisHareketis.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                               
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + "" + x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + "" + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

           

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var sts = c.SatisHareketis.Find(id);
            return View("SatisGetir", sts);
        }
        public ActionResult SatisGuncelle(SatisHareketi p)
        {
            var degr = c.SatisHareketis.Find(p.SatisHareketiID);
            degr.CariId=p.CariId;
            degr.Adet = p.Adet;
            degr.Fiyat = p.Fiyat;
            degr.PersonelID=p.PersonelID;
            degr.SatisTarihi = p.SatisTarihi;
            degr.ToplamTutar = p.ToplamTutar;
            degr.UrunID = p.UrunID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHareketis.Where(x => x.SatisHareketiID == id).ToList();
            return View(degerler);
        }

    }
}