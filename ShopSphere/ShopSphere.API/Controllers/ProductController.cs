using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ShopSphere.API.Data;
using ShopSphere.API.Models;

namespace ShopSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductContext _Context { get; }
        public ILogger<ProductController> Logger { get; }

        public ProductController(ProductContext context, ILogger<ProductController> logger)
        {
            _Context = context;
            Logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get() {
            return await _Context.Products.Find(p=>true).ToListAsync();
        }
    }
}
