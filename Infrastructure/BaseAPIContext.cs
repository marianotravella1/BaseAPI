using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BaseAPIContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public BaseAPIContext(DbContextOptions<BaseAPIContext> options) : base(options)
        {
            
        }
    }
}
