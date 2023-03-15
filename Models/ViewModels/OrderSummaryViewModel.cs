using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewPizzaPalace.Models.ViewModels
{
    public class OrderSummaryViewModel
    {
        public string Size { get; set; }
        public List<string> Toppings { get; set; }
        public List<string> DeluxeT { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GST { get; set; }
        public decimal Total { get; set; }
        public decimal SmallP { get; set; }
        public decimal MediumP { get; set; }
        public decimal LargeP { get; set; }
        public int SmallPizza { get; set; }
        public int MediumPizza { get; set; }
        public int LargePizza { get; set; }
    }

}
