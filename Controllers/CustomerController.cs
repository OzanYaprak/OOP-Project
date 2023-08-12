using Microsoft.AspNetCore.Mvc;
using OOP.Data;
using OOP.Entity;
using System.Linq;

namespace OOP.Controllers
{
    public class CustomerController : Controller
    {
        private DBContext dbContext = new DBContext();

        public IActionResult Index()
        {
            var customers = dbContext.Customers.ToList();

            return View(customers);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = dbContext.Customers.FirstOrDefault(x => x.CustomerID == id);

            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = dbContext.Customers.FirstOrDefault(x => x.CustomerID == id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var updatedCustomer = dbContext.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);

            updatedCustomer.CustomerName = customer.CustomerName;
            updatedCustomer.CustomerCity = customer.CustomerCity;

            dbContext.Customers.Update(updatedCustomer);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}