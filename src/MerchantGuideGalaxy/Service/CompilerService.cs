using MerchantGuideGalaxy.Model;
using MerchantGuideGalaxy.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantGuideGalaxy.Service
{
    public class CompilerService : ICompilerService
    {
        public string ExecuteQuery(IList<Keyword> listKeywords)
        {
            switch (DefineTypeExecution(listKeywords))
            {
                case TypeQuery.Declaration:
                    return ExecuteDeclarationQuery(listKeywords);
                case TypeQuery.IntergalacticDefinition:
                    return ExecuteIntergalacticDefinitionQuery(listKeywords);
                case TypeQuery.Result:
                    return ExecuteResultQuery(listKeywords);
                default:
                    return "I have no idea what you are talking about";
            }
        }

        private TypeQuery DefineTypeExecution(IList<Keyword> listKeywords)
        {

            return TypeQuery.Declaration;
        }

        private string ExecuteDeclarationQuery(IList<Keyword> listKeywords)
        {
            throw new NotImplementedException();
        }

        private string ExecuteIntergalacticDefinitionQuery(IList<Keyword> listKeywords)
        {
            throw new NotImplementedException();
        }

        private string ExecuteResultQuery(IList<Keyword> listKeywords)
        {
            throw new NotImplementedException();
        }
    }
}
