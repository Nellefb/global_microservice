namespace GlobalSolution.Database
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public DatabaseConfig(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }
    }
}
