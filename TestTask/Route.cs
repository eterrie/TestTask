using System.Text;

namespace TestTask
{
    public class Route
    {
        public Route()
        {
            Visits = new Visit[] {};
        }

        public Route(Visit[] visits)
        {
            Visits = visits;
            RoutePriority = visits.Sum(visit => visit.Priority);
        }

        public Route(Visit[] visits, int routePriority)
        {
            Visits = visits;
            RoutePriority = routePriority;
        }

        public int RoutePriority { get; set; }
        public Visit[] Visits { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach(var visit in Visits)
            {
                Console.WriteLine(visit);
            }
            stringBuilder.AppendLine("Время: " + Visits.Sum(visit => visit.VisitTime) / 2.0 + " ч.");
            stringBuilder.AppendLine("Сумма важностей: " + RoutePriority);

            return stringBuilder.ToString();
        }
    }
}
