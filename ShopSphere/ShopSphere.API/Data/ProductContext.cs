using MongoDB.Driver;
using ShopSphere.API.Models;

namespace ShopSphere.API.Data
{

    public class ProductContext : IProductContext
    {
        public IMongoCollection<Product> Products { get; }
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }
        private static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {

                      new Product {  Name = "IPhone X", Description = "This phone is the company's biggest change to its flagship smartphone.", ImageFile = "product-1.png", Price = 950.00M, Category = "Smart Phone" },
                        new Product {  Name = "Samsung 10", Description = "This phone is the company's biggest change to its flagship smartphone.", ImageFile = "product-2.png", Price = 840.00M, Category = "Smart Phone" },
                    new Product {  Name = "Huawei Plus", Description = "High-end smartphone with an advanced quad-camera setup and sleek glass design.", ImageFile = "product-3.png", Price = 650.00M, Category = "White Appliances" },
                    new Product {  Name = "Xiaomi Mi 9", Description = "Budget flagship with high-performance Snapdragon processor and AMOLED display.", ImageFile = "product-4.png", Price = 470.00M, Category = "White Appliances" },
                    new Product {  Name = "HTC One M9", Description = "Classic all-aluminum body design with dual front stereo speakers.", ImageFile = "product-5.png", Price = 380.00M, Category = "Smart Phone" },
                    new Product {  Name = "LG G8 ThinQ", Description = "Features hand-gesture controls and crystal sound OLED speaker technology.", ImageFile = "product-6.png", Price = 520.00M, Category = "Home Electronics" },
                    new Product {  Name = "Google Pixel 6", Description = "Pure Android experience with custom Tensor chip and amazing computational photography.", ImageFile = "product-1.png", Price = 699.00M, Category = "Smart Phone" },
                    new Product {  Name = "OnePlus 9 Pro", Description = "Hasselblad camera integration with ultra-fast fluid AMOLED 120Hz display.", ImageFile = "product-2.png", Price = 799.00M, Category = "Smart Phone" },
                    new Product {  Name = "Sony Xperia 1 III", Description = "4K HDR OLED 120Hz display built for creators, photographers, and mobile gamers.", ImageFile = "product-3.png", Price = 1199.00M, Category = "Smart Phone" },
                    new Product {  Name = "MacBook Pro 16", Description = "Ultimate pro laptop powered by high-efficiency Apple Silicon with liquid Retina display.", ImageFile = "product-4.png", Price = 2499.00M, Category = "Laptops" },
                    new Product {  Name = "Dell XPS 15", Description = "InfinityEdge display with 4K resolution and high-performance dedicated graphics.", ImageFile = "product-5.png", Price = 1899.00M, Category = "Laptops" },
                    new Product {  Name = "Lenovo ThinkPad X1", Description = "Business laptop standard with durable carbon-fiber chassis and iconic keyboard.", ImageFile = "product-6.png", Price = 1450.00M, Category = "Laptops" },
                    new Product {  Name = "Asus ROG Zephyrus", Description = "Ultra-slim gaming laptop with ultra-fast refresh rate display and top-tier GPU.", ImageFile = "product-1.png", Price = 1699.00M, Category = "Laptops" },
                    new Product {  Name = "HP Spectre x360", Description = "Premium 2-in-1 convertible laptop with OLED touch screen and stylus pen included.", ImageFile = "product-2.png", Price = 1399.00M, Category = "Laptops" },
                    new Product {  Name = "iPad Pro 12.9", Description = "Liquid Retina XDR display with M-series desktop-class computing performance.", ImageFile = "product-3.png", Price = 1099.00M, Category = "Tablets" },
                    new Product {  Name = "Samsung Galaxy Tab S8", Description = "Ultra-wide front camera, ultra-low latency S Pen included for smooth sketching.", ImageFile = "product-4.png", Price = 749.00M, Category = "Tablets" },
                    new Product {  Name = "Microsoft Surface Pro 9", Description = "Laptop power in a versatile tablet form factor with built-in kickstand.", ImageFile = "product-5.png", Price = 999.00M, Category = "Tablets" },
                    new Product {  Name = "Sony WH-1000XM5", Description = "Industry-leading noise canceling headphones with dual processors and 8 mics.", ImageFile = "product-6.png", Price = 399.00M, Category = "Audio" },
                    new Product {  Name = "Bose QuietComfort 45", Description = "World-class quiet comfort noise canceling with lightweight build for long listening.", ImageFile = "product-1.png", Price = 329.00M, Category = "Audio" },
                    new Product {  Name = "Apple AirPods Max", Description = "High-fidelity audio with active noise cancellation and spatial audio tracking.", ImageFile = "product-2.png", Price = 549.00M, Category = "Audio" },
                    new Product {  Name = "Sennheiser Momentum 4", Description = "Outstanding sound quality with audiophile-inspired 42mm transducer system.", ImageFile = "product-3.png", Price = 349.00M, Category = "Audio" },
                    new Product {  Name = "JBL Charge 5", Description = "Portable waterproof Bluetooth speaker with long-lasting built-in powerbank.", ImageFile = "product-4.png", Price = 179.00M, Category = "Audio" },
                    new Product {  Name = "Apple Watch Series 8", Description = "Advanced health sensors for heart rate, blood oxygen, and crash detection.", ImageFile = "product-5.png", Price = 399.00M, Category = "Wearables" },
                    new Product {  Name = "Samsung Galaxy Watch 5", Description = "Comprehensive wellness tracking, bioelectrical impedance sensor, and sapphire glass.", ImageFile = "product-6.png", Price = 279.00M, Category = "Wearables" },
                    new Product {  Name = "Garmin Fenix 7", Description = "Multisport GPS watch designed for outdoor endurance athletes with solar charging.", ImageFile = "product-1.png", Price = 699.00M, Category = "Wearables" },
                    new Product {  Name = "Fitbit Charge 5", Description = "Advanced fitness tracker with built-in GPS, stress management score, and EDA sensor.", ImageFile = "product-2.png", Price = 149.00M, Category = "Wearables" },
                    new Product {  Name = "Logitech MX Master 3S", Description = "Ergonomic wireless mouse with 8K DPI sensor and quiet click switches.", ImageFile = "product-3.png", Price = 99.00M, Category = "Accessories" },
                    new Product {  Name = "Keychron K2 Wireless", Description = "Tactile mechanical keyboard compatible with Mac and Windows via Bluetooth.", ImageFile = "product-4.png", Price = 89.00M, Category = "Accessories" },
                    new Product {  Name = "Samsung Odyssey G7", Description = "Curved 240Hz gaming monitor with QLED panel and 1ms response time.", ImageFile = "product-5.png", Price = 699.00M, Category = "Monitors" },
                    new Product {  Name = "LG UltraGear 27GN950", Description = "4K Nano IPS gaming monitor with 144Hz refresh rate and HDMI 2.1 support.", ImageFile = "product-6.png", Price = 799.00M, Category = "Monitors" },
                    new Product {  Name = "Dell UltraSharp U2723QE", Description = "Pro color monitor with IPS Black panel technology and USB-C hub connectivity.", ImageFile = "product-1.png", Price = 579.00M, Category = "Monitors" },
                    new Product {  Name = "PlayStation 5", Description = "Next-gen gaming console with ultra-high speed SSD and haptic feedback controller.", ImageFile = "product-2.png", Price = 499.00M, Category = "Gaming" },
                    new Product {  Name = "Xbox Series X", Description = "Fastest, most powerful Xbox ever with 12 teraflops of processing power.", ImageFile = "product-3.png", Price = 499.00M, Category = "Gaming" },
                    new Product {  Name = "Nintendo Switch OLED", Description = "Handheld console featuring vibrant 7-inch OLED screen and enhanced audio.", ImageFile = "product-4.png", Price = 349.00M, Category = "Gaming" },
                    new Product {  Name = "Steam Deck 512GB", Description = "Portable gaming PC capable of running AAA games anywhere on the go.", ImageFile = "product-5.png", Price = 649.00M, Category = "Gaming" },
                    new Product {  Name = "GoPro HERO11 Black", Description = "Action camera with 5.3K video resolution and HyperSmooth video stabilization.", ImageFile = "product-6.png", Price = 399.00M, Category = "Cameras" },
                    new Product {  Name = "Sony Alpha A7 IV", Description = "Full-frame mirrorless camera for hybrid creators with 33MP sensor and 4K60p.", ImageFile = "product-1.png", Price = 2498.00M, Category = "Cameras" },
                    new Product {  Name = "Fujifilm X-T5", Description = "Retro-style APS-C mirrorless camera with 40MP HR sensor and 3-way tilt LCD.", ImageFile = "product-2.png", Price = 1699.00M, Category = "Cameras" },
                    new Product {  Name = "DJI Mini 3 Pro", Description = "Ultra-lightweight foldable drone with 4K HDR video and tri-directional obstacle sensing.", ImageFile = "product-3.png", Price = 759.00M, Category = "Drones" },
                    new Product {  Name = "Anker 737 Power Bank", Description = "24,000mAh portable charger with 140W fast output and smart digital display.", ImageFile = "product-4.png", Price = 149.00M, Category = "Accessories" },
                    new Product {  Name = "SanDisk Extreme 2TB SSD", Description = "Rugged portable NVMe solid-state drive with 1050MB/s read speed.", ImageFile = "product-5.png", Price = 199.00M, Category = "Storage" },
                    new Product {  Name = "Samsung T7 Shield 1TB", Description = "Durable external SSD built for harsh environments with IP65 water/dust resistance.", ImageFile = "product-6.png", Price = 119.00M, Category = "Storage" },
                    new Product {  Name = "Nest Learning Thermostat", Description = "Smart home thermostat that automatically learns your schedule to save energy.", ImageFile = "product-1.png", Price = 249.00M, Category = "Home Electronics" },
                    new Product {  Name = "Philips Hue Starter Kit", Description = "Smart ambient LED lighting kit with bridge included for home automation.", ImageFile = "product-2.png", Price = 199.00M, Category = "Home Electronics" },
                    new Product {  Name = "Dyson V15 Detect", Description = "Cordless vacuum cleaner with laser illumination to reveal invisible dust on hard floors.", ImageFile = "product-3.png", Price = 749.00M, Category = "White Appliances" },
                    new Product {  Name = "Nespresso VertuoPlus", Description = "Single-serve coffee and espresso machine using Centrifusion extraction technology.", ImageFile = "product-4.png", Price = 169.00M, Category = "White Appliances" },
                    new Product {  Name = "Instant Pot Duo 7-in-1", Description = "Multi-use programmable electric pressure cooker, slow cooker, and rice maker.", ImageFile = "product-5.png", Price = 99.00M, Category = "White Appliances" },
                    new Product {  Name = "Kindle Paperwhite", Description = "6.8-inch glare-free display with adjustable warm light and weeks of battery life.", ImageFile = "product-6.png", Price = 139.00M, Category = "E-Readers" },
                    new Product {  Name = "Sonos Arc Soundbar", Description = "Premium smart soundbar with Dolby Atmos sound for movies, TV, and gaming.", ImageFile = "product-1.png", Price = 899.00M, Category = "Audio" },
                    new Product {  Name = "Razer DeathAdder V3", Description = "Ultra-lightweight ergonomic wired esports gaming mouse with 8KHz polling rate.", ImageFile = "product-2.png", Price = 69.00M, Category = "Accessories" }

            };
        }
    }
}
