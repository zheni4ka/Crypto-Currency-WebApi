using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IChangeHistoryService
    {
        IEnumerable<ChangeHistoryDto> GetAll();
        Task<IEnumerable<ChangeHistoryDto>> Get(IEnumerable<int> ids);
        Task<ChangeHistoryDto?> Get(int id);
        void Create(CreateChangeHistoryModel model);
        Task Delete(int id);
    } 
}
