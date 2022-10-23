using efcore3.DTOs;
using efcore3.Repositories;
using efcore3.Models;

namespace efcore3.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;

        private readonly ICategoryRepository _category;

        public ProductService(IProductRepository product, ICategoryRepository category)
        {
            _product = product;
            _category = category;
        }

        public CreateProductResponse? CreateProduct(CreateProduct model)
        {
            using (var transaction = _product.DatabaseTransaction())
            {
                try
                {
                    var cat = _category.GetById(o => o.Id == model.Category_id);

                    if (cat != null)
                    {
                        var product = new Product
                        {
                            Name = model.Name,
                            Manufacture = model.Manufacture,
                            Category_id = cat.Id
                        };

                        var newProduct = _product.Create(product);

                        _product.SaveChanges();
                        transaction.Commit();

                        return new CreateProductResponse
                        {
                            Id = newProduct.Id,
                            Name = newProduct.Name,
                            Manufacture = newProduct.Manufacture,
                            Category_id = newProduct.Category_id
                        };
                    }
                    return null;
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }

        public bool DeleteProduct(DeleteProduct model , int id)
        {
            using (var transaction = _product.DatabaseTransaction())
            {
                try
                {
                    var product = _product.GetById(o => o.Id == id);

                    if (product != null)
                    {
                        var updateProduct = _product.Delete(product);
                        _product.SaveChanges();
                        transaction.Commit();
                    }
                    return true;
                }
                catch
                {
                    transaction.RollBack();
                    return true;
                }
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _product.GetAll(s => true);
        }

        public UpdateProductResponse? UpdateProduct(UpdateProduct model , int id)
        {
            using (var transaction = _product.DatabaseTransaction())
            {
                try
                {
                    var product = _product.GetById(o => o.Id == id);
                    if (product != null)
                    {
                        product.Name = model.Name;
                        product.Manufacture = model.Manufacture;
                        product.Category_id = model.Category_id;

                        var updateProduct = _product.Update(product);

                        _product.SaveChanges();
                        transaction.Commit();
                        return new UpdateProductResponse
                        {
                            Id = updateProduct.Id,
                            Name = updateProduct.Name,
                            Manufacture = updateProduct.Manufacture,
                            Category_id = updateProduct.Category_id
                        };
                    }
                    return null;
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }
    }
}