using api.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace api.Services
{
    public class UserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;


        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }



        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();


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

        public void CreateUser(User user)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var cmd = new MySqlCommand(@$"INSERT INTO users (Id, FirstName, PhotoLink, Experience, SocialMediaLink, Role)
                VAlUES (@Id, @FirstName, @PhotoLink, @Experience, @SocialMediaLink, @Role)",
                connection))
                {
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@PhotoLink", user.PhotoLink);
                    cmd.Parameters.AddWithValue("@Experience", user.Experience);
                    cmd.Parameters.AddWithValue("@SocialMediaLink", user.SocialMediaLink);
                    cmd.Parameters.AddWithValue("@Role", user.Role);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(User updateUser)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var cmd = new MySqlCommand($"UPDATE users SET FirstName = @FirstName, PhotoLink = @PhotoLink, SocialMediaLink = @SocialMediaLink WHERE Id = @Id",
                connection))
                {
                    cmd.Parameters.AddWithValue("@Id", updateUser.Id);
                    cmd.Parameters.AddWithValue("@FirstName", updateUser.FirstName);
                    cmd.Parameters.AddWithValue("@PhotoLink", updateUser.PhotoLink);
                    cmd.Parameters.AddWithValue("@SocialMediaLink", updateUser.SocialMediaLink);

                    cmd.ExecuteNonQuery();
                }

            }
        }

    }
}