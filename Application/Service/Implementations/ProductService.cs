using Application.Repository;
using Application.Service.Interfaces;
using Domain.Entities;

namespace Application.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public int Create(Product product)
        {
            return _repository.Create(product);
        }

        public int Delete(Product product)
        {
            return _repository.Delete(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product? GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
