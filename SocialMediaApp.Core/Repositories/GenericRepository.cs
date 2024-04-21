using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Core.Database;
using SocialMediaApp.Core.Interfaces;

namespace SocialMediaApp.Core.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected SocialMediaAppContext context;
    protected DbSet<T> dbSet;

    public GenericRepository(SocialMediaAppContext context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await dbSet.FirstOrDefaultAsync(filter);
    }

    public virtual async Task<IEnumerable<T>> GetAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<T> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual async Task InsertAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public virtual async Task DeleteAsync(int id)
    {
        T? entityToDelete = await dbSet.FindAsync(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(T? entityToDelete)
    {
        if (entityToDelete == null)
        {
            throw new ArgumentNullException(nameof(entityToDelete));
        }

        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(T entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}