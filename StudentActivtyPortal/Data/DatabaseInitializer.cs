using Microsoft.Data.Sqlite;

namespace StudentActivityPortal.Data;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        var connectionString = "Data Source=Data/Activities.db";

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS Activities (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Description TEXT,
            ActivityDate TEXT
        );
        ";

        command.ExecuteNonQuery();
    }
}