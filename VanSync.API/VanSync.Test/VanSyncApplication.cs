using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace VanSyncTests
{
    internal class VanSyncApplication : WebApplicationFactory<Program>
    {
        private readonly string _environment;

        public VanSyncApplication(string environment = "Development")
        {
            _environment = environment;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment(_environment);

            return base.CreateHost(builder);
        }
    }
}
