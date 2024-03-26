using api.Services;
using api.Models;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Inicializa o banco de dados
        string connectionString = "server=localhost;uid=root;pwd=senha1234;";
        DbInitializer dbInitializer = new DbInitializer(connectionString);
        dbInitializer.InitializeDatabase();

        // Obtém todos os usuários e exibe na tela
        //  using (var context = new DbContext(connectionString))
        //  {
        //     var userRepository = new UserRepository(context);
        //     var users = userRepository.GetAllUsers();
        //     foreach (var user in users)
        //     {
        //         Console.WriteLine($"Id: {user.Id}, Nome: {user.FirstName}");
        //       // Exibir outros campos, se necessário
        //    }
        }
        
}

