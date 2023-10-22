using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter girmelisiniz")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]

        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir{ get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]

        public string CariSifre { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariMail { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHareketi> SatisHareketis { get; set; }

    }
}
