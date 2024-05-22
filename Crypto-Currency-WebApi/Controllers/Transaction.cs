using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Crypto_Currency_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Transaction
    {
        private readonly ITransactionService transactionService;
        public Transaction(ITransactionService transactionService)
        {
            this.transactionService = transactionService;    
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(transactionService.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await transactionService.Get(id));
        }
    }
}
