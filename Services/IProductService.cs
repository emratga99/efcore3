using efcore3.Models;
using efcore3.DTOs;


namespace efcore3.Services
{
    public interface IProductService
    {
        CreateProductResponse? CreateProduct(CreateProduct model);

        UpdateProductResponse? UpdateProduct(UpdateProduct model , int id);

        bool DeleteProduct(DeleteProduct model , int id);

        IEnumerable<Product> GetAll();
    }
}