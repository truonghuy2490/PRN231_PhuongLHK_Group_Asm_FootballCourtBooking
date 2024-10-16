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
    public interface ICourtService
    {
        Task<ResponseModel> GetCourt(string? filterField,
            string? filterValue,
            string? sortField,
            string sortValue,
            int pageNumber,
            int pageSize);

        Task<ResponseModel> GetCourtById(int id);

        Task<ResponseModel> CreateCourt(CourtCreateModel courtCreateModel);

        Task<ResponseModel> UpdateCourt(CourtUpdateModel courtUpdateModel);

        Task<ResponseModel> DeleteCourt(int id);
    }
    public class CourtService : ICourtService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourtService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ResponseModel> CreateCourt(CourtCreateModel courtCreateModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteCourt(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetCourt(string? filterField, string? filterValue, string? sortField, string sortValue, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetCourtById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateCourt(CourtUpdateModel courtUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
