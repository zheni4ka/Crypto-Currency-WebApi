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
        Task<IEnumerable<TransactionsDTO>> GetAll();
        Task<IEnumerable<TransactionsDTO>> Get(IEnumerable<int> id);
        Task<TransactionsDTO?> Get(int id);
        void Create(CreateTransactionModel create);
        void Delete(int id);
    }
}
