using Ardalis.Specification;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Specifications
{
    public class CurrencySpecs
    {
        internal class ById : Specification<Currency>
        {
            public ById(int Id) 
            {
                Query.Where(x => x.Id == Id);
            }
        }
        internal class ByIds : Specification<Currency>
        {
            public ByIds(IEnumerable<int> ids)
            {
                Query.Where(x => ids.Contains(x.Id));
            }
        }
    }
}
