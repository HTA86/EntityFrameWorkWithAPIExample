
using Data.Contexts;
using Data.Repositories;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace WebApiServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            // L�gg till alla services h�r (inkl repositories, det �r ocks� en service). 
            // Se �ven till att DbContext har r�tt connection string
            //builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HBGROCA\Desktop\Sideprojects\Data\Data\DataBaseLocal.mdf;Integrated Security=True;Connect Timeout=30"));
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("Server=11.0.0.21;Database=demo;User Id=demo;Password=demo;TrustServerCertificate=True;"));
            builder.Services.AddScoped<IGamesRepository, GamesRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Aktivera Scalar om nugget packet �r installerat.
                // Denna kan du sen ansluta till via din webl�sare.
                // http://localhost:5062/scalar/v1

                // Inne p� sidan klickar du p� �nskad API metod 
                // och sen Test Request och sedan Send. Svaret
                // f�r du direkt efter i rutan till h�ger.

                app.MapScalarApiReference();


                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
