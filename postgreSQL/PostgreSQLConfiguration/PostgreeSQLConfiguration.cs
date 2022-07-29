namespace postgreSQL.PostgreSQLConfiguration
{
    public class PostgreeSQLConfiguration
    {
        public string ConnectionString { get; set; }
        public PostgreeSQLConfiguration(string connectionString) => ConnectionString = connectionString;    }
}
