using MerchantGuideGalaxy.Test.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MerchantGuideGalaxy.Test.Service
{
    public class InterpreterProcessorServiceTest
    {
        public readonly InterpreterProcessorServiceFactory _factory;
        public InterpreterProcessorServiceTest()
        {
            _factory = new InterpreterProcessorServiceFactory();
        }

        [Fact]
        public void InterpreterProcessorTest()
        {
            //arrange
            _factory.LoadInputTestValues();

            //action
            var result = _factory.InterpreterProcessorService.Execute("how much is pish tegj glob glob ?");
            //assert
            Assert.Equal("pish tegj glob glob is 42", result);

            //action
            result = _factory.InterpreterProcessorService.Execute("how many Credits is glob prok Silver ?");
            //assert
            Assert.Equal("glob prok Silver is 68 Credits", result);

            //action
            result = _factory.InterpreterProcessorService.Execute("how many Credits is glob prok Gold ?");
            //assert
            Assert.Equal("glob prok Gold is 57800 Credits", result);

            //action
            result = _factory.InterpreterProcessorService.Execute("how many Credits is glob prok Iron ?");
            //assert
            Assert.Equal("glob prok Iron is 782 Credits", result);

            //action
            result = _factory.InterpreterProcessorService.Execute("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");
            //assert
            Assert.Equal("I have no idea what you are talking about", result);
        }
    }
}
