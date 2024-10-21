using FBS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        Task<List<Review>> GetReview(string? filterField, string? filterValue);

        Task<Review?> GetReviewById(int id);

        Task<Review> CreateReview(Review review);

        Task<Review> UpdateReview(Review review);

        Task<Review> DeleteReview(Review review);
    }
    public class ReviewRepository(FootballBookingSystemContext repositoryContext)
        : RepositoryBase<User>(repositoryContext), IReviewRepository
    {
        public Task<bool> CreateAsync(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<Review> CreateReview(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<Review> DeleteReview(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> FindAllAsync<TResult>(Expression<Func<Review, TResult>> selector, params Expression<Func<Review, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> FindByConditionAsync<TResult>(Expression<Func<Review, bool>> expression, Expression<Func<Review, TResult>> selector, params Expression<Func<Review, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<TResult?> GetByIdAsync<TResult>(object id, Expression<Func<Review, TResult>> selector, params Expression<Func<Review, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetReview(string? filterField, string? filterValue)
        {
            throw new NotImplementedException();
        }

        public Task<Review?> GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<Review> UpdateReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
