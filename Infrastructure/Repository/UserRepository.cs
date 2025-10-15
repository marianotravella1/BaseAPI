using Application.Repository;
using Domain.Entities;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BaseAPIContext context) : base(context) { }
        public User? AuthUser(string userName, string password)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }

    
}
