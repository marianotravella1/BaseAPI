using Application.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly BaseAPIContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(BaseAPIContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Lectura
        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T? GetById(int id) => _dbSet.Find(id);

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) =>
            _dbSet.Where(predicate).ToList();

        public bool Exists(Expression<Func<T, bool>> predicate) =>
            _dbSet.Any(predicate);

        public int Count(Expression<Func<T, bool>>? predicate = null) =>
            predicate is null ? _dbSet.Count() : _dbSet.Count(predicate);

        // Escritura
        public int Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            // Intento devolver el Id si existe una propiedad Id int
            var prop = entity.GetType().GetProperty("Id");
            return prop != null && prop.PropertyType == typeof(int)
                ? (int)(prop.GetValue(entity) ?? 0)
                : 0;
        }

        public int Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            var prop = entity.GetType().GetProperty("Id");
            return prop != null && prop.PropertyType == typeof(int)
                ? (int)(prop.GetValue(entity) ?? 0)
                : 0;
        }

        public int Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            var prop = entity.GetType().GetProperty("Id");
            return prop != null && prop.PropertyType == typeof(int)
                ? (int)(prop.GetValue(entity) ?? 0)
                : 0;
        }
    }
}
