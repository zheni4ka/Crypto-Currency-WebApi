using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Crypto_Currency_WebApi.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class ChangeHistoryController : ControllerBase
    {
        private readonly IChangeHistoryService changeHistoryService;
        public ChangeHistoryController(IChangeHistoryService changeHistoryService)
        {
            this.changeHistoryService = changeHistoryService;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            return Ok(changeHistoryService.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await  changeHistoryService.Get(id));
        }

    }
}
