using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebTicariOtomasyon.Models.Siniflar;
namespace MvcWebTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c =new Context();
        public ActionResult Index()
        {
            Class1 class1 = new Class1();
            class1.Deger1=c.Uruns.Where(x=>x.UrunID==8).ToList();
            class1.Deger2 = c.Detays.Where(x => x.DetayID == 1).ToList();
            //var degerler=c.Uruns.Where(x=>x.UrunID==8).ToList();    
            return View(class1);
        }
    }
}