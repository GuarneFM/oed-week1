namespace ContainerLibrary.Classes
{
    public class MonthItem
    {
        public string Month { get; set; }
        public int Index { get; set; }

        public override string ToString()
        {
            return $"{Index,1:D2}, {Month}";
        }
    }
}