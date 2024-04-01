using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using api.Models;
using api.Services;
using api.Controllers;


class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Crie uma instância do IConfiguration para acessar as configurações
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        // Acesse a string de conexão do arquivo de configuração
        string connectionString = configuration.GetConnectionString("DefaultConnection");

        // Crie uma instância do DbContext passando a string de conexão como argumento
        builder.Services.AddSingleton<DbContext>(_ =>{
            var connection = new DbContext(connectionString);
            return connection;
        });

        builder.Services.AddSingleton<UserRepository>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
    
        app.UseEndpoints(endpoints =>{
            endpoints.MapControllers();
        });

        app.Run();
    }
}
