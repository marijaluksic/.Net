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
    public class Dish
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Molimo unesite naziv jela")]
        [DisplayName("Name")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Naziv mora sadržavati barem 2 slova")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Molimo unesite opis jela")]
        [DisplayName("Description")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Opis mora sadržavati barem 2 slova, a maksimalan broj znakova je 200")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Molimo unesite cijenu")]
        [StringLength(3, ErrorMessage = "Maksimalan broj znakova je 3")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Dopuštene su samo znamenke 0-9")]
        [DisplayName("Price")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Molimo izaberite restoran")]
        [ForeignKey(nameof(Restaurant))]
        public int? RestaurantID { get; set; }
        public Restaurant? Restaurant { get; set; }

        [Required(ErrorMessage = "Molimo izaberite stupanj ljutosti")]
        [ForeignKey(nameof(Spiciness))]
        public int? SpicinessID { get; set; }
        public Spiciness? Spiciness { get; set; }
    }
}
