using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ChangeHistoryService : IChangeHistoryService
    {
        private readonly IRepository<ChangeHistory> changehistoryR;
        private readonly IMapper mapper;
        public ChangeHistoryService(IRepository<ChangeHistory> changehistoryR, IMapper mapper)
        {
            this.changehistoryR = changehistoryR;
            this.mapper = mapper;
        }

        public void Create(CreateChangeHistoryModel model)
        {
            changehistoryR.Insert(mapper.Map<ChangeHistory>(model));
            changehistoryR.Save();
        }

        public async Task<IEnumerable<ChangeHistoryDto>> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<ChangeHistoryDto>>(await changehistoryR.GetListBySpec(new ChangeHistorySpecs.ByIds(ids)));
        }

        public async Task<ChangeHistoryDto?> Get(int id)
        {
            return mapper.Map<ChangeHistoryDto>(await changehistoryR.GetItemBySpec(new ChangeHistorySpecs.ById(id)));
        }

        public IEnumerable<ChangeHistoryDto> GetAll()
        {
            return mapper.Map<IEnumerable<ChangeHistoryDto>>(changehistoryR.GetAll());
        }

        public async Task Remove(int id)
        {
            if (id < 0) throw new HttpException(Errors.IdMustBePositive, HttpStatusCode.BadRequest);

            var history = await changehistoryR.GetItemBySpec(new ChangeHistorySpecs.ById(id));

            if (history == null) throw new HttpException(Errors.HistoryNotFound, HttpStatusCode.NotFound);

            changehistoryR.Delete(history);
            changehistoryR.Save();
        }
    }
}
