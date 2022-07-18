using Microsoft.EntityFrameworkCore;
using SemOrder.Core.Entity;
using SemOrder.Core.Repository;
using SemOrder.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SemOrder.Service.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : CoreEntity
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public DbSet<T> _entities;

        public DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
        public IQueryable<T> Table => Entities;

        public IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        public async Task<T> Add(T item)
        {
            try
            {
                if (item == null)
                    return null;

                await Entities.AddAsync(item);

                if (await Save() > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddRange(List<T> items)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    await Entities.AddRangeAsync(items);
                    int result = await Save();

                    if (items.Count == result)
                        scope.Complete();
                    return result == items.Count;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<T> Update(T item)
        {

            try
            {
                if (item == null)
                    return null;

                Entities.Update(item);

                if (await Save() > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateRange(List<T> items)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    Entities.UpdateRange(items);
                    int result = await Save();

                    if (result == items.Count)
                        scope.Complete();
                    return result == items.Count;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Any(Expression<Func<T, bool>> exp) => await Entities.AnyAsync(exp);
        public Task<T[]> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeParameters)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includeParameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeParameters)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(T item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAll(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }


    }
}
