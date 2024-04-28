using System.Collections;
using System.Text;

namespace TestTask.RouteProblem
{
    public class Route : IEnumerable<Visit>
    {
        private readonly List<Visit> visits;
        public List<Visit> Visits => visits;

        public int RoutePriority => visits.Sum(visit => visit.Priority);
        public int TotalHalfHourPeriod => visits.Sum(visit => visit.HalfHourPeriod);

        public Route()
        {
            visits = new List<Visit>();
        }

        public Route(params Visit[] visits)
        {
            this.visits = visits.ToList();
        }

        public void Add(Visit visit)
        {
            visits.Add(visit);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var visit in Visits)
            {
                stringBuilder.AppendLine(visit.ToString());
            }

            stringBuilder.AppendLine($"Время: {TotalHalfHourPeriod / 2.0:F1} ч.");
            stringBuilder.AppendLine("Сумма важностей: " + RoutePriority);

            return stringBuilder.ToString();
        }

        public IEnumerator<Visit> GetEnumerator()
        {
            return visits.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
