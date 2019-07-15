using MerchantGuideGalaxy.DI;
using MerchantGuideGalaxy.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MerchantGuideGalaxy
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfiguration configuration = builder.Build();

            ServiceProvider serviceProvider = new ServiceCollection()
                .AddRegistrationDependencies(configuration)
                .BuildServiceProvider();

            IIntergalacticTransactionsControllerService controller = serviceProvider
                .GetService<IIntergalacticTransactionsControllerService>();

            controller.StartProcess();
        }
    }
}
