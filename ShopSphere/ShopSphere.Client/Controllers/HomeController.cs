using Microsoft.AspNetCore.Mvc;
using ShopSphere.Client.Data;
using ShopSphere.Client.Models;
using System.Diagnostics;

namespace ShopSphere.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _httpClient = httpClientFactory.CreateClient("ShopSphereApi"); 
    }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/product");

            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
                return View(products);
            }

            return View(new List<Product>());
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
