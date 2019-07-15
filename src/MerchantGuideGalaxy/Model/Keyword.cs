namespace MerchantGuideGalaxy.Model
{
    public class Keyword
    {
        public Keyword(string name, TypeKeyword type)
        {
            Name = name;
            Type = type;
        }

        public TypeKeyword Type { get; set; }
        public string Name { get; set; }
    }
}
