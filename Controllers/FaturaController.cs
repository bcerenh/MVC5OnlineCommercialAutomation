using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using MvcWebTicariOtomasyon.Models.Siniflar;

namespace MvcWebTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura

        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturas.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura f1)
        {
            c.Faturas.Add(f1);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturas.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Fatura f1)
        {
            var fatura = c.Faturas.Find(f1.FaturaID);
            fatura.FaturaSeriNo = f1.FaturaSeriNo;
            fatura.FaturaSiraNo = f1.FaturaSiraNo;
            fatura.FaturaSaat = f1.FaturaSaat;
            fatura.FaturaTarih = f1.FaturaTarih;
            fatura.TeslimEden = f1.TeslimEden;
            fatura.TeslimAlan = f1.TeslimAlan;
            fatura.VergiDairesi = f1.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Dinamik()
        {
            Class3 ccs = new Class3();
            ccs.deger1 = c.Faturas.ToList();
            ccs.deger2 = c.FaturaKalems.ToList();
            return View(ccs);
        }
        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSiraNo, DateTime FaturaTarih,
                                         string VergiDairesi, string FaturaSaat, string TeslimEden, string TeslimAlan, string Toplam,
                                         FaturaKalem[] FaturaKalems)
        {
            Fatura f = new Fatura();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSiraNo;// sol taraf property iken sağ taraf ise parametrnin kendisi
            f.FaturaTarih = FaturaTarih;
            f.VergiDairesi = VergiDairesi;
            f.FaturaSaat = FaturaSaat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.Toplam = decimal.Parse(Toplam);
            c.Faturas.Add(f);
            foreach (var x in FaturaKalems)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.FaturaAcıklamasi = x.FaturaAcıklamasi;// buradaki x dışarıdan gelen değerleri tutacak yani popup ekranında gelen bilgileri
                fk.UrunBirimFiyat = x.UrunBirimFiyat;
                fk.Miktar = x.Miktar;
                fk.UrunTutar = x.UrunTutar;
                fk.Faturaid = x.FaturaKalemID;
                c.FaturaKalems.Add(fk);//fk den gelen değerleri faturakalems içine eklesin
            }
            c.SaveChanges(); //bunu yazmayınca sql kaydetme yapmaz
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }

    }
}