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
            Console.WriteLine($"Hello, how can I help you?");
            Console.WriteLine($@"Enter ""exit"" to close the program. {Environment.NewLine}");
            while (true)
            {
                Console.Write($"Enter values to be computed: ");
                string text = Console.ReadLine();

                if (text.ToLower() == "exit")
                {
                    break;
                }

                string result = _interpreterProcessorService.Execute(text);
                Console.WriteLine(result);
            }
        }
    }
}
