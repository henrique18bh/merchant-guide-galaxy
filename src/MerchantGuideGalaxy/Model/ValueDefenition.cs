using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantGuideGalaxy.Model
{
    public class ValueDefenition
    {
        public ValueDefenition(string typeName, string romanValue, TypeKeyword type)
        {
            TypeName = typeName;
            RomanValue = romanValue;
            Type = type;
        }

        public ValueDefenition(string typeName, int value, TypeKeyword type)
        {
            TypeName = typeName;
            Value = value;
            Type = type;
        }

        public TypeKeyword Type { get; set; }
        public string TypeName { get; set; }
        public string RomanValue { get; set; }
        public int? Value { get; set; }
    }
}
