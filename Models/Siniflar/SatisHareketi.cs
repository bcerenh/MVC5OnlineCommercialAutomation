
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class SatisHareketi
    {
        [Key]
        public int SatisHareketiID { get; set; }
        //hangiürün
        //kimesatıldı
        //kimsattı
        public DateTime SatisTarihi { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int UrunID {get;set;}
        public int CariId { get; set; }

        public int PersonelID { get; set; }

       

        public virtual Urun Urun { get; set; } 
        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; }


    }
}
