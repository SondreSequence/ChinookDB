using Microsoft.Data.SqlClient;
namespace SuperheroesDb_Project.Repository
{
    internal class ConnectionStringHelper
    {

        public static string _Datasource = "N-NO-01-01-8189\\SQLEXPRESS"; // Here you can assign your own datasource string
        
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = _Datasource,
                InitialCatalog = "Chinook",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            };

            return builder.ConnectionString;
        }

    }
}
