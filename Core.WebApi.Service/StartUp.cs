using DestinationMessurment.Service.Core.Bootstrappers;
using DistanceMeasurement.API.Bootstrappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Core.WebApi.Service
{
    public class StartUp
    {
        private readonly IConfiguration _configuration;
        public StartUp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddApiExplorer();
            services.AddDestinationMeasurment();
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddOptions();

            var serviceProvider = services.BuildServiceProvider();

            services.AddRazorPages();
      
        }
    }
}
