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

    }
    public class ReviewReplyRepository(FootballCourtBookingContext repositoryContext)
        : RepositoryBase<User>(repositoryContext), IReviewReplyRepository
    {
    }
}
