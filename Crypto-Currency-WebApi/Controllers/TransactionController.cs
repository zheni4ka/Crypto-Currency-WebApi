using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
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
        
        [HttpGet("all")]
        public IActionResult All()
        {
            return Ok(transactionService.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await transactionService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateTransactionModel model)
        {
            transactionService.Create(model);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await transactionService.Delete(id);
            return Ok();
        }
    }
}
