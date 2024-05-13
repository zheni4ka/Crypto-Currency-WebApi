using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyDto>> Get(IEnumerable<int> ids);
        IEnumerable<CurrencyDto> GetAll();
        Task<CurrencyDto?> Get(int id);
        void Create(CreateCurrencyModel create);
        void Edit(CurrencyDto currencyDTO);
        Task Delete(int id);
    }
}
