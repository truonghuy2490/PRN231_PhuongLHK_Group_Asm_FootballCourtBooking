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
    public interface ICourtSlotService
    {
        Task<ResponseModel> GetCourtSlot(string? filterField,
            string? filterValue,
            string? sortField,
            string sortValue,
            int pageNumber,
            int pageSize);

        Task<ResponseModel> GetCourtSlotById(int id);

        Task<ResponseModel> CreateCourtSlot(CourtSlotCreateModel courtSlotCreateModel);

        Task<ResponseModel> UpdateCourtSlot(CourtSlotUpdateModel courtSlotUpdateModel);

        Task<ResponseModel> DeleteCourtSlot(int id);
    }
    public class CourtSlotService : ICourtSlotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourtSlotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ResponseModel> CreateCourtSlot(CourtSlotCreateModel courtSlotCreateModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteCourtSlot(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetCourtSlot(string? filterField, string? filterValue, string? sortField, string sortValue, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetCourtSlotById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateCourtSlot(CourtSlotUpdateModel courtSlotUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
