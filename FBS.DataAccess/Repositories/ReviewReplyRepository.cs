using FBS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface IReviewReplyRepository
    {
        Task<List<ReviewReply>> GetReviewReply(string? filterField, string? filterValue);

        Task<ReviewReply?> GetReviewReplyById(int id);

        Task<ReviewReply> CreateReviewReply(ReviewReply reviewReply);

        Task<ReviewReply> UpdateReviewReply(ReviewReply reviewReply);

        Task<ReviewReply> DeleteReviewReply(ReviewReply reviewReply);
    }
    public class ReviewReplyRepository(FootballBookingSystemContext repositoryContext)
        : RepositoryBase<User>(repositoryContext), IReviewReplyRepository
    {
        public Task<ReviewReply> CreateReviewReply(ReviewReply reviewReply)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewReply> DeleteReviewReply(ReviewReply reviewReply)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReviewReply>> GetReviewReply(string? filterField, string? filterValue)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewReply?> GetReviewReplyById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewReply> UpdateReviewReply(ReviewReply reviewReply)
        {
            throw new NotImplementedException();
        }
    }
}
