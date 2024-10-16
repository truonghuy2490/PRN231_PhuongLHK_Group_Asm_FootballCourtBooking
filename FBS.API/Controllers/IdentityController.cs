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
using static FBS.BusinessObjects.BusinessModels.AuthenModel;

namespace FBS.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IAuthService _authService;
        

        public IdentityController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseLoginModel>> Login([FromBody] LoginRequestModel model)
        {
            ResponseLoginModel response = new ResponseLoginModel();
            var result = await _authService.Login(model);
            return Ok(response);
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
