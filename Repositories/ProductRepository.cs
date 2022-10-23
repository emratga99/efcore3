using efcore3.Repositories;
using efcore3.Models;
using efcore3.Data;

namespace efcore3.Repositories
{
    public class ProductRepository : BaseRepository<Product> , IProductRepository
    {
        public ProductRepository(ProductStoreContext context) : base(context)
        {
            
        }
    }
}