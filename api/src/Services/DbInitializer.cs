using System;
using MySql.Data.MySqlClient;

namespace api.Services
{
    public class DbInitializer
    {
        private readonly string _connectionString;

        public DbInitializer(string connectionString)
        {
            _connectionString = connectionString;
        }

      

        public void InitializeDatabase()
        {
            using (MySqlConnection mysqlConnection = new MySqlConnection(_connectionString))
            {

           try
        {
            string connectionString = "server=localhost;uid=root;pwd=root;";
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
             
            }
        }

        
    }
}
