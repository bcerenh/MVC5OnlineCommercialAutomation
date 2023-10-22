using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Display(Name="Personel Adı")]

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Display(Name = "Görsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareketi> SatisHareketis { get; set; }
        public virtual Departmant Departmant { get; set; }  //her personelde bir departmana ait olacağı için tanımlandı
        public int DepartmantID { get; set; }
        
    }
}
