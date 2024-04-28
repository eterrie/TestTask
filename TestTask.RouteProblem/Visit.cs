namespace TestTask
{
    public class Visit
    {
        public Visit() { }

        public Visit(string placeName, double period, int priority)
        {
            PlaceName = placeName;
            Priority = priority;
            HalfHourPeriod = (int)(period * 2);
        }

        public string PlaceName { get; } = string.Empty;
        public int Priority { get; }

        public int HalfHourPeriod { get; }

        public override string ToString()
        {
            return $"{PlaceName,-60}\t{HalfHourPeriod / 2.0, 4} ч.\t{Priority,4}";
        }
    }
}
