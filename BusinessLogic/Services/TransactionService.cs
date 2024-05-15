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
        public TransactionService(IMapper mapper, IRepository<Transaction> transactionR)
        {
            this.mapper = mapper;
            this.transactionR = transactionR;
        }

        public void Create(CreateTransactionModel create)
        {
            transactionR.Insert(mapper.Map<Transaction>(create));
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
