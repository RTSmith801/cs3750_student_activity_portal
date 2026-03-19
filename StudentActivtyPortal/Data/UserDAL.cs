using System.Data;
using Microsoft.Data.SqlClient;
using StudentActivityPortal.Models;

namespace StudentActivityPortal.Data
{
    public class UserDAL
    {
        private readonly string _connectionString;

        public UserDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(
                "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)", connection);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public List<User> GetAll()
        {
            var users = new List<User>();
            using var connection = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("SELECT Id, Name, Email, DateRegistered FROM Users", connection);

            connection.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Email = (string)reader["Email"],
                    DateRegistered = (DateTime)reader["DateRegistered"]
                });
            }
            return users;
        }

        public void Update(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(
                "UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Id", user.Id);

            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", id);

            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}