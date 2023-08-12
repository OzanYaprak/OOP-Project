using Microsoft.AspNetCore.Mvc;
using OOP.Data;

namespace OOP.Controllers
{
    public class CustomerController : Controller
    {
        private DBContext dbContext = new DBContext();

        public IActionResult Index()
        {


            return View();
        }
    }
}