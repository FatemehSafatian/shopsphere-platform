using MongoDB.Driver;
using ShopSphere.API.Models;

namespace ShopSphere.API.Data
{
    public interface IProductContext
    {
        IMongoCollection<Product> Products { get; }
    }
}