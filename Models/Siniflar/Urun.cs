using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]

        //ürün Marka ve Ürün Addan önce bu kalıp yazıldı ve  kısıtlama getirildi 
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunMarka { get; set; }
        public short UrunStok { get; set; }
        public decimal UrunAlisFiyat { get; set; }
        public decimal UrunSatisFiyat { get; set; }
        public bool UrunDurum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public int Kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; } //her ürünün bir kategorisi olacağı için burada kategori propertysi oluşturduk    }
        //virtual ürünlerin kategorisini çekmek için kullanıyoruz
        public ICollection<SatisHareketi> SatisHareketis { get; set; } //her ürünün birden çok satışı olabilir
    }
}
