using FBS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface IUserRepository
    {

    }
    public class UserRepository(FootballCourtBookingContext repositoryContext) 
        : RepositoryBase<User>(repositoryContext), IUserRepository
    {
    }
}
