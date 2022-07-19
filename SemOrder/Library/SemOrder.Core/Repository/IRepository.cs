﻿using SemOrder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SemOrder.Core.Repository
{
    public interface IRepository<T> where T : CoreEntity
    {
        Task<T> Add(T item);
        Task<bool> AddRange(List<T> items);
        Task<T> Update(T item);
        Task<bool> UpdateRange(List<T> items);
        Task<bool> Remove(T item);
        Task<bool> RemoveAll(Expression<Func<T, bool>> exp);
        Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includeParameters);
        Task<T> GetByDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeParameters);
        IQueryable<T> GetActive();
        IQueryable<T> GetDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeParameters);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        Task<bool> Activate(Guid id);
        Task<bool> Any(Expression<Func<T, bool>> exp);
        Task<int> Save();
    }
}
