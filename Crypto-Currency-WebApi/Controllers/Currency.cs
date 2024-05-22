﻿using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Crypto_Currency_WebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Crypto_Currency_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Currency : ControllerBase
    {
        private readonly ICurrencyService currencyService;
        public Currency(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }
        
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(currencyService.GetAll());
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await currencyService.Get(id));
        }
        
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        [HttpPost]
        public IActionResult Create([FromForm] CreateCurrencyModel model)
        {
            currencyService.Create(model);
            return Ok();
        }
        
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        [HttpPut]
        public IActionResult Edit([FromBody] CurrencyDto model)
        {
            currencyService.Edit(model);
            return Ok();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ADMIN)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await currencyService.Delete(id);
            return Ok();
        }
    }
}
