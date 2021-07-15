using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Helper
{
    public class ProductData
    {
        static string img1 = "https://images-na.ssl-images-amazon.com/images/I/61VK5q8L-oL._SX679_.jpg";
        static string img2 = "https://images-na.ssl-images-amazon.com/images/I/71ZOtNdaZCL._SX679_.jpg";
        static string img3 = "https://images-na.ssl-images-amazon.com/images/I/519KIlHA2wL._SL1024_.jpg";
        static string img4 = "https://images-na.ssl-images-amazon.com/images/I/6197cT6ItYL._SL1500_.jpg";
        static string img5 = "https://images-na.ssl-images-amazon.com/images/I/61LvUvbZGlL._SX679_.jpg";
        public static List<Product> products = new List<Product>
        {
            new Product{ ProductId = 1, ProductName = "IPhone 11 Pro Max", Description = "It has Max storage capacity of 512GB with Operating System IOS", ImageName = img1, Price = 5999, Rating = 5},
            new Product{ ProductId = 2, ProductName = "IPhone 12", Description = "It has Max storage capacity of 256GB with Operating System IOS", ImageName = img2, Price = 3500, Rating = 3},
            new Product{ ProductId = 3, ProductName = "IPhone XR", Description = "It has storage capacity of 128GB with Operating System IOS", ImageName = img3, Price = 6999, Rating = 4},
            new Product{ ProductId = 4, ProductName = "Samsung Galaxy S20", Description = "It has Max storage capacity of 512GB with Operating System Android 11.0", ImageName = img4, Price = 4599, Rating = 2},
            new Product{ ProductId = 5, ProductName = "OnePlus 7", Description = "It has Max storage capacity of 128GB with Operating System Android", ImageName = img5, Price = 2900, Rating = 5}
        };
    }
}
