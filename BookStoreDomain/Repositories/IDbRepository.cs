using System;
using System.Linq;
using System.Linq.Expressions;
using BookStore.Domain.Entity;
using System.Threading.Tasks;

namespace BookStore.Domain.Repositories
{
    public interface IDbRepository
    {
        IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IEntity; 
        IQueryable<T> Get<T>() where T : class, IEntity;

        Task<long> Add<T> (T newEntity) where T : class, IEntity;

        Task Remove<T> (T entity) where T : class, IEntity;
        Task Delete<T> (long entityId) where T : class, IEntity;

        Task Update<T>(T entity) where T : class, IEntity;

        Task<int> SaveChangesAsync();

    }
}
