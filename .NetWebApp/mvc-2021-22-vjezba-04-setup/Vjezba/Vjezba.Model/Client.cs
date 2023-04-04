using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("First Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ime mora sadržavati barem 2 slova.")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Prezime mora sadržavati barem 2 slova.")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Range(1, 100)]
        public int? WorkingExperience { get; set; }

        [StringLength(10, ErrorMessage = "Maksimalan broj znakova je 10.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Dopuštene su samo znamenke 0-9.")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }

        [ForeignKey(nameof(City))]
        public int? CityID { get; set; }
        public City? City { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<Meeting>? Meetings { get; set; }

    }
}
