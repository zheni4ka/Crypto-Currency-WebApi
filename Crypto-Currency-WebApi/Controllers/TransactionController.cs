using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Crypto_Currency_WebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Crypto_Currency_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Transactions : ControllerBase
    {
        private readonly ITransactionService transactionService;
        public Transactions(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }
        
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("all")]
        public IActionResult All()
        {
            return Ok(transactionService.GetAll());
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await transactionService.Get(id));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult Create([FromForm] CreateTransactionModel model)
        {
            transactionService.Create(model);
            return Ok();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await transactionService.Delete(id);
            return Ok();
        }
    }
}
