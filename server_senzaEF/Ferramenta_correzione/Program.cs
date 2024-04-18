
using Ferramenta_correzione.Models;
using Ferramenta_correzione.Repositories;
using Ferramenta_correzione.Services;
using Microsoft.EntityFrameworkCore;

namespace Ferramenta_correzione
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region Importanti per la configurazione di Context e Repository
            builder.Services.AddDbContext<FerramentaContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped<ProdottoRepo>();
            builder.Services.AddScoped<ProdottoService>();

            #endregion

            var app = builder.Build();

            app.UseCors(builder =>
                 builder
                 .WithOrigins("*")
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            // Configure the HTTP request pipeline.
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
