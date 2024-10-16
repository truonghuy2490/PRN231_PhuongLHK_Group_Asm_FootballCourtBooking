using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.Repositories.Repositories
{
    public interface IUnitOfWork
    {
        IBookingRepository bookingRepository { get; }
        ICourtSlotRepository courtSlotRepository { get; }
        ICourtRepository courtRepository { get; }
        IReviewReplyRepository reviewReplyRepository { get; }
        IReviewRepository reviewRepository { get; }
        IUserRepository userRepository { get; }
    }
    public class UnitOfWork(FootballCourtBookingContext context) : IUnitOfWork
    {
        public IBookingRepository bookingRepository { get; } = new BookingRepository(context);

        public ICourtSlotRepository courtSlotRepository { get; } = new CourtSlotRepository(context);

        public ICourtRepository courtRepository { get; } = new CourtRepository(context);

        public IReviewReplyRepository reviewReplyRepository { get; } = new ReviewReplyRepository(context);

        public IReviewRepository reviewRepository { get; } = new ReviewRepository(context);

        public IUserRepository userRepository { get; } = new UserRepository(context);

    }
}
