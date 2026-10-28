using Microsoft.AspNetCore.Mvc;
using ShopSphere.Client.Data;
using ShopSphere.Client.Models;
using System.Diagnostics;

namespace ShopSphere.Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(ProductContext.Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
