using MerchantGuideGalaxy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantGuideGalaxy.Service.Interface
{
    public interface ICompilerService
    {
        string ExecuteQuery(IList<Keyword> listKeywords);
    }
}
