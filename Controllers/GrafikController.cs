using MvcWebTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcWebTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafik = new Chart(width: 500, height: 500);
            grafik.AddTitle(text: "Kategoriler ve Ürün Sayıları");
            grafik.AddLegend(title: "Değerler");
            grafik.AddSeries(name: "Veriler",
                chartType: "Bar", //chart tpini seçebilrsin 
                xValue: new[] { "Beyaz Eşya", "Küçük Ev Aletleri", "Buzdolabı", "Telefon" },
                yValues: new[] { 100, 200, 300, 400 });
            grafik.Write();
            return File(grafik.ToWebImage().GetBytes(),"image/jpeg");
        }
        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xva = new ArrayList();
            ArrayList yva = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xva.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yva.Add(y.UrunStok));
            var grafik = new Chart(width: 500, height: 500).AddTitle("Stoklar").AddSeries(chartType:"Column",name:"Stok",xValue:xva,yValues:yva);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult() //visualize etmek için bu method kullanılır
        {
            return Json(urunlistesi(),JsonRequestBehavior.AllowGet);
        }
        public List<sinif1> urunlistesi()
        {
            List<sinif1> us = new List<sinif1>();
            us.Add(new sinif1()
                {
                UrunAd="Bilgisayar",
                UrunStok=120,

            });
            us.Add(new sinif1()
            {
                UrunAd = "Kuçük Ev Aletleri",
                UrunStok = 15,

            });
            return us;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(urunlistesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif2> urunlistesi2()
        {
            List<sinif2> us = new List<sinif2>();
           using(var c =new Context())
            {
                us=c.Uruns.Select(x => new sinif2
                    {
                    urn=x.UrunAd,
                    stk=x.UrunStok,
                }).ToList();    
            }
           return us;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}