using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionsDto>> GetAll();
        Task<IEnumerable<TransactionsDto>> Get(IEnumerable<int> id);
        Task<TransactionsDto?> Get(int id);
        void Create(CreateTransactionModel create);
        void Delete(int id);
    }
}
