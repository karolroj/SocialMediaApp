using System.Linq.Expressions;

namespace SocialMediaApp.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");
        Task<T?> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task DeleteAsync(int id);
        void Delete(T? entityToDelete);
        void Update(T entityToUpdate);
    }
}
