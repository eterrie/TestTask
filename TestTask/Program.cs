namespace TestTask
{
    class Visit
    {
        public Visit(string placeName, double visitTime, int priority)
        {
            PlaceName = placeName;
            Priority = priority;
            VisitTime = visitTime;
        }

        public string PlaceName { get; } = string.Empty;
        public int Priority { get; }
        public double VisitTime { get; }
    }

    class RouteCalculator
    {
        public List<Visit> CalculateOptimalRoute(double maxVisitTime, Visit[] visits)
        {
            List<Visit> optimal = new List<Visit>();

            double visitTime = 0;

            for(int i = 0; i < visits.Length; i++)
            {
                for(int j = 0; j < visits.Length; j++)
                {
                    if (i == j) continue;


                } 
            }

            return optimal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double maxVisitTime = 32;
            Visit[] visits = new Visit[]
            {
                new Visit("Исаакиевский собор", 5, 10),
                new Visit("Эрмитаж", 8, 11),
                new Visit("Кунсткамера", 5, 10),
                new Visit("Петропавловская крепость", 10, 7),
                new Visit("Ленинградский зоопарк", 9, 15),
                new Visit("Медный всадник", 1, 17),
                new Visit("Казанский собор", 4, 3),
                new Visit("Спас на Крови", 2, 9),
                new Visit("Зимний дворец Петра I", 7, 12),
                new Visit("Зоологический музей", 5.5, 6),
                new Visit("Музей обороны и блокады Ленинграда", 2, 19),
                new Visit("Русский музей", 5, 8),
                new Visit("Навестить друзей", 12, 20),
                new Visit("Литературно-мемориальный музей Ф.М. Достоевского", 4, 2),
                new Visit("Екатерининский дворец", 1.5, 5),
                new Visit("Петербургский музей кукол", 1, 14),
                new Visit("Музей микроминиатюры Русский Левша", 3, 18),
                new Visit("Всероссийский музей А.С. Пушкина и филиалы", 6, 1),
                new Visit("Музей современного искусства Эрарта", 7, 16),
            };

            RouteCalculator routeCalculator = new RouteCalculator();

            var optimalVisits = routeCalculator.CalculateOptimalRoute(maxVisitTime, visits);

            foreach (var visit in optimalVisits)
            {
                Console.WriteLine($"{visit.PlaceName, -40}\t{visit.VisitTime, 4} ч.\t{visit.Priority, 4}");
            }
            Console.WriteLine("Время: " + optimalVisits.Sum(visit => visit.VisitTime) + " ч.");
            Console.WriteLine("Сумма важностей: " + optimalVisits.Sum(visit => visit.Priority));
        }
    }
}
