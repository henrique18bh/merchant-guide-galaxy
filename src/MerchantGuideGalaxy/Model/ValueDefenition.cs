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

        public ValueDefenition(string typeName, double value, TypeKeyword type)
        {
            TypeName = typeName;
            Value = value;
            Type = type;
        }

        public TypeKeyword Type { get; set; }
        public string TypeName { get; set; }
        public string RomanValue { get; set; }
        public double? Value { get; set; }
    }
}
