using Microsoft.EntityFrameworkCore;
using lab_8.DbContext;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace lab_8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.WebHost.ConfigureKestrel(serverOptions =>
            //{
            //    serverOptions.Listen(IPAddress.Parse("127.0.0.1"), 5224);
            //});

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string connectionString = "Host=localhost;Port=5433;Database=lab8;Username=postgres;Password=admin;";
            builder.Services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(connectionString));
            builder.Services.BuildServiceProvider().GetService<ApiDbContext>().Database.EnsureCreated();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}