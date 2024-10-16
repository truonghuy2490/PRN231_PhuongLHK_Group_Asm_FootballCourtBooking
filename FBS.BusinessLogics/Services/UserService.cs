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
    public interface IUserService
    {
        Task<ResponseModel> GetUser(string? filterField,
            string? filterValue,
            string? sortField,
            string sortValue,
            int pageNumber,
            int pageSize);

        Task<ResponseModel> GetUserById(int id);

        Task<ResponseModel> CreateUser(UserCreateModel userCreateModel);

        Task<ResponseModel> UpdateUser(UserUpdateModel userUpdateModel);

        Task<ResponseModel> DeleteUser(int id);
    }
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ResponseModel> CreateUser(UserCreateModel userCreateModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetUser(string? filterField, string? filterValue, string? sortField, string sortValue, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateUser(UserUpdateModel userUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
