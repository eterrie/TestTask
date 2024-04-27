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

            Route[,] routesTableOfMaxPriority = new Route[visits.Length + 1, maxVisitTime + 1];

            for (int i = 0; i <= visits.Length; i++)
            {
                for (int j = 0; j <= maxVisitTime; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        routesTableOfMaxPriority[i, j] = new Route();
                    }
                    else if (visits[i - 1].VisitTime <= j)
                    {
                        int newRoutePriority = visits[i - 1].Priority + routesTableOfMaxPriority[i - 1, j - visits[i - 1].VisitTime].RoutePriority;
                        int prevRoutePriority = routesTableOfMaxPriority[i - 1, j].RoutePriority;
                        if (newRoutePriority > prevRoutePriority)
                        {
                            List<Visit> newVisits = new List<Visit>();

                            newVisits.Add(visits[i - 1]);
                            newVisits.AddRange(routesTableOfMaxPriority[i - 1, j - visits[i - 1].VisitTime].Visits);

                            routesTableOfMaxPriority[i, j] = new Route(newVisits.ToArray(), newRoutePriority);
                        }
                        else
                        {
                            routesTableOfMaxPriority[i, j] = routesTableOfMaxPriority[i - 1, j];
                        }
                    }
                    else
                    {
                        routesTableOfMaxPriority[i, j] = routesTableOfMaxPriority[i - 1, j];
                    }
                }
            }

            return routesTableOfMaxPriority[visits.Length, maxVisitTime];
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
