
namespace Crypto_Currency_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connStr = builder.Configuration.GetConnectionString("LocalDb")!;


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddJWT(builder.Configuration);
            //builder.Services.AddRequirements();

            //builder.Services.AddDbContext(connStr);
            //builder.Services.AddIdentity();
            //builder.Services.AddRepositories();

            //builder.Services.AddAutoMapper();
            //builder.Services.AddFluentValidators();

            //builder.Services.AddCustomServices();

            var app = builder.Build();

            //using (var scope = app.Services.CreateScope())
            //{
            //    scope.ServiceProvider.SeedRoles().Wait();
            //    scope.ServiceProvider.SeedAdmin().Wait();
            //}

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseMiddleware<GlobalErrorHandler>();

            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}