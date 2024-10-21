using FBS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface ICourtSlotRepository : IRepositoryBase<CourtSlot>
    {
        Task<List<CourtSlot>> GetCourtSlot(string? filterField, string? filterValue);

        Task<CourtSlot?> GetCourtSlotById(int id);

        Task<CourtSlot> CreateCourtSlot(CourtSlot courtSlot);

        Task<CourtSlot> UpdateCourtSlot(CourtSlot courtSlot);

        Task<CourtSlot> DeleteCourtSlot(CourtSlot courtSlot);
    }
    public class CourtSlotRepository(FootballBookingSystemContext repositoryContext)
        : RepositoryBase<User>(repositoryContext), ICourtSlotRepository
    {
        public Task<bool> CreateAsync(CourtSlot entity)
        {
            throw new NotImplementedException();
        }

        public Task<CourtSlot> CreateCourtSlot(CourtSlot courtSlot)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(CourtSlot entity)
        {
            throw new NotImplementedException();
        }

        public Task<CourtSlot> DeleteCourtSlot(CourtSlot courtSlot)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> FindAllAsync<TResult>(Expression<Func<CourtSlot, TResult>> selector, params Expression<Func<CourtSlot, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> FindByConditionAsync<TResult>(Expression<Func<CourtSlot, bool>> expression, Expression<Func<CourtSlot, TResult>> selector, params Expression<Func<CourtSlot, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<TResult?> GetByIdAsync<TResult>(object id, Expression<Func<CourtSlot, TResult>> selector, params Expression<Func<CourtSlot, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourtSlot>> GetCourtSlot(string? filterField, string? filterValue)
        {
            throw new NotImplementedException();
        }

        public Task<CourtSlot?> GetCourtSlotById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CourtSlot entity)
        {
            throw new NotImplementedException();
        }

        public Task<CourtSlot> UpdateCourtSlot(CourtSlot courtSlot)
        {
            throw new NotImplementedException();
        }
    }
}
