using VanSync.Infra.Data.Repositorys;

namespace VanSync.API.Configurations
{
    public static class OpenConnectionStringRepositoryConfiguration
    {
        public static void ConnectionStringRepository(this WebApplicationBuilder builder)
        {
            var configuration =
                new ConfigurationBuilder().AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json").Build();

            builder.Services.AddTransient(r => new AdminRepositorys(configuration.GetConnectionString("Default")));
            builder.Services.AddTransient(r => new UserRepositorys(configuration.GetConnectionString("Default")));
            builder.Services.AddTransient(r => new LoginRepositorys(configuration.GetConnectionString("Default")));
        }
    }
}
