using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZavrsniLuksic.Model
{
    public class Restaurant
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Molimo unesite ime restorana")]
        [DisplayName("Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ime mora sadržavati barem 2 slova")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Molimo izaberite tip kuhinje")]
        [ForeignKey(nameof(Cuisine))]
        public int? CuisineID { get; set; }
        public Cuisine? Cuisine { get; set; }

        [Required(ErrorMessage = "Molimo unesite adresu restorana")]
        [DisplayName("Address")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Adresa mora sadržavati barem 2 slova")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Molimo unesite broj telefona")]
        [StringLength(10, ErrorMessage = "Maksimalan broj znakova je 10")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Dopuštene su samo znamenke 0-9")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Molimo unesite Url web stranice/društvene mreže restorana")]
        [DataType(DataType.Url)]
        [Url(ErrorMessage = "Molimo unesite ispravan Url (http, https, ftp)")]
        public string Url { get; set; }
    }
}
