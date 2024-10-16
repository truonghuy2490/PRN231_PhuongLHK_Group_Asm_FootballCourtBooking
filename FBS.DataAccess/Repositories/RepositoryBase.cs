using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<List<TResult>> FindAllAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            params Expression<Func<T, object>>[]? includes);

        Task<List<TResult>> FindByConditionAsync<TResult>(
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TResult>> selector,
            params Expression<Func<T, object>>[]? includes);

        Task<TResult?> GetByIdAsync<TResult>(
            object id,
            Expression<Func<T, TResult>> selector,
            params Expression<Func<T, object>>[]? includes);
        Task<bool> CreateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> SaveChange();
    }
    public class RepositoryBase<T>(FootballCourtBookingContext repositoryContext) : IRepositoryBase<T>
    where T : class
    {
        public async Task<List<TResult>> FindAllAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> query = repositoryContext.Set<T>();

            if (includes is { Length: > 0 })
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include)).AsSplitQuery();
            }

            return await query.Select(selector).ToListAsync();
        }



        public async Task<List<TResult>> FindByConditionAsync<TResult>(
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TResult>> selector,
            params Expression<Func<T, object>>[]? includes)
        {
            var query = repositoryContext.Set<T>().Where(expression);

            if (includes is { Length: > 0 })
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include)).AsSplitQuery();
            }

            return await query.Select(selector).ToListAsync();
        }



        public async Task<TResult?> GetByIdAsync<TResult>(
            object id,
            Expression<Func<T, TResult>> selector,
            params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> query = repositoryContext.Set<T>();

            if (includes is { Length: > 0 })
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include)).AsSplitQuery();
            }

            return await query.Where(e => EF.Property<object>(e, "UserId") == id)
                .Select(selector)
                .FirstOrDefaultAsync();
        }


        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                await repositoryContext.Set<T>().AddAsync(entity);
                return await SaveChange();
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to add", ex);
            }
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                repositoryContext.Set<T>().Update(entity);
                return await SaveChange();
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to update", ex);
            }
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                repositoryContext.Set<T>().Update(entity);
                return await SaveChange();
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to remove", ex);
            }
        }
        public async Task<bool> SaveChange()
        {
            var result = await repositoryContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
