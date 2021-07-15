using ProductMicroservice.Helper;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            return ProductData.products;
        }
        public Product SearchProductById(int productId)
        {
            var products = GetAllProducts();
            return products.Where(a => a.ProductId == productId).FirstOrDefault();

        }
        public Product SearchProductByName(string productName)
        {
            var products = GetAllProducts();
            return products.Where(a => a.ProductName == productName).FirstOrDefault();
        }
        public int AddProductRating(int productId, double rating)
        {
            var products = GetAllProducts();
            var product= products.Where(a => a.ProductId == productId).FirstOrDefault();
            if (product == null) return 0;
            product.Rating = (product.Rating + rating) / 2;
            return 1;
        }
    }
}
