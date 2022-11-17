﻿using Microsoft.EntityFrameworkCore;
using Sample.Shared.Common;
using Sample.Shared.Common.Interfaces;
using Sample.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Repositories
{
    public class Repository<T, K> : IRepository<T, K>, IDisposable where T : EntityBase<K>
    {
        private readonly DatabaseContext _appContext;

        public Repository(DatabaseContext appContext)
        {
            _appContext = appContext;
        }

        public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        }

        public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _appContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var item in includeProperties)
                {
                    items = items.Include(item);
                }
            }

            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _appContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var item in includeProperties)
                {
                    items = items.Include(item);
                }
            }

            return items.Where(predicate);
        }

        public void Add(T entity)
        {
            _appContext.Add(entity);
            _appContext.SaveChanges();
        }

        public T Update(T entity)
        {
            var dbEntity = _appContext.Set<T>().AsNoTracking().Single(p => p.Id.Equals(entity.Id));
            var databaseEntry = _appContext.Entry(dbEntity);
            var inputEntry = _appContext.Entry(entity);

            //no items mentioned, so find out the updated entries
            IEnumerable<string> dateProperties = typeof(IDateTracking).GetProperties().Select(x => x.Name);

            var allProperties = databaseEntry.Metadata.GetProperties()
                .Where(x => !dateProperties.Contains(x.Name));

            foreach (var property in allProperties)
            {
                var proposedValue = inputEntry.Property(property.Name).CurrentValue;
                var originalValue = databaseEntry.Property(property.Name).OriginalValue;

                if (proposedValue != null && !proposedValue.Equals(originalValue))
                {
                    databaseEntry.Property(property.Name).IsModified = true;
                    databaseEntry.Property(property.Name).CurrentValue = proposedValue;
                }
            }

            var result = _appContext.Set<T>().Update(dbEntity);
            return result.Entity;
        }

        public void Remove(T entity)
        {
            _appContext.Set<T>().Remove(entity);
        }

        public void Remove(K id)
        {
            Remove(FindById(id));
        }

        public void RemoveMultiple(List<T> entities)
        {
            _appContext.Set<T>().RemoveRange(entities);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _appContext.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
