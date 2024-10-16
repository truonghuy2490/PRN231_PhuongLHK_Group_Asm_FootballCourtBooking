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
    public interface IReviewReplyService
    {
        Task<ResponseModel> GetReviewReply(string? filterField,
            string? filterValue,
            string? sortField,
            string sortValue,
            int pageNumber,
            int pageSize);

        Task<ResponseModel> GetReviewReplyById(int id);

        Task<ResponseModel> CreateReviewReply(ReviewReplyCreateModel reviewReplyCreateModel);

        Task<ResponseModel> UpdateReviewReply(ReviewReplyUpdateModel reviewReplyUpdateModel);

        Task<ResponseModel> DeleteReviewReply(int id);
    }
    public class ReviewReplyService : IReviewReplyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewReplyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ResponseModel> CreateReviewReply(ReviewReplyCreateModel reviewReplyCreateModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteReviewReply(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetReviewReply(string? filterField, string? filterValue, string? sortField, string sortValue, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetReviewReplyById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateReviewReply(ReviewReplyUpdateModel reviewReplyUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
