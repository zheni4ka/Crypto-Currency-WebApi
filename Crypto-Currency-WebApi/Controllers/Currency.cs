using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Crypto_Currency_WebApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class Currency : ControllerBase
    {
        private readonly ICurrencyService currencyService;
        public Currency(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }
        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(currencyService.GetAll());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await currencyService.Get(id));
        }
    }
}
