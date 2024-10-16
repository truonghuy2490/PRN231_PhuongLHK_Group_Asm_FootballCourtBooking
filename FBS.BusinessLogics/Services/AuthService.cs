using FBS.BusinessObjects.BusinessModels;
using FBS.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FBS.BusinessObjects.BusinessModels.AuthenModel;

namespace FBS.BusinessLogics.Services
{
    public interface IAuthService
    {
        Task<ResponseLoginModel> Login(LoginRequestModel request);
        Task<RefreshToken> RefreshToken(TokenRequest request);
        Task<ResponseLoginModel> ResetPassword(LoginRequestModel request);

    }
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseLoginModel> Login(LoginRequestModel request)
        {
            throw new NotImplementedException();
        }

        public async Task<RefreshToken> RefreshToken(TokenRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseLoginModel> ResetPassword(LoginRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
