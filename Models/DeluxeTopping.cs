using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPizzaPalace.Models
{
    public class DeluxeTopping
    {
        public int DeluxeToppingID { get; set; }
        public string SizeID { get; set; }
        public decimal Sausage { get; set; }
        public decimal FetaCheese { get; set; }
        public decimal Tomatoes { get; set; }
        public decimal Olives { get; set; }
        public Size Size { get; set; }
    }
}
