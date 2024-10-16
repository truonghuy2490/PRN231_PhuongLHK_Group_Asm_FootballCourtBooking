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

    public class ResponseLoginDTO
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
        public string? AccessToken { get; set; }
    }
    public class TokenRequest
    {

    }
    public class RefreshToken
    {
        public string? Token { get; set; }
        public string? Username { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsActive => DateTime.UtcNow <= Expiration;
    }
}

