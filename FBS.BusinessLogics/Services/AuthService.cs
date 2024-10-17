using AutoMapper;
using FBS.BusinessObjects.BusinessModels;
using FBS.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FBS.Repositories.Entities;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public ResponseLoginModel _ResponseLoginModel;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper = null)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _ResponseLoginModel = new ResponseLoginModel(false, String.Empty, String.Empty, null);
        }

        public async Task<ResponseLoginModel> Login(LoginRequestModel request)
        {
            try
            {
                // Fetch user from the database
                var user = await _unitOfWork.UserRepository.GetUserByProperties("username", request.Username);
                if (user != null)
                {
                    // Verify the password
                    var hashedPassword = _unitOfWork.AuthRepository.HashPassword(request.Password, user.PasswordSalt);
                    if (!hashedPassword.SequenceEqual(user.PasswordHash))
                    {
                        return new ResponseLoginModel(false, "Login fail successfully", null, null);
                    }

                    // Generate JWT Token
                    var token = _unitOfWork.AuthRepository.GenerateJwtToken(user);
                
                    _ResponseLoginModel.Message = "Login successfully";
                    _ResponseLoginModel.AccessToken = token;
                    _ResponseLoginModel.IsSuccess = true;
                
                    return _ResponseLoginModel;
                }
                return new ResponseLoginModel(false, "Username not found", null, null);
            }
            catch (Exception e)
            {
                return new ResponseLoginModel(false, e.Message, null, null);
            }
        }


        public Task<RefreshToken> RefreshToken(TokenRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseLoginModel> ResetPassword(LoginRequestModel request)
        {
            try
            {
                // check if account exist
                var existAccount = await _unitOfWork.UserRepository.GetUserByProperties("username", request.Username);
                if (existAccount != null)
                {
                    // hash and salt
                    byte[] inputHashPassword = _unitOfWork.AuthRepository.HashPassword(request.Password, existAccount.PasswordSalt);
                    // compare password
                    if(inputHashPassword != existAccount.PasswordHash)
                    {
                        // change password
                        existAccount.PasswordSalt = _unitOfWork.AuthRepository.GenerateSalt();
                        existAccount.PasswordHash = _unitOfWork.AuthRepository.HashPassword(request.Password, existAccount.PasswordSalt);
                        // update password
                        await _unitOfWork.UserRepository.UpdateAsync(existAccount);
                        
                        _ResponseLoginModel.Message = "Reset Password successfully";
                        _ResponseLoginModel.IsSuccess = true;
                        
                        return _ResponseLoginModel;

                    }return new ResponseLoginModel(false, "Password or Username not correct!", null, null);
                    
                }return new ResponseLoginModel(false, "Account not found", null, null);
            }
            catch (Exception e)
            {
                _ResponseLoginModel.Message = e.Message;
                _ResponseLoginModel.IsSuccess = false;
            }

            return _ResponseLoginModel;
        }
        
        
        

    }

}      
    
