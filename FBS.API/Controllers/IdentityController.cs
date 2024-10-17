using FBS.BusinessLogics.Services;
using FBS.BusinessObjects.BusinessModels;
using FBS.Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using static FBS.BusinessObjects.BusinessModels.AuthenModel;

namespace FBS.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseLoginModel _responseLoginModel;

        public IdentityController(IAuthService authService)
        {
            _authService = authService;
            _responseLoginModel = new ResponseLoginModel(false, String.Empty,String.Empty , null);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseLoginModel>> Login([FromBody] LoginRequestModel model)
        {
            
            var result = await _authService.Login(model);
            return Ok(result);
        }
        
        [HttpPost("reset-password")]
        public async Task<ActionResult<ResponseLoginModel>> ResetPassword([FromBody] LoginRequestModel model)
        {
            var result = await _authService.ResetPassword(model);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<RefreshToken>> Refresh([FromBody] TokenRequest model)
        {
            RefreshToken response = new RefreshToken();
            var result = await _authService.RefreshToken(model);
            return Ok(response);
        }

    }
}
