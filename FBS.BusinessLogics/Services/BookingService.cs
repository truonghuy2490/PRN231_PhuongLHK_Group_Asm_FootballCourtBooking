using AutoMapper;
using FBS.BusinessObjects.BusinessModels;
using FBS.BusinessObjects.BusinessModels.RequestModels.CreateModels;
using FBS.BusinessObjects.BusinessModels.RequestModels.UpdateModels;
using FBS.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.BusinessLogics.Services
{
    public interface IBookingService
    {
        Task<ResponseModel> GetBookings(string? filterField,
            string? filterValue,
            string? sortField,
            string sortValue,
            int pageNumber,
            int pageSize);

        Task<ResponseModel> GetBookingById(int bookingId);

        Task<ResponseModel> CreateBooking(BookingCreateModel bookingCreateDto);

        Task<ResponseModel> UpdateBooking(BookingUpdateModel bookingUpdateDto);

        Task<ResponseModel> DeleteBooking(int id);
    }
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ResponseModel> CreateBooking(BookingCreateModel bookingCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteBooking(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetBookingById(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetBookings(string? filterField, string? filterValue, string? sortField, string sortValue, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateBooking(BookingUpdateModel bookingUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
