using Microsoft.AspNetCore.Mvc;
using OOP.Data;
using OOP.Entity;
using System.Linq;

namespace OOP.Controllers
{
    public class ProductController : Controller
    {
        private DBContext dBContext = new DBContext();

        public IActionResult Index()
        {
            var values = dBContext.Products.ToList();

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
            dBContext.Products.Add(product);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var product = dBContext.Products.FirstOrDefault(x => x.ProductID == id);

            dBContext.Remove(product);
            dBContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id) 
        {
            var value = dBContext.Products.FirstOrDefault(x => x.ProductID == id);

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            var value = dBContext.Products.FirstOrDefault(x => x.ProductID == product.ProductID);

            value.ProductName = product.ProductName;
            value.ProductPrice = product.ProductPrice;
            value.ProductStock = product.ProductStock;

            dBContext.Products.Update(value);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}