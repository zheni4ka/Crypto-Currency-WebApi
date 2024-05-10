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
        Task<IEnumerable<ChangeHistoryDTO>> GetAll();
        Task<IEnumerable<ChangeHistoryDTO>> Get(IEnumerable<int> ids);
        Task<ChangeHistoryDTO?> Get(int id);
        void Create(CreateChangeHistoryModel model);
        void Remove(int id);
    } 
}
