using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SzczesliwyPlecak.Data;
using SzczesliwyPlecak.Models;
using SzczesliwyPlecak.Services;

namespace SzczesliwyPlecak.Controllers
{
    public class TripsController : Controller
    {
        private readonly MainContext _context;
        private readonly INutritionCalculatorService _nutritionCalculatorService;

        public TripsController(MainContext context, INutritionCalculatorService nutritionCalculatorService)
        {
            _context = context;
            _nutritionCalculatorService = nutritionCalculatorService;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trip.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.Include(p => p.TripProducts).ThenInclude(e => e.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FemaleParticipants,MaleParticipants,DurationInDays,TotalTimeHiking,Name,StartDate")] Trip trip)
        {
            _nutritionCalculatorService.CalculateNutrition(trip);
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartDate,DurationInDays,CaloriesNeeded,FatNeeded,CarbohydratesNeeded,FibreNeeded,ProteinsNeeded,SaltNeeded")] Trip trip)
        {
            if (id != trip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trip);
        }

        public async Task<IActionResult> AddProducts(int tripId, string searchString)
        {
            await PrepareViewDataForAddProducts(tripId, searchString);
            @ViewData["Added"] = "";
            return View();
        }

        private async Task PrepareViewDataForAddProducts(int tripId, string searchString ="")
        {
            @ViewData["TripId"] = tripId;
            PrepareProductsList(searchString);
        }

        private void PrepareProductsList(string searchString)
        {
            var products = from p in _context.Product
                select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            @ViewData["ProductList"] = products;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProducts(int tripId, [Bind("Id,Weight,Name,Calories,Fat,Carbohydrates,Proteins,Quantity")] ProductForm productForm)
        {
            if (ModelState.IsValid)
            {
                if (productForm.Id < 0)
                {
                    return BadRequest();
                }

                Product product;
                if (productForm.Id == 0)
                {
                    product = await AddNewProduct(productForm);
                }
                else
                {
                    product = await _context.Product
                        .FirstOrDefaultAsync(m => m.Id == productForm.Id);
                }

                var trip = await _context.Trip
                    .FirstOrDefaultAsync(m => m.Id == tripId);
                if (trip == null)
                {
                    return NotFound();
                }

                var newTrip = _context.Trip
                    .Include(p => p.TripProducts)
                    .ThenInclude(e => e.Product)
                    .Single(p => p.Id == tripId);

                foreach (var tripProduct in newTrip.TripProducts)
                {
                    if (tripProduct.Product.Id == product.Id)
                    {
                        tripProduct.Quantity += productForm.Quantity;
                        await _context.SaveChangesAsync();
                        await PrepareViewDataForAddProducts(tripId);
                        ProductAddedInfo();
                        return View();
                    }
                }

                var newProduct = _context.Product.Include(p => p.TripProducts)
                    .Single(p => p.Id == product.Id);

                newTrip.TripProducts.Add(new TripProduct()
                    {Product = newProduct, Trip = newTrip, Quantity = productForm.Quantity});

                await _context.SaveChangesAsync();
                ProductAddedInfo();
                await PrepareViewDataForAddProducts(tripId);
                return View();
            }
            await PrepareViewDataForAddProducts(tripId);
            return View();
        }

        private async Task<Product> AddNewProduct(ProductForm productForm)
        {
            Product product;
            product = new Product
            {
                Id = productForm.Id,
                Name = productForm.Name,
                Calories = productForm.Calories,
                Fat = productForm.Fat,
                Carbohydrates = productForm.Carbohydrates,
                Proteins = productForm.Proteins,
                Weight = productForm.Weight
            };

            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        private void ProductAddedInfo()
        {
            ViewData["Added"] = "Produkt dodany";
            ModelState.Clear();
        }


        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trip.FindAsync(id);
            _context.Trip.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteProduct(int tripId, int productId)
        {
            var trip = await _context.Trip.Include(p => p.TripProducts).ThenInclude(e => e.Product)
                .FirstOrDefaultAsync(m => m.Id == tripId);

            foreach (var tripProduct in trip.TripProducts)
            {
                if (tripProduct.Product.Id == productId)
                {
                    _context.TripProduct.Remove(tripProduct);
                }
            }
            
            await _context.SaveChangesAsync();
            return Redirect(nameof(Details) + "/" + tripId);
        }

        public async Task<IActionResult> DeleteProductFromList(int? productId, int? tripId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(productId);
            _context.Product.Remove(product);

            await _context.SaveChangesAsync();

            return Redirect(nameof(AddProducts) + "/" + tripId);
        }

        private bool TripExists(int id)
        {
            return _context.Trip.Any(e => e.Id == id);
        }

    }
}
