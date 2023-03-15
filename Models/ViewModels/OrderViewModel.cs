using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewPizzaPalace.Models.ViewModels
{
    public class OrderViewModel
    {


        [Range(0, 10, ErrorMessage = "Please select at least 1 pizza.")]
        public int Small { get; set; }

        [Range(0, 10, ErrorMessage = "Please select at least 1 pizza.")]
        public int Medium { get; set; }

        [Range(0, 10, ErrorMessage = "Please select at least 1 pizza.")]
        public int Large { get; set; }
        public bool Cheese { get; set; }
        public bool Pepperoni{ get; set; }
        public bool Ham { get; set; }
        public bool Pineapple { get; set; }
        public bool Sausage { get; set; }
        [Display(Name = "Feta Cheese")]
        public bool FetaCheese { get; set; }
        public bool Tomatoes { get; set; }
        public bool Olives { get; set; }
    }
}
