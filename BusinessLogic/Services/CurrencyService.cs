using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Currency> currencyR;
        public CurrencyService(IMapper mapper, IRepository<Currency> currencyR)
        {
            this.mapper = mapper;
            this.currencyR = currencyR;
        }

        public void Create(CreateCurrencyModel create)
        {
            currencyR.Insert(mapper.Map<Currency>(create));
            currencyR.Save();
        }

        public async Task Delete(int id)
        {
            if (id < 0) throw new HttpException(Errors.IdMustBePositive, HttpStatusCode.BadRequest);

            var film = await currencyR.GetItemBySpec(new CurrencySpecs.ById(id));

            if (film == null) throw new HttpException(Errors.CurrencyNotFound, HttpStatusCode.NotFound);

            currencyR.Delete(film);
            currencyR.Save();
        }

        public void Edit(CurrencyDto currency)
        {
            currencyR.Update(mapper.Map<Currency>(currency));
            currencyR.Save();
        }

        public async Task<IEnumerable<CurrencyDto>> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<CurrencyDto>>(await currencyR.GetListBySpec(new CurrencySpecs.ByIds(ids)));
        }

        public async Task<CurrencyDto?> Get(int id)
        {
            if (id < 0) throw new HttpException(Errors.IdMustBePositive, HttpStatusCode.BadRequest);

            var currency = await currencyR.GetItemBySpec(new CurrencySpecs.ById(id));
            if (currency == null) throw new HttpException(Errors.CurrencyNotFound, HttpStatusCode.NotFound);

            var dto = mapper.Map<CurrencyDto>(currency);

            return dto;
        }

        public IEnumerable<CurrencyDto> GetAll()
        {
            return mapper.Map<IEnumerable<CurrencyDto>>(currencyR.GetAll());
        }
    }
}
