using System;
using System.Data.SqlClient;



namespace SuperheroesDb_Project
{

    
    public class DatabaseMethods
    {
        String DatabaseName = "";

        public DatabaseMethods(string databaseName) { 
        
            DatabaseName = databaseName;
        }

        internal void CreateDatabase()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "N-NO-01-03-8890\\SQLEXPRESS",
                InitialCatalog = "Chinook",
                IntegratedSecurity = true
            };
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                

      
            {
                // Create a command to create a new database
                string createDatabaseQuery = " " + DatabaseName;
                SqlCommand command = new SqlCommand(createDatabaseQuery, connection);

                // Execute the query to create the database
                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine("Created database. Rows affected: " + rowsAffected);
            }
        }
    }
}



