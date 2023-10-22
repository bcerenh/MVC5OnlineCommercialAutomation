using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebTicariOtomasyon.Models.Siniflar;
namespace MvcWebTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c=new Context();
        public ActionResult Index()
        {
            var car=c.Caris.Where(x=>x.Durum==true).ToList();
            return View(car);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cari car)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            car.Durum = true;
            c.Caris.Add(car);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var c1 = c.Caris.Find(id);
            c1.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var care = c.Caris.Find(id);
            return View("CariGetir", care);
        }
        public ActionResult CariGuncelle(Cari cr)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari12 = c.Caris.Find(cr.CariId);
            cari12.CariAd = cr.CariAd;
            cari12.CariSoyad = cr.CariSoyad;
            cari12.CariSehir = cr.CariSehir;
            cari12.CariMail = cr.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var satisdeg=c.SatisHareketis.Where(x=>x.CariId==id).ToList();
            return View(satisdeg);
        }
       
    }
}