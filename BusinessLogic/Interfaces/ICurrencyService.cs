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
        Task<IEnumerable<CurrencyDTO>> Get(IEnumerable<int> ids);
        Task<IEnumerable<CurrencyDTO>> GetAll();
        Task<CurrencyDTO?> Get(int id);
        void Create(CreateCurrencyModel create);
        void Edit(CurrencyDTO currencyDTO);
        void Delete(int id);
    }
}
