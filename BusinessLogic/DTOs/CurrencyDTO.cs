using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CurrencyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceForOneUnit { get; set; } //USD default
        public int Value { get; set; }
        public string ImageUrl { get; set; }
    }
}
