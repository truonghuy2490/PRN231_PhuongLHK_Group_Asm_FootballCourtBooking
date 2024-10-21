using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FBS.Repositories.Repositories
{
    public interface IUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
        IBookingRepository BookingRepository { get; }
        ICourtSlotRepository CourtSlotRepository { get; }
        ICourtRepository CourtRepository { get; }
        IReviewReplyRepository ReviewReplyRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IUserRepository UserRepository { get; }
    }
    public class UnitOfWork(FootballBookingSystemContext context, IConfiguration configuration) : IUnitOfWork
    {
        public IAuthRepository AuthRepository { get; } = new AuthRepository(configuration);
        
        public IBookingRepository BookingRepository { get; } = new BookingRepository(context);

        public ICourtSlotRepository CourtSlotRepository { get; } = new CourtSlotRepository(context);

        public ICourtRepository CourtRepository { get; } = new CourtRepository(context);

        public IReviewReplyRepository ReviewReplyRepository { get; } = new ReviewReplyRepository(context);

        public IReviewRepository ReviewRepository { get; } = new ReviewRepository(context);

        public IUserRepository UserRepository { get; } = new UserRepository(context);

    }
}
