using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceForOneUnit { get; set; } //USD default
        public int Value { get; set; } = 0;
        public string ImgUrl { get; set; }
        public IEnumerable<ChangeHistory> Changes { get; set; }
    }
}
