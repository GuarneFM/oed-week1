namespace ContainerLibrary.Classes
{
    public class CultureItem
    {
        public string EnglishName { get; set; }
        public string Name { get; set; }
        public override string ToString() => $"{Name,-20}{EnglishName}";

    }
}