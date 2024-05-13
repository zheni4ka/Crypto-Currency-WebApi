using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFilmImage(IFormFile file);
        Task DeleteProductImage(string path);
    }
}
