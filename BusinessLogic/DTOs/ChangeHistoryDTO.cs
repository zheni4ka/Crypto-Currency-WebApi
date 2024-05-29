﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ChangeHistoryDto
    {
        public int Id { get; set; }
        public decimal PriceChange { get; set; }
        public DateTime ChangeTime { get; set; }
        public int CurrencyId { get; set; }
    }
}
