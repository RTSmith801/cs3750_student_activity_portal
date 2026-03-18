using System.Data;
using Microsoft.Data.SqlClient;
using StudentActivityPortal.Models;

namespace StudentActivityPortal.Data
{
    public class ActivityDAL
    {
        private readonly string _connectionString;

        public ActivityDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 🔹 GET ALL
        public List<Activity> GetAll()
        {
            var list = new List<Activity>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Activities";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Activity
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString()!,
                        Description = reader["Description"].ToString()!,
                        ActivityDate = (DateTime)reader["ActivityDate"]
                    });
                }
            }

            return list;
        }

        // 🔹 GET BY ID
        public Activity GetById(int id)
        {
            Activity? activity = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Activities WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    activity = new Activity
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString()!,
                        Description = reader["Description"].ToString()!,
                        ActivityDate = (DateTime)reader["ActivityDate"]
                    };
                }
            }

            return activity!;
        }

        // 🔹 CREATE
        public void Create(Activity activity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Activities (Title, Description, ActivityDate)
                                 VALUES (@Title, @Description, @Date)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", activity.Title);
                cmd.Parameters.AddWithValue("@Description", activity.Description);
                cmd.Parameters.AddWithValue("@Date", activity.ActivityDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 🔹 UPDATE
        public void Update(Activity activity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Activities 
                                 SET Title=@Title, Description=@Description, ActivityDate=@Date
                                 WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", activity.Id);
                cmd.Parameters.AddWithValue("@Title", activity.Title);
                cmd.Parameters.AddWithValue("@Description", activity.Description);
                cmd.Parameters.AddWithValue("@Date", activity.ActivityDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 🔹 DELETE
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Activities WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}