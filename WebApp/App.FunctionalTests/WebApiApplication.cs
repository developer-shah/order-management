using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App.FunctionalTests
{
    class WebApiApplication : WebApplicationFactory<Program>
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public WebApiApplication(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {

                // Create a new service provider.
                var serviceProvider = services.BuildServiceProvider();

            });

            return base.CreateHost(builder);
        }
    }
}
