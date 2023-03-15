using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewPizzaPalace.Models
{
    public class BasicTopping
    {
        [Key]
        public int BasicTopppingID { get; set; }
        public string SizeID { get; set; }
        public decimal Cheese { get; set; }
        public decimal Pepperoni { get; set; }
        public decimal Ham { get; set; }
        public decimal Pineapple { get; set; }
        public Size Size { get; set; }


    }
}
