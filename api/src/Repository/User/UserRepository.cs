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

        
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

           //metodo de validação da porta
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
               
                connection.Open();

                
                using (MySqlCommand command = new MySqlCommand(@"
                    USE crud;
                    SELECT Id, FirstName FROM users", connection))
                {
                    
                    using (var reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            
                            var user = new User
                            {
                                Id = reader.GetInt32("Id"),
                                FirstName = reader.GetString("FirstName"),
                                
                            };
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        
    }
}