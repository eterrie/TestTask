using System.Linq;

namespace TestTask
{
    public static class OptimalRouteCalculator
    {
        /// <summary>
        /// Поиск оптимального маршрута используя динамическое программирование
        /// </summary>
        /// <param name="maxVisitTime">Отведенное время посещения (в часах)</param>
        /// <param name="visits">Полный маршрут посещений</param>
        /// <returns>Оптимальный маршрут посещений</returns>
        public static Route CalculateOptimalRouteDynamicMethod(int maxVisitTime, Visit[] visits)
        {
            /*
             * Так как необходимо определить целое значение времени посещения, 
             * то будем считать время посещения не в часах, а получасах
             */

            maxVisitTime *= 2;

            int[,] maxPriorityValues = new int[visits.Length + 1, maxVisitTime + 1];

            for (int i = 0; i <= visits.Length; i++)
            {
                for (int j = 0; j <= maxVisitTime; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        maxPriorityValues[i, j] = 0;
                    }
                    else if (visits[i - 1].VisitTime > j)
                    {
                        maxPriorityValues[i, j] = maxPriorityValues[i - 1, j];
                    }
                    else
                    {
                        maxPriorityValues[i, j] = Math.Max(maxPriorityValues[i - 1, j], visits[i - 1].Priority + maxPriorityValues[i - 1, j - visits[i - 1].VisitTime]);
                    }
                }
            }

            List<Visit> optimalVisits = new List<Visit>();

            int remainingTime = maxVisitTime;

            for (int i = visits.Length; i > 0 && remainingTime > 0; i--)
            {
                if (maxPriorityValues[i, remainingTime] != maxPriorityValues[i - 1, remainingTime])
                {
                    optimalVisits.Add(visits[i - 1]);
                    remainingTime -= visits[i - 1].VisitTime;
                }
            }


            return new Route(optimalVisits.ToArray());
        }

        /// <summary>
        /// Поиск оптимального маршрута жадным алгоритмом
        /// </summary>
        /// <param name="maxVisitTime">Отведенное время посещения (в часах)</param>
        /// <param name="visits">Полный маршрут посещений</param>
        /// <returns>Оптимальный маршрут посещений</returns>
        public static Route CalculateOptimalRouteByGreedyAlgorithm(int maxVisitTime, Visit[] fullRoute)
        {
            /*
             * Так как необходимо определить целое значение времени посещения, 
             * то будем считать время посещения не в часах, а получасах
             */

            maxVisitTime *= 2;

            //Сортируем полный маршрут по отношению важности посещения ко времени
            Visit[] sortedFullRoute = fullRoute.OrderByDescending(visit => visit.Priority / visit.VisitTime).ToArray();
            List<Visit> optimal = new List<Visit>();

            int visitTimeSum = 0;

            for (int i = 0; i < sortedFullRoute.Length; i++)
            {
                int visitTime = sortedFullRoute[i].VisitTime;
                if (visitTimeSum > maxVisitTime - visitTime)
                {
                    break;
                }

                optimal.Add(sortedFullRoute[i]);
                visitTimeSum += visitTime;
            }

            return new Route(optimal.ToArray());
        }

    }
}
