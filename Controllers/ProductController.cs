using Microsoft.AspNetCore.Mvc;
using OOP.Data;
using OOP.Entity;
using System.Linq;

namespace OOP.Controllers
{
    public class ProductController : Controller
    {
        private DBContext dbContext = new DBContext();

        public IActionResult Index()
        {
            var values = dbContext.Products.ToList();

            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.ProductID == id);

            dbContext.Remove(product);
            dbContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id) 
        {
            var value = dbContext.Products.FirstOrDefault(x => x.ProductID == id);

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            var value = dbContext.Products.FirstOrDefault(x => x.ProductID == product.ProductID);

            value.ProductName = product.ProductName;
            value.ProductPrice = product.ProductPrice;
            value.ProductStock = product.ProductStock;

            dbContext.Products.Update(value);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}