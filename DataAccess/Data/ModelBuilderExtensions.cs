using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<Currency>().HasData(new[]
            {
                new Currency() {Id = 1, Name="Bitcoin", PriceForOneUnit = 60000, ImgUrl = "https://www.criptomonedas.co/wp-content/uploads/2021/01/bitcoin-btc-logo.png"}
            });
        }
    }
}
