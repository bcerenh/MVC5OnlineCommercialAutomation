using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcWebTicariOtomasyon.Models.Siniflar;

namespace MvcWebTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmantController : Controller
    {
        // GET: Departmant

        Context c = new Context();
        public ActionResult Index()
        {
           
            var departmanlar = c.Departmants.Where(x=>x.Durum==true).ToList();
            return View(departmanlar);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult DepartmantEkle()
        {
            
            return View();
        }
        [HttpPost]
       
        public ActionResult DepartmantEkle(Departmant d)
        {
            d.Durum = true; //SQLDE DEĞERİ TRUE YAPMAK İÇİN BUNU EKLEDİM
            c.Departmants.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
          
        }
        public ActionResult DepartmantSil(int id)
        {
            var dpr = c.Departmants.Find(id);
            dpr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmantGetir(int id)
        {
            var depe = c.Departmants.Find(id);
            return View("DepartmantGetir", depe);
        }
        public ActionResult DepartmantGuncelle(Departmant k)
        {
            var dprt = c.Departmants.Find(k.DepartmantID);
            dprt.DepartmantAd = k.DepartmantAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmantDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmantID == id).ToList();
            var de=c.Departmants.Where(x=>x.DepartmantID==id).Select(y=>y.DepartmantAd).FirstOrDefault();
            //firstordefault tek değer seçmek için kullanılır
            //tolist tabloyu çekmek için kullanılır
            ViewBag.x = de;
            //viewbag controllerdeki değerleri view taşır
            //x sanal bir değer çok isim önemli değil, önemli olan "de" yi taşıması
            return View(degerler);
        }
        public ActionResult DepartmantPersonelSatis(int id)
        {
            var degerler1=c.SatisHareketis.Where(x=>x.PersonelID==id).ToList();
            var pers = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd+ " "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.re = pers;
            return View(degerler1);
        }

    }
}