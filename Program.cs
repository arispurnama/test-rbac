using ApiCrud.DataBase;
using FastEndpoints;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiCrud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Menambahkan MediatR ke dalam DI container
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            // Menambahkan DbContext dengan Npgsql
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Menambahkan layanan-layanan lain
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Menambahkan FastEndpoints
            builder.Services.AddFastEndpoints();

            var app = builder.Build();

            // Menambahkan Swagger hanya di Development Environment
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            
            // Memetakan endpoint FastEndpoints
            app.UseFastEndpoints();

            // Menjalankan aplikasi
            app.Run();
        }
    }
}
