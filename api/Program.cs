using api.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using api.Services;



 class Program
    {
        static void Main(string[] args)
        {
            // Defina sua string de conexão com o banco de dados
            string connectionString = "server=localhost;uid=root;pwd=root;";

            // Inicialize o banco de dados
            DbInitializer dbInitializer = new DbInitializer(connectionString);
            dbInitializer.InitializeDatabase();
            

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

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
    