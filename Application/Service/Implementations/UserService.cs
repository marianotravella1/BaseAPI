using Application.Repository;
using Application.Service.Interfaces;
using Application.Service.Models;
using Domain.Entities;

namespace Application.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public int Create(User user)
        {
            return _repository.Create(user);
        }

        public int Delete(User user)
        {
            return _repository.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public User? AuthUser(CredentialsDto credDto)
        {
            return _repository.AuthUser(credDto.UserName, credDto.Password);
        }
    }
}
