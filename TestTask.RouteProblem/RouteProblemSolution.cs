namespace TestTask.RouteProblem
{
    public struct RouteProblemSolution
    {
        private readonly int maxHalfHourPeriod;

        private readonly Visit[] visits;

        private readonly int[,] maxPriorityValues;

        private readonly Route optimalRoute;

        private RouteProblemSolution(int maxHalfHourPeriod, Visit[] visits)
        {
            this.maxHalfHourPeriod = maxHalfHourPeriod;
            this.visits = visits;

            maxPriorityValues = new int[this.visits.Length + 1, this.maxHalfHourPeriod + 1];
            optimalRoute = new Route();

            for(int i = 0; i < maxPriorityValues.GetLength(0); i++)
            {
                for(int j = 0; j < maxPriorityValues.GetLength(1); j++)
                {
                    maxPriorityValues[i, j] = -1;
                }
            }
        }

        public static Route ComputeRoute(double maxHourPeriod, Visit[] visits, bool recursive)
        {
            var maxHalfHourPeriod = (int)(maxHourPeriod * 2);

            if (maxHalfHourPeriod <= 0) return new Route();

            var thisExample = new RouteProblemSolution(maxHalfHourPeriod, visits);

            if(!recursive)
            {
                thisExample.FindOptimalRouteByLoop();
            }
            else
            {
                thisExample.ComputeMaxPriorityValuesRecursive(visits.Length, maxHalfHourPeriod);
                thisExample.AssembleRouteRecursive(visits.Length, maxHalfHourPeriod);
            }

            return thisExample.optimalRoute;
        }

        private void FindOptimalRouteByLoop()
        {
            for (int i = 0; i <= visits.Length; i++)
            {
                for (int j = 0; j <= maxHalfHourPeriod; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        maxPriorityValues[i, j] = 0;
                    }
                    else if (visits[i - 1].HalfHourPeriod > j)
                    {
                        maxPriorityValues[i, j] = maxPriorityValues[i - 1, j];
                    }
                    else
                    {
                        maxPriorityValues[i, j] = Math.Max(maxPriorityValues[i - 1, j], visits[i - 1].Priority + maxPriorityValues[i - 1, j - visits[i - 1].HalfHourPeriod]);
                    }
                }
            }

            int remainingTime = maxHalfHourPeriod;

            for (int i = visits.Length; i > 0 && remainingTime > 0; i--)
            {
                if (maxPriorityValues[i, remainingTime] != maxPriorityValues[i - 1, remainingTime])
                {
                    optimalRoute.Add(visits[i - 1]);
                    remainingTime -= visits[i - 1].HalfHourPeriod;
                }
            }
        }

        private void ComputeMaxPriorityValuesRecursive(int visitIndex, int period)
        {
            if(visitIndex == 0 || period <= 0)
            {
                maxPriorityValues[visitIndex, period] = 0;
                return;
            }

            if (maxPriorityValues[visitIndex - 1, period] < 0)
            {
                ComputeMaxPriorityValuesRecursive(visitIndex - 1, period);
            }

            if(visits[visitIndex - 1].HalfHourPeriod > period)
            {
                maxPriorityValues[visitIndex, period] = maxPriorityValues[visitIndex - 1, period];
            }
            else
            {
                int prevVisitIndex = visitIndex - 1;
                int prevVisitPeriod = period - visits[visitIndex - 1].HalfHourPeriod;

                if (maxPriorityValues[prevVisitIndex, prevVisitPeriod] < 0)
                {
                    ComputeMaxPriorityValuesRecursive(prevVisitIndex, prevVisitPeriod);
                }

                maxPriorityValues[visitIndex, period] = 
                    Math.Max(maxPriorityValues[prevVisitIndex, period], visits[prevVisitIndex].Priority + maxPriorityValues[prevVisitIndex, prevVisitPeriod]);
            }
        }

        private void AssembleRouteRecursive(int visitIndex, int period)
        {
            if (visitIndex == 0) return;

            if (maxPriorityValues[visitIndex, period] > maxPriorityValues[visitIndex - 1, period])
            {
                AssembleRouteRecursive(visitIndex - 1, period - visits[visitIndex - 1].HalfHourPeriod);
                optimalRoute.Add(visits[visitIndex - 1]);
            }
            else
            {
                AssembleRouteRecursive(visitIndex - 1, period);
            }
        }
    }
}
