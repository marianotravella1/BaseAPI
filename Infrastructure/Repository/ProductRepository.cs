using Application.Repository;
using Domain.Entities;

namespace Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(BaseAPIContext context) : base(context) { }
    }
}
