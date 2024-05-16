using System.Linq.Expressions;

namespace RepositoryPatternExample.API.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T,bool>> expression);
        void Update(T entity);
        void Delete(T entity);
        Task AddAsync(T entity);
    }
}
