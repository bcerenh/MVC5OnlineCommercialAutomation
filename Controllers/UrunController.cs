using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcWebTicariOtomasyon.Models.Siniflar;

namespace MvcWebTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p) //arama fonksiyonu için p paramteresi aynı olmak zorunda
        {
            var urunler = from x in c.Uruns select x;
            if(!string.IsNullOrEmpty(p))
            {
                urunler=urunler.Where(y=>y.UrunAd.Contains(p));
            }
            return View(urunler.ToList()); //aramada ürünler çıksın diye listelemeye ihtiyaç duyuluyor
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }) .ToList();
            ViewBag.dgr1 = deger1;//viewbag taşımak için kullanılıyor değeri atadık dgr1'e
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                u.UrunGorsel = "/Image/" + dosyaadi + uzanti;
                //bu ksıım file uopload yardımı ile resim görseli yükleme
            }
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id);
            urun.UrunDurum = false;
            c.Uruns.Remove(urun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urune = c.Uruns.Find(id);
            return View("UrunGetir", urune);
        }
        public ActionResult UrunGuncelle(Urun u, HttpPostedFileBase UrunGorsel)
        {
            var urn = c.Uruns.Find(u.UrunID);
            urn.UrunAlisFiyat = u.UrunAlisFiyat;
            urn.UrunSatisFiyat = u.UrunSatisFiyat;
            urn.UrunDurum = u.UrunDurum;
            urn.Kategoriid = u.Kategoriid;
            urn.UrunMarka = u.UrunMarka;
            urn.UrunStok = u.UrunStok;
            //urn.UrunGorsel = u.UrunGorsel;
            urn.UrunAd = u.UrunAd;
            if (ModelState.IsValid)
            {
                if (UrunGorsel != null)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    urn.UrunGorsel = "/Image/" + dosyaadi + uzanti;  //urn olması gerekir
                    //bu ksıım file uopload yardımı ile resim görseli yükleme
                }
            }
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> personeldegeri = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + "" + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.personeldegeri = personeldegeri;
            var urundegeri = c.Uruns.Find(id);
            ViewBag.urundegeri = urundegeri.UrunID;
            var fiyatdegeri=c.Uruns.Find(id);
            ViewBag.fiyatdegeri = urundegeri.UrunSatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareketi p)
        {
            p.SatisTarihi = DateTime.Parse(DateTime.Now.ToString());
            c.SatisHareketis.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}