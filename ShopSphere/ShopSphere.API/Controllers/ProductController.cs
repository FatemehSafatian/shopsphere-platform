using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSphere.API.Data;
using ShopSphere.API.Models;

namespace ShopSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ILogger<ProductController> Logger { get; }

        public ProductController(ILogger<ProductController> logger)
        {
            Logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get() {
            return ProductContext.Products;
            return ProductContext.Products;
        }
    }
}
