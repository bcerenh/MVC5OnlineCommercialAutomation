using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KullaniciAdi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string AdminSifre { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Yetki { get; set; }

    }
}
