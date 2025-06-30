using Serilog;

namespace CaseItau.API.Configuration
{
    public static class SerilogConfig
    {
        public static void AddSerilogConfiguration(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}
