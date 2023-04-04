using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZavrsniLuksic.Model
{
    public class Spiciness
    {
        [Key]
        public int ID { get; set; }
        public string Level { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
