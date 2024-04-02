using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using api.Models;
using api.Services;
using api.Controllers;
using api.src.Services;


class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        
        string connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddSingleton<UserRepository>();
        builder.Services.AddSingleton<UserService>();
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
