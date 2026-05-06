public static class DbConfig
{
    public static string ConnectionString =>
        Environment.GetEnvironmentVariable("CONNECTION_STRING")
        ?? "Host=10.0.2.2;Port=5432;Username=app_user;Password=app_password;Database=appdb";
}