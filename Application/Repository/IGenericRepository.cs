using System.Linq.Expressions;

namespace Application.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        // Lectura
        IEnumerable<T> GetAll();
        T? GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        bool Exists(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>>? predicate = null);

        // Escritura
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
