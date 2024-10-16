using AutoMapper;
using FBS.BusinessObjects.BusinessModels.RequestModels.CreateModels;
using FBS.BusinessObjects.BusinessModels.RequestModels.UpdateModels;
using FBS.BusinessObjects.BusinessModels;
using FBS.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.BusinessLogics.Services
{
    public interface IReviewService
    {
        Task<ResponseModel> GetReview(string? filterField,
            string? filterValue,
            string? sortField,
            string sortValue,
            int pageNumber,
            int pageSize);

        Task<ResponseModel> GetReviewById(int id);

        Task<ResponseModel> CreateReview(ReviewCreateModel reviewCreateModel);

        Task<ResponseModel> UpdateReview(ReviewUpdateModel reviewUpdateModel);

        Task<ResponseModel> DeleteReview(int id);
    }
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ResponseModel> CreateReview(ReviewCreateModel reviewCreateModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteReview(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetReview(string? filterField, string? filterValue, string? sortField, string sortValue, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateReview(ReviewUpdateModel reviewUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
