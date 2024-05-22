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
        const string folder = "images";
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<Currency>().HasData(new[]
            {
                new Currency() {Id = 1, Name="MaxiCoin", PriceForOneUnit = 10, ImageUrl = "images/maxicoin.jpg"},
                new Currency() {Id = 2, Name="TymoCoin", PriceForOneUnit = 2000, ImageUrl = "images/Tymocoin.jpg"}
            });
        }
    }
}
