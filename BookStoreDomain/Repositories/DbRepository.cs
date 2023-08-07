using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entity;
using BookStoreDomain;
using BookStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Domain.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly BookStoreContext _context;

        public DbRepository(BookStoreContext context)
        {
            _context = context;
        }

        Task<long> IDbRepository.Add<T>(T newentity)
        {
            var entity = _context.Set<T>().AddAsync(newentity) as IEntity;
            return Task.Run(() => newentity.Id);
        }


        Task IDbRepository.Delete<T>(long entityid)
        {
            var activeEntity = _context.Set<T>().FirstOrDefault(x => x.Id == entityid);
            activeEntity.IsActive = false;
            return Task.Run(() => _context.Update(activeEntity));

        }

        IQueryable<T> IDbRepository.Get<T>(Expression<Func<T, bool>> selector)
        {
            return _context.Set<T>().Where(selector).Where(x => x.IsActive).AsQueryable();
        }

        IQueryable<T> IDbRepository.Get<T>()
        {
            var test = _context.Set<T>().Where(x => x.IsActive).AsQueryable();
            return test;
        }

        Task IDbRepository.Remove<T>(T entity)
        {
            return Task.Run(() => _context.Set<T>().Remove(entity));
        }

        Task IDbRepository.Update<T>(T entity)
        {
            return Task.Run(() => _context.Set<T>().Update(entity));
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

       
    }
}
