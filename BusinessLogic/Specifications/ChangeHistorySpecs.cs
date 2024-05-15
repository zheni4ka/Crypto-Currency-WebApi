using Ardalis.Specification;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Specifications
{
    public static class ChangeHistorySpecs
    {
        internal class ById: Specification<ChangeHistory>
        {
            public ById(int Id)
            {
                Query.Where(x => x.Id == Id);
            }
        }
        internal class ByIds: Specification<ChangeHistory>
        {
            public ByIds(IEnumerable<int> ids)
            { 
                Query.Where(x=>ids.Contains(x.Id));
            }

        }
        //internal class ByDate: Specification<ChangeHistory>
        //{
        //    public ByDate(Date)
        //}    
    }

}
