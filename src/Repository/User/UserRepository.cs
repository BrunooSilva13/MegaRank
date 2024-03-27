using api.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace api.Services
{
public class UserRepository
{
    private readonly DbContext _context;

    public UserRepository(DbContext context)
    {
        _context = context;
    }

    public List<User> GetAllUsers()
    {
        List<User> users = new List<User>();

        using (MySqlConnection connection = _context.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM users";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
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