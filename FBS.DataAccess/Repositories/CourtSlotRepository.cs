using FBS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface ICourtSlotRepository
    {

    }
    public class CourtSlotRepository(FootballCourtBookingContext repositoryContext)
        : RepositoryBase<User>(repositoryContext), ICourtSlotRepository
    {
    }
}
