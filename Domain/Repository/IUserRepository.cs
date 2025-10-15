using Domain.Entities;

namespace Application.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? AuthUser(string userName, string password);
    }
}
