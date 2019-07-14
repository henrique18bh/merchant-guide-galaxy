using MerchantGuideGalaxy.Service.Interface;
using System;

namespace MerchantGuideGalaxy.Service
{
    public class IntergalacticTransactionsControllerService : IIntergalacticTransactionsControllerService
    {
        private readonly IInterpreterProcessorService _interpreterProcessorService;

        public IntergalacticTransactionsControllerService(IInterpreterProcessorService interpreterProcessorService)
        {
            _interpreterProcessorService = interpreterProcessorService;
        }
        public void StartProcess()
        {
            while (true)
            {
                Console.Write($"Hello Galaxy Merchant, how can I help you? {Environment.NewLine}");
                var text = Console.ReadLine();

                if (text == "exit")
                {
                    break;
                }

                var result = _interpreterProcessorService.Execute(text);
                Console.WriteLine(result);
            }
        }
    }
}
