using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppZlatarna.Models
{
    public class Kategorija
    {
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // iskljucujemo AUTO_INTCREMENT
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        public string Naziv { get; set; }
        //veza - svaka kategorija moze imati vise nakita na sebi
        public List<Nakit> Nakiti { get; set; }

    }
}
