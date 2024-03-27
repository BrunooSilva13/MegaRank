using api.Services;
using api.Models;
using System;
using Microsoft.AspNetCore.Hosting;


class Program
{
    static void Main(string[] args)
    {
        try
        {
            string connectionString = "server=localhost;uid=admin;pwd=root;";
            DbInitializer dbInitializer = new DbInitializer(connectionString);
            dbInitializer.InitializeDatabase();
            Console.WriteLine("Banco de dados inicializado com sucesso!");
        }
        catch (Exception ex)
        {
            // Aqui você pode lidar com a exceção como desejar,
            // como registrá-la, exibi-la ao usuário ou tomar outras medidas corretivas.
            Console.WriteLine("Ocorreu um erro durante a inicialização do banco de dados:");
            Console.WriteLine(ex.Message);
        }

        // Obtém todos os usuários e exibe na tela, preciso de uma requisição get para pegar os usuarios
        //CreateHostBuilder(args).Build().Run();

        //criar uma rota para conexao
    }

}

