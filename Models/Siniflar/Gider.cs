using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string GiderAciklama { get; set; }
        public DateTime Tarih { get; set; }
        public decimal GiderTutari { get; set; }
    }
}
