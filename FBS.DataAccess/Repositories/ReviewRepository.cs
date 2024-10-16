using FBS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface IReviewRepository
    {

    }
    public class ReviewRepository(FootballCourtBookingContext repositoryContext)
        : RepositoryBase<User>(repositoryContext), IReviewRepository 
    {
    }
}
