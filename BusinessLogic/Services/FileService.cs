using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private const string imageFolder = "images";
        private readonly IWebHostEnvironment environment;
        public FileService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public Task DeleteProductImage(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveCurrencyImage(IFormFile file)
        {
            string root = environment.WebRootPath;
            string name = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName); 
            string fullName = name + extension;         

            string imagePath = Path.Combine(imageFolder, fullName);
            string imageFullPath = Path.Combine(root, imagePath);

            using (FileStream fs = new FileStream(imageFullPath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return Path.DirectorySeparatorChar + imagePath;
        }
    }
}
