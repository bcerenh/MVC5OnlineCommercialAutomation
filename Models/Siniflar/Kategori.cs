using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection<Urun>Uruns { get; set; } //her ürünün bir kategorisi olur ama kategoride birden çok ürün olabilir
        // o yüzden ICollection yapısı kullanılır.
    }
}
