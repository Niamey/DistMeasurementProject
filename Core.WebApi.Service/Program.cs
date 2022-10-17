using DestinationMessurment.Service.Core.Bootstrappers;

namespace Core.WebApi.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBootstrapper<StartUp>.Run(args);
        }
    }
}