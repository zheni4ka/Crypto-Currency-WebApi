using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CreateCurrencyModel
    {
        public string Name { get; set; }
        public decimal PriceForOneUnit { get; set; } //USD default
        public int Value { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
