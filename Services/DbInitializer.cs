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
                mysqlConnection.Open();
                if (!DatabaseExists(mysqlConnection))
                {
                   CreateDatabase(mysqlConnection);
                }

                // if (!TableExists(mysqlConnection))
                // {
                //     CreateTable(mysqlConnection);
                // }
            }
        }

        private bool DatabaseExists(MySqlConnection connection)
        {
            string query = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'megarank_api'";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                return result != null;
            }
        }

        private void CreateDatabase(MySqlConnection connection)
        {
            string query = "CREATE DATABASE IF NOT EXISTS megarank_api";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private bool TableExists(MySqlConnection connection)
        {
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'megarank_api' AND TABLE_NAME = 'Users'";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                return result != null;
            }
        }

        //  private void CreateTable(MySqlConnection connection)
        // {
            
        //     using (MySqlCommand command = connection.CreateCommand())
        //     {
        //         command.CommandText = $"USE megarank_api";
        //         command.ExecuteNonQuery();

        //         command.CommandText = @"
        //             CREATE TABLE Users (
        //                 Id INT AUTO_INCREMENT PRIMARY KEY,
        //                 FirstName VARCHAR(255),
        //                 PhotoLink VARCHAR(255),
        //                 Experience INT,
        //                 SocialMediaLink VARCHAR(255),
        //                 Role VARCHAR(255)
        //             );";


        //         command.ExecuteNonQuery();
        //     }
        // }
    }
}
