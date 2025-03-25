using Ecommerce.Services.ProductAPI.Models;

namespace Ecommerce.Services.ProductAPI.dbcontexts;

public static class SeedData
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Title = "Nike Air Zoom Pegasus 39",
                    Price = 120,
                    Description = "Koşu için ideal, hafif ve rahat spor ayakkabı.",
                    Category = "Shoes",
                    Brand = "Nike",
                    Collection = new List<string> { "SPORT", "NEW" },
                    Hot = true,
                    Discount = 10,
                    Stock = 15,
                    New = true,
                    Rating = 4.8,
                    Tags = new List<string> { "running", "nike", "sport", "black", "white" }
                },
                new Product
                {
                    ProductId = 2,
                    Title = "Adidas Ultraboost 22",
                    Price = 180,
                    Description = "Boost taban teknolojisi ile ekstra konfor sunan ayakkabı.",
                    Category = "Shoes",
                    Brand = "Adidas",
                    Collection = new List<string> { "RUNNING", "NEW ARRIVALS" },
                    Hot = false,
                    Discount = 15,
                    Stock = 10,
                    New = true,
                    Rating = 4.7,
                    Tags = new List<string> { "running", "adidas", "boost", "gray", "blue" }
                },
                new Product
                {
                    ProductId = 3,
                    Title = "Under Armour Sportstyle T-Shirt",
                    Price = 35,
                    Description = "Günlük kullanım ve spor aktiviteleri için ideal tişört.",
                    Category = "Clothing",
                    Brand = "Under Armour",
                    Collection = new List<string> { "TRAINING", "CASUAL" },
                    Hot = false,
                    Discount = 0,
                    Stock = 20,
                    New = false,
                    Rating = 4.5,
                    Tags = new List<string> { "tshirt", "underarmour", "black", "blue", "s", "m", "l" }
                }
            };
        }

        public static List<Image> GetImages()
        {
            return new List<Image>
            {
                new Image { ImageId = 1, Alt = "Black Nike Shoe", Src = "1.png", ProductId = 1 },
                new Image { ImageId = 2, Alt = "White Nike Shoe", Src = "2.png", ProductId = 1 },
                new Image { ImageId = 3, Alt = "Gray Adidas Shoe", Src = "3.png", ProductId = 2 },
                new Image { ImageId = 4, Alt = "Blue Adidas Shoe", Src = "4.png", ProductId = 2 },
                new Image { ImageId = 5, Alt = "Black T-Shirt", Src = "5.png", ProductId = 3 }
            };
        }

        public static List<Variant> GetVariants()
        {
            return new List<Variant>
            {
                new Variant { VariantId = 1, Sku = "NK-PEG39-BLK", Size = "42", Color = "Black", ProductId = 1, ImageId = 1 },
                new Variant { VariantId = 2, Sku = "NK-PEG39-WHT", Size = "44", Color = "White", ProductId = 1, ImageId = 2 },
                new Variant { VariantId = 3, Sku = "AD-UB22-GRY", Size = "40", Color = "Gray", ProductId = 2, ImageId = 3 },
                new Variant { VariantId = 4, Sku = "AD-UB22-BLU", Size = "42", Color = "Blue", ProductId = 2, ImageId = 4 },
                new Variant { VariantId = 5, Sku = "UA-TSHRT-BLK", Size = "M", Color = "Black", ProductId = 3, ImageId = 5 },
                new Variant { VariantId = 6, Sku = "UA-TSHRT-BLK", Size = "L", Color = "Black", ProductId = 3, ImageId = 5 }
            };
        }
    }