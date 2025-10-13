using Application.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository
        : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BaseAPIContext context) : base(context) { }
    }
}
