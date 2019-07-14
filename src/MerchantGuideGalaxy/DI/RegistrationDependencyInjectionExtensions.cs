using MerchantGuideGalaxy.Service;
using MerchantGuideGalaxy.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideGalaxy.DI
{
    public static class RegistrationDependencyInjectionExtensions
    {
        public static IServiceCollection AddRegistrationDependencies(this IServiceCollection service, IConfiguration configuration = null)
        {
            service.AddSingleton(configuration);
            service.AddSingleton<IIntergalacticTransactionsControllerService, IntergalacticTransactionsControllerService>();

            service.AddTransient<IInterpreterProcessorService, InterpreterProcessorService>();
            service.AddTransient<ICompilerService, CompilerService>();

            return service;
        }
    }
}
