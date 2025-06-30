using Microsoft.Data.Sqlite;
using System.Data;

namespace CaseItau.API.Configuration
{
    public static class DatabaseConfig
    {
        public static IServiceCollection ConexaoDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IDbConnection>(provider =>
            {
                var connection = new SqliteConnection(configuration.GetConnectionString("DefaultConnection"));
                return connection;
            });

            SQLitePCL.Batteries.Init();

            return services;
        }

    }
}