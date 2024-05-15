using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile(IFileService fileService) 
        {
            CreateMap<Currency, CurrencyDto>();
            CreateMap<CurrencyDto, Currency>();
            CreateMap<CreateCurrencyModel, Currency>()
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(src => fileService.SaveCurrencyImage(src.ImageUrl).Result));
            CreateMap<RegisterModel, User>();
            CreateMap<CreateTransactionModel, Transaction>();
            CreateMap<Transaction, TransactionsDto>();
            CreateMap<TransactionsDto, Transaction>();
            CreateMap<ChangeHistory, ChangeHistoryDto>();
            CreateMap<ChangeHistoryDto, ChangeHistory>();
        }
    }
}
