using GameStore.Interfaces;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _products;
        private readonly ICategory _categories;

        public HomeController(IProduct products, ICategory categories)
        {
            _products = products;
            _categories = categories;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // Ask info from previus is Cleaned (not see)
            //System.Console.Clear();
            return View(_products.GetAllProducts());
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.Categories = _categories.GetAllCategories();
            return View(id == 0 ? new Product() : _products.GetProduct(id));
        }
        // No need more
        //[HttpGet]
        //public IActionResult UpdateAll()
        //{
        //    ViewBag.UpdateAll = true;
        //    return View(nameof(Index), _products.GetAllProducts());
        //}


        //[HttpPost]
        //public IActionResult AddProduct(Product product)
        //{
        //    _products.AddProduct(product);
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (product.Id == 0)
            {
                _products.AddProduct(product);
            }
            else 
            {
                _products.UpdateProduct(product);
            }
            
            return RedirectToAction(nameof(Index));
            
        }

                
        [HttpPost]
        public IActionResult DeleteProduct(Product product)
        {
            _products.DeleteProduct(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
