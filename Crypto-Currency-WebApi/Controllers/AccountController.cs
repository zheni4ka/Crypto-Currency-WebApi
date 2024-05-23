using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Crypto_Currency_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountsService accountsService;
        public AccountController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            await accountsService.Register(model);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            return Ok(await accountsService.Login(model));
        }

        [HttpPost("refreshTokens")]
        public async Task<IActionResult> RefreshTokens(UserTokens tokens)
        {
            return Ok(await accountsService.RefreshTokens(tokens));
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(LogoutModel model)
        {
            await accountsService.Logout(model.RefreshToken);
            return Ok();
        }
    }
}
