using System;

namespace MerchantGuideGalaxy.Model
{
    public class ValueKeyword : Keyword
    {
        public ValueKeyword(string name, TypeKeyword type)
            : base(name, type)
        {
            Name = name;
            Type = type;
            Number = Convert.ToInt32(name);
        }

        public int Number { get; set; }
    }
}
