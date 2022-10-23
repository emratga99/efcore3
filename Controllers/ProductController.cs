using Microsoft.AspNetCore.Mvc;
using efcore3.Services;
using efcore3.DTOs;
using efcore3.Models;

namespace efcore3.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _product;
        public ProductController(IProductService product) 
        {
            _product = product;
        }

        [HttpPost("newproduct")]
        public CreateProductResponse? CreateProduct([FromBody] CreateProduct model)
        {
            return _product.CreateProduct(model);
        }

        [HttpPut("update-product")]
        public UpdateProductResponse? UpdateProduct(UpdateProduct model ,int id)
        {
            return _product.UpdateProduct(model , id);
        }

        [HttpDelete("delete-product")]
        public bool DeleteProduct(DeleteProduct model , int id)
        {
            return _product.DeleteProduct(model, id);
        }

        [HttpGet("productlist")]
        public  IEnumerable<Product> GetAll()
        {
            return _product.GetAll();
        }
    }
}