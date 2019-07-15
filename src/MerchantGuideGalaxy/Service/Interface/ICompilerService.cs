using MerchantGuideGalaxy.Model;
using System.Collections.Generic;

namespace MerchantGuideGalaxy.Service.Interface
{
    public interface ICompilerService
    {
        string ExecuteQuery(IList<Keyword> listKeywords);
    }
}
