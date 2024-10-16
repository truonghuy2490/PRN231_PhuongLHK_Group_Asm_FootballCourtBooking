using AutoMapper;
using FBS.BusinessObjects.BusinessModels.RequestModels;
using FBS.BusinessObjects.BusinessModels.RequestModels.CreateModels;
using FBS.BusinessObjects.BusinessModels.RequestModels.UpdateModels;
using FBS.BusinessObjects.BusinessModels.ViewModels;
using FBS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.API.DependencyInjections
{
    public class MapperConfig : Profile
    {
        public MapperConfig() {

            // Booking
            CreateMap<Booking, BookingViewModel>().ReverseMap();
            CreateMap<BookingUpdateModel, Booking>();
            CreateMap<BookingCreateModel, Booking>();

            // Court
            CreateMap<Court, CourtViewModel>();
            CreateMap<CourtUpdateModel, Court>();
            CreateMap<CourtCreateModel, Court>();

            CreateMap<CourtSlot, CourtSlotUpdateModel>();
            CreateMap<CourtSlotUpdateModel, CourtSlot>();
            CreateMap<CourtSlotCreateModel, CourtSlot>();

            // Review
            CreateMap<Review, ReviewViewModel>();
            CreateMap<ReviewUpdateModel, Review>();
            CreateMap<ReviewCreateModel, Review>();

            CreateMap<ReviewReply, ReviewReplyViewModel>();
            CreateMap<ReviewReplyUpdateModel, ReviewReply>();
            CreateMap<ReviewReplyCreateModel, ReviewReply>();

            // User
            CreateMap<User, UserViewModel>();
            CreateMap<UserUpdateModel, User>();
            CreateMap<UserCreateModel, User>();

        }
    }
}
