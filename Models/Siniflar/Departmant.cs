using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class Departmant
    {
        [Key]
        public int DepartmantID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmantAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel>Personels  { get; set; } //departmant ICollection ile personelleri topluyor
    }
}
