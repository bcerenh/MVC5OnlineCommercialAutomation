using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class Class2
    {
        public IEnumerable<SelectListItem> Kategori { get; set; }
        //Listeleme olacağı için IEnumerable kullanılıyor            
        //kategroiler ve ürünleri birlikte getirecğimiz için sınıfta iki tür tanımladık cascading
        public IEnumerable<SelectListItem> Urun { get; set; }
    }
}