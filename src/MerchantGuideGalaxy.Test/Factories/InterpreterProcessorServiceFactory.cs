using MerchantGuideGalaxy.Service;
using MerchantGuideGalaxy.Service.Interface;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideGalaxy.Test.Factories
{
    public class InterpreterProcessorServiceFactory
    {
        public InterpreterProcessorService InterpreterProcessorService { get; set; }
        private readonly ICompilerService _compilerService;
        private readonly Mock<IConfiguration> _configurationMock;

        public InterpreterProcessorServiceFactory()
        {
            _configurationMock = mockConfig();
            _compilerService = new CompilerService(_configurationMock.Object);
            InterpreterProcessorService = new InterpreterProcessorService(_compilerService);
        }

        private static Mock<IConfiguration> mockConfig()
        {
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["RomanConfig:RomanRegex"]).Returns("^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
            return configuration;
        }

        public void LoadInputTestValues()
        {
            InterpreterProcessorService.LoadText("glob is I");
            _compilerService.ExecuteQuery(InterpreterProcessorService.ListKeywords);
            InterpreterProcessorService.LoadText("prok is V");
            _compilerService.ExecuteQuery(InterpreterProcessorService.ListKeywords);
            InterpreterProcessorService.LoadText("pish is X");
            _compilerService.ExecuteQuery(InterpreterProcessorService.ListKeywords);
            InterpreterProcessorService.LoadText("tegj is L");
            _compilerService.ExecuteQuery(InterpreterProcessorService.ListKeywords);
            InterpreterProcessorService.LoadText("glob glob Silver is 34 Credits");
            _compilerService.ExecuteQuery(InterpreterProcessorService.ListKeywords);
            InterpreterProcessorService.LoadText("glob prok Gold is 57800 Credits");
            _compilerService.ExecuteQuery(InterpreterProcessorService.ListKeywords);
            InterpreterProcessorService.LoadText("pish pish Iron is 3910 Credits");
            _compilerService.ExecuteQuery(InterpreterProcessorService.ListKeywords);
        }

    }
}
