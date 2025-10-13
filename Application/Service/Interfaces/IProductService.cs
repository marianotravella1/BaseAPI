using Domain.Entities;

namespace Application.Service.Interfaces
{
    public interface IProductService
    {
        int Create(Product product);
        int Delete(Product product);
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
    }
}
