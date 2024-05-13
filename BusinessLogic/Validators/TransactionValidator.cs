using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionsDto>
    {
        public TransactionValidator() 
        {
            RuleFor(x => x.Sum).NotEmpty().GreaterThan(0);
        }
    }
}
