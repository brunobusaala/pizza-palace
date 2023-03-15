using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPizzaPalace.Data;
using NewPizzaPalace.Models;
using NewPizzaPalace.Models.ViewModels;

namespace NewPizzaPalace.Controllers
{
    public class SizesController : Controller
    {
        private readonly PizzaDbContext _context;

        public SizesController(PizzaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Order(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Get the selected toppings from the model
                var toppings = new List<string>();

                if (model.Cheese)
                    toppings.Add("Cheese");

                if (model.Pepperoni)
                    toppings.Add("Pepperoni");

                if (model.Ham)
                    toppings.Add("Ham");

                if (model.Pineapple)
                    toppings.Add("Pineapple");

                var deluxetoppings = new List<string>();

                if (model.Sausage)
                    deluxetoppings.Add("Sausage");

                if (model.FetaCheese)
                    deluxetoppings.Add("Feta Cheese");

                if (model.Tomatoes)
                    deluxetoppings.Add("Tomatoes");

                if (model.Olives)
                    deluxetoppings.Add("Olives");

                // Calculate the total price of the order based on the selected size and toppings
                decimal priceofSmall = 0;

                if (model.Small > 0)
                {
                    var smallPizza = _context.Size.FirstOrDefault(m => m.SizeID == "Small");

                    priceofSmall += smallPizza.Price * model.Small;

                    if (toppings.Count > 0)
                        priceofSmall += toppings.Count * 0.5m;

                    if (deluxetoppings.Count > 0)
                        priceofSmall += deluxetoppings.Count * 2m;
                }

                decimal priceofMedium = 0;

                if (model.Medium > 0)
                {
                    var mediumPizza = _context.Size.FirstOrDefault(m => m.SizeID == "Medium");

                    priceofMedium += mediumPizza.Price * model.Medium;

                    if (toppings.Count > 0)
                        priceofMedium += toppings.Count * 0.75m;

                    if (deluxetoppings.Count > 0)
                        priceofMedium += deluxetoppings.Count * 3m;
                }

                decimal priceOfLarge = 0;

                if (model.Large > 0)
                {
                    var largePizza = _context.Size.FirstOrDefault(m => m.SizeID == "Large");
                    priceOfLarge += largePizza.Price * model.Large;
                    if (toppings.Count > 0) priceOfLarge += toppings.Count * 1m;
                    if (deluxetoppings.Count > 0) priceOfLarge += deluxetoppings.Count * 4m;
                }

                //var smallPizza = await _context.Size.FirstOrDefaultAsync(m => m.SizeID == "Small");
                //var priceOfSmall = smallPizza.Price * model.Small;

                //var mediumPizza = await _context.Size.FirstOrDefaultAsync(m => m.SizeID == "Medium");
                //var priceOfMedium = mediumPizza.Price * model.Medium;

                //var largePizza = await _context.Size.FirstOrDefaultAsync(m => m.SizeID == "Large");
                //var priceOfLarge = largePizza.Price * model.Large;

                //var smallToppingB = await _context.BasicToppings.FirstOrDefaultAsync(k => k.BasicTopppingID == 1);
                //var smallToppingPriceB = model.Small*model.Cheese*smallPizza.Price;

                //// Store the results in ViewBag and pass them to the next view
                //ViewBag.PriceOfSmall = priceOfSmall;
                //ViewBag.PriceOfMedium = priceOfMedium;
                //ViewBag.PriceOfLarge = priceOfLarge;


                // Create a view model to display the order summary
                var viewModel = new OrderSummaryViewModel

                {


                    Size = $"{model.Small} Small, {model.Medium} Medium, {model.Large} Large",
                    Toppings = toppings,
                    DeluxeT = deluxetoppings,
                    SubTotal = priceofSmall + priceofMedium + priceOfLarge,
                    GST = Math.Round(0.05m * (priceofSmall + priceofMedium + priceOfLarge), 2),
                    Total = Math.Round(0.05m * (priceofSmall + priceofMedium + priceOfLarge) + priceofSmall + priceofMedium + priceOfLarge, 2),
                    SmallP = priceofSmall,
                    MediumP = priceofMedium,
                    LargeP = priceOfLarge,
                    SmallPizza = model.Small,
                    MediumPizza = model.Medium,
                    LargePizza = model.Large
                };

                //// Return the "OrderSummary" view with the model
                //return View("OrderSummary", model);
                // Pass the view model to the OrderSummary view
                return View("OrderSummary", viewModel);
            }


            // If the model state is invalid, return the same view with the model
            return View(model);

        }


        // GET: Sizes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size = await _context.Size
                .FirstOrDefaultAsync(m => m.SizeID == id);
            if (size == null)
            {
                return NotFound();
            }

            return View(size);
        }

        // GET: Sizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SizeID,Price")] Size size)
        {
            if (ModelState.IsValid)
            {
                _context.Add(size);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(size);
        }

        // GET: Sizes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size = await _context.Size.FindAsync(id);
            if (size == null)
            {
                return NotFound();
            }
            return View(size);
        }



        // GET: Sizes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size = await _context.Size
                .FirstOrDefaultAsync(m => m.SizeID == id);
            if (size == null)
            {
                return NotFound();
            }

            return View(size);
        }



    }
}