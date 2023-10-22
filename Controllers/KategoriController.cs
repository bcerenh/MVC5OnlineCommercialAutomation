using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebTicariOtomasyon.Models.Siniflar;//sınıflara ulaşabilmek için model sınıfının dahil edilmesi gerekir 
using PagedList;
using PagedList.Mvc;

namespace MvcWebTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c=new Context();//context adında nesne üretilmesi için 
        //context sınıfında tablolar tutuluyor
        public ActionResult Index(int sayfa=1)  //listeleme işlemini index içinde gerçekleştireceğimiz için index için parametre yazdık
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,15);
            //var yazıldı çünkü tüm karakteristik,artimetik hepsini kapsar.
            //to list ile kategorideki değerleri listeler.
            //return ile de değerleri döndürüyor.
            return View(degerler);
        }
        [HttpGet]//burada ilk çağrıldığında değerler boş gelir
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]//burada değerleri ekler ve kaydeder
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kate = c.Kategoris.Find(id);
            return View("KategoriGetir",kate);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.KategoriID);
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme()
        {
            Class2 class2 = new Class2();
            class2.Kategori = new SelectList(c.Kategoris, "KategoriID", "KategoriAd");//burada dikkat ettiysen ikinci tarafta c. diyip context ten çekmeklazım
            class2.Urun = new SelectList(c.Uruns, "UrunID", "UrunAd");
            return View(class2);
        }
        public JsonResult UrunGetir(int p)
        {
            var urunlistesi = (from x in c.Uruns join y in c.Kategoris on x.Kategori.KategoriID equals y.KategoriID where x.Kategori.KategoriID == p select new
            {
                Text = x.UrunAd,
                Value=x.UrunID.ToString()
            }).ToList();
            return Json(urunlistesi, JsonRequestBehavior.AllowGet);
        }
    }
}