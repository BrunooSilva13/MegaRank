using System;
using MySql.Data.MySqlClient;

namespace api.Services
{
    public class DbContext : IDisposable
    {
        private readonly MySqlConnection _connection;

        public DbContext(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
