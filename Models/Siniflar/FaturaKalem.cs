using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string FaturaAcıklamasi { get; set; }
        public int Miktar { get; set; }
        public decimal UrunBirimFiyat { get; set; }
        public decimal UrunTutar { get; set; }
        public int Faturaid { get; set; }
        
        public virtual Fatura Fatura { get; set; }
    }
}
