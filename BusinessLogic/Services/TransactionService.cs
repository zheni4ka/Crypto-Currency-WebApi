using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Transaction> transactionR;
        private readonly IRepository<Currency> currencyR;
        public TransactionService(IMapper mapper, IRepository<Currency> currencyR, IRepository<Transaction> transactionR)
        {
            this.mapper = mapper;
            this.transactionR = transactionR;
            this.currencyR = currencyR;
        }

        public async Task Create(CreateTransactionModel create)
        {
            var currency = await currencyR.GetItemBySpec(new CurrencySpecs.ById(create.CurrencyId));
            var transaction = mapper.Map<Transaction>(create);
            transaction.Sum = (int)(currency.PriceForOneUnit * transaction.Value);
            transactionR.Insert(transaction);
         

            currency.Value += create.Value;
            currencyR.Update(currency);
            transactionR.Save();
        }

        public async Task Delete(int id)
        {
            if (id < 0) throw new HttpException(Errors.IdMustBePositive, System.Net.HttpStatusCode.BadRequest);
            var transaction = await transactionR.GetItemBySpec(new TransactionSpecs.ById(id));  
            if (transaction == null) throw new HttpException(Errors.TransactionNotFound, System.Net.HttpStatusCode.NotFound);
            transactionR.Delete(transaction);
            transactionR.Save();
        }

        public async Task<IEnumerable<TransactionsDto>> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<TransactionsDto>>(await transactionR.GetListBySpec(new TransactionSpecs.ByIds(ids)));
        }

        public async Task<TransactionsDto?> Get(int id)
        {
            return mapper.Map<TransactionsDto>(await transactionR.GetItemBySpec(new TransactionSpecs.ById(id)));
        }

        public IEnumerable<TransactionsDto> GetAll()
        {
            return mapper.Map<IEnumerable<TransactionsDto>>(transactionR.GetAll());
        }
    }
}
