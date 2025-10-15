using Application.Service.Models;
using Domain.Entities;

namespace Application.Service.Interfaces
{
    public interface IUserService
    {
        int Create(User user);
        int Delete(User user);
        IEnumerable<User> GetAll();
        User? GetById(int id);
        User? AuthUser(CredentialsDto credDto);
    }
}
