using api.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace api.Services
{
    public class UserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            // Recupera a string de conexão do arquivo de configuração
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Cria uma nova conexão usando a string de conexão
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Abre a conexão
                connection.Open();

                // Cria um comando SQL para selecionar todos os usuários
                using (MySqlCommand command = new MySqlCommand(@"
                    USE crud;
                    SELECT Id, FirstName FROM users", connection))
                {
                    // Executa o comando SQL e obtém um leitor de dados
                    using (var reader = command.ExecuteReader())
                    {
                        // Itera sobre as linhas do resultado
                        while (reader.Read())
                        {
                            // Cria um objeto User para cada linha e adiciona à lista
                            var user = new User
                            {
                                Id = reader.GetInt32("Id"),
                                FirstName = reader.GetString("FirstName"),
                                // Outros campos
                            };
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        // Métodos adicionais para adicionar, atualizar e excluir usuários manualmente
    }
}
