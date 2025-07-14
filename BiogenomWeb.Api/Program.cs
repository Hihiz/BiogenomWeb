using BiogenomWeb.Application;
using BiogenomWeb.Infrastructure;
using BiogenomWeb.Infrastructure.Data;

namespace BiogenomWeb.Api
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationsServices()
                .AddInfrastructureServices(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;

                await SeedData.Initializer(service);
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}