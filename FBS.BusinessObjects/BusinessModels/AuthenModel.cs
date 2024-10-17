using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBS.BusinessObjects.BusinessModels;

public class AuthenModel{
    public class LoginRequestModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class ResponseLoginModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string? AccessToken { get; set; }
        public RefreshToken? RefreshToken { get; set; }

        public ResponseLoginModel(bool isSuccess, string message, string? accessToken, RefreshToken? refreshToken)
        {
            IsSuccess = isSuccess;
            Message = message;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
    public class TokenRequest
    {
        public RefreshToken? RefreshToken { get; set; }
    }
    public class RefreshToken
    {
        public string? Token { get; set; }
        public string? Username { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsActive => DateTime.UtcNow <= Expiration;
    }
}

