namespace TestTask
{
    public class Visit
    {
        public Visit()
        {
            PlaceName = string.Empty;
            Priority = 0;
            VisitTime = 0;
        }

        /// <summary>
        /// Конструктор для создания экземпляра посещения
        /// </summary>
        /// <param name="placeName">Название достопримечательности</param>
        /// <param name="visitTime">Время посещения (в часах)</param>
        /// <param name="priority">Важность посещения достопримечательности</param>
        public Visit(string placeName, double visitTime, int priority)
        {
            PlaceName = placeName;
            Priority = priority;
            VisitTime = (int)visitTime * 2;
        }

        public string PlaceName { get; } = string.Empty;
        public int Priority { get; }

        /// <summary>
        /// Время посещения (в получасах)
        /// </summary>
        public int VisitTime { get; }

        public override string ToString()
        {
            return $"{PlaceName,-40}\t{VisitTime / 2.0, 4} ч.\t{Priority,4}";
        }
    }
}
