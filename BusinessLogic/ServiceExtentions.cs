using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Profiles;
using BusinessLogic.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class ServiceExtentions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationProfile(provider.CreateScope().ServiceProvider.GetService<IFileService>()!));
            }).CreateMapper());
        }

        public static void AddFluentValidators(this IServiceCollection services)    
        {   
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IChangeHistoryService, ChangeHistoryService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ITransactionService, TransactionService>();
        }
    }
}
