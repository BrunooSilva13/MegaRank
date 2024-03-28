using Microsoft.Extensions.Configuration;
using System;
using api.Models;
using api.Services;

class Program
{
    static void Main(string[] args)
    {
        // Crie uma instância do IConfiguration para acessar as configurações
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        // Acesse a string de conexão do arquivo de configuração
        string connectionString = configuration.GetConnectionString("DefaultConnection");

        // Crie uma instância do DbContext passando a string de conexão como argumento
        DbContext dbContext = new DbContext(connectionString);

        // Crie uma instância do UserRepository passando o DbContext como argumento
        UserRepository userRepository = new UserRepository(dbContext);

        // Obtenha todos os usuários do banco de dados usando o UserRepository
        var users = userRepository.GetAllUsers();

        // Imprima os usuários
        Console.WriteLine("Lista de Usuários:");
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Nome: {user.FirstName}, ..."); // Adicione outros campos conforme necessário
        }
    }
}
