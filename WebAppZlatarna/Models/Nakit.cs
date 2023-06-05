using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppZlatarna.Models;

namespace WebAppZlatarna.Models
{
    public class Nakit
    {
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // iskljucujemo s ovim AUTO_INTCREMENT
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Datum nabave")]
        [DataType(DataType.Date)]
        public DateTime DatumNabave { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Slika")]
        public string SlikaUrl { get; set; }
        [Display(Name = "Kategorija")]
        public int KategorijaId { get; set; }
        // veza - svaki nakit moze imati jednu kategoriju na sebi
        public Kategorija Kategorija { get; set; }
    }
}
