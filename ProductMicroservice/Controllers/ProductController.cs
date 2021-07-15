using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProductController));
        private IProductRepository _repo;// = new ProductRepository();
        public ProductController(IProductRepository _repo)
        {
            this._repo = _repo;

        }
        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            _log4net.Info("ProductController - GetAllProducts Method");
            try
            {
                var result = _repo.GetAllProducts();

                if (result != null)
                {
                    _log4net.Info("ProductController - GetAllProducts - All Products sent");
                    return Ok(result);
                }
                _log4net.Info("ProductController - GetAllProducts - No Products found");
                return NotFound();
            }
            catch (Exception)
            {
                _log4net.Info("ProductController - GetAllProducts - Bad Request");
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("searchProductById/{id}")]
        public IActionResult searchProductById(int id)
        {
            _log4net.Info("ProductController - searchProductById");
            try
            {
                var result = _repo.SearchProductById(id);

                if (result != null)
                {
                    _log4net.Info("ProductController - searchProductById - Product with id \'"+id+"\' sent");
                    return Ok(result);
                }
                _log4net.Info("ProductController - searchProductById - Product with id \'" + id + "\' not found");
                return NotFound();
            }
            catch (Exception)
            {
                _log4net.Info("ProductController - searchProductById - Bad Request");
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("searchProductByName/{name}")]
        public IActionResult searchProductByName(string name)
        {
            _log4net.Info("ProductController - searchProductByName");
            try
            {
                var result = _repo.SearchProductByName(name);

                if (result != null)
                {
                    _log4net.Info("ProductController - SearchProductByName - Product with name \'" + name + "\' sent");
                    return Ok(result);
                }
                _log4net.Info("ProductController - SearchProductByName - Product with name \'" + name + "\' not found");
                return NotFound();
            }
            catch (Exception)
            {
                _log4net.Info("ProductController - SearchProductByName - Bad Request");
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("AddProductRating/{productId}/{rating}")]
        public IActionResult AddProductRating(int productId, double rating)
        {

            _log4net.Info("ProductController - AddProductRating");
            double[] validRating = new double[5] { 1, 2, 3, 4, 5 };

            if (!validRating.Contains(rating))
            {
                _log4net.Info("ProductController - AddProductRating - Invalid rating");
                return BadRequest("Enter a valid rating");
            }
            try
            {
                int result = _repo.AddProductRating(productId, rating);
                if (result == 1)
                {
                    _log4net.Info("ProductController - AddProductRating - Rating Added sucessfully");
                    return Ok();
                }
                _log4net.Info("ProductController - AddProductRating - Add rating failed");
                return NotFound();
            }
            catch (Exception)
            {
                _log4net.Info("ProductController - AddProductRating - Bad Request");
                return BadRequest();
            }
        }

    }
}
