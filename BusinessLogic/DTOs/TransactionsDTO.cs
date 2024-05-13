using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class TransactionsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Sum { get; set; }
        public int CurrencyId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
