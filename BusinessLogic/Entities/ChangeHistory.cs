using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class ChangeHistory
    {
        public int Id { get; set; }
        public decimal PriceChange { get; set; }
        public DateTime ChangeTime { get; set; }
        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; }
    }
}
