using FBS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface IBookingRepository : IRepositoryBase<Booking>
    {
        Task<List<Booking>> GetBooking(string? filterField, string? filterValue);

        Task<Booking?> GetBookingById(int id);

        Task<Booking> CreateBooking(Booking booking);

        Task<Booking> UpdateBooking(Booking booking);

        Task<Booking> DeleteBooking(Booking booking);
    }
    public class BookingRepository(FootballCourtBookingContext repositoryContext)
        : RepositoryBase<User>(repositoryContext), IBookingRepository
    {
        public Task<bool> CreateAsync(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> CreateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> DeleteBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> FindAllAsync<TResult>(Expression<Func<Booking, TResult>> selector, params Expression<Func<Booking, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> FindByConditionAsync<TResult>(Expression<Func<Booking, bool>> expression, Expression<Func<Booking, TResult>> selector, params Expression<Func<Booking, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> GetBooking(string? filterField, string? filterValue)
        {
            throw new NotImplementedException();
        }

        public Task<Booking?> GetBookingById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TResult?> GetByIdAsync<TResult>(object id, Expression<Func<Booking, TResult>> selector, params Expression<Func<Booking, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
