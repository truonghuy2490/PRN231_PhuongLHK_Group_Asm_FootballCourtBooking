using FBS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface ICourtRepository : IRepositoryBase<Court>
    {
        Task<List<Court>> GetCourt(string? filterField, string? filterValue);

        Task<Court?> GetCourtById(int id);

        Task<Court> CreateCourt(Court court);

        Task<Court> UpdateCourt(Court court);

        Task<Court> DeleteCourt(Court court);
    }
    public class CourtRepository(FootballCourtBookingContext repositoryContext)
        : RepositoryBase<User>(repositoryContext), ICourtRepository
    {
        public Task<bool> CreateAsync(Court entity)
        {
            throw new NotImplementedException();
        }

        public Task<Court> CreateCourt(Court court)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Court entity)
        {
            throw new NotImplementedException();
        }

        public Task<Court> DeleteCourt(Court court)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> FindAllAsync<TResult>(Expression<Func<Court, TResult>> selector, params Expression<Func<Court, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> FindByConditionAsync<TResult>(Expression<Func<Court, bool>> expression, Expression<Func<Court, TResult>> selector, params Expression<Func<Court, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<TResult?> GetByIdAsync<TResult>(object id, Expression<Func<Court, TResult>> selector, params Expression<Func<Court, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<Court>> GetCourt(string? filterField, string? filterValue)
        {
            throw new NotImplementedException();
        }

        public Task<Court?> GetCourtById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Court entity)
        {
            throw new NotImplementedException();
        }

        public Task<Court> UpdateCourt(Court court)
        {
            throw new NotImplementedException();
        }
    }
}
