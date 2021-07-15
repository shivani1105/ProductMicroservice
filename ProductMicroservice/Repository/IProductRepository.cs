using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product SearchProductById(int productId);
        public Product SearchProductByName(string productName);
        public int AddProductRating(int productId, double rating);
    }
}
