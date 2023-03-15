using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewPizzaPalace.Models
{
    public class Size
    {
        [Key]
        public string SizeID { get; set; }
        public decimal Price { get; set; }
        public ICollection<BasicTopping> BasicToppings { get; set; }
        public ICollection<DeluxeTopping> DeluxeToppings { get; set; }

    }
}
