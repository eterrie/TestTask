using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using TestTask.RouteProblem;

namespace TestTask.Tests
{
    public class RouteProblemSolutionTests
    {
        [TestCaseSource(typeof(ComputeRouteData), nameof(ComputeRouteData.ExactTestCases))]
        public void ComputeRouteByLoopTest(double maxHourPeriod, Visit[] visits, Route optimalRouteExpected)
        {
            var actual = RouteProblemSolution.ComputeRoute(maxHourPeriod, visits, false);
            Assert.That(actual, Is.EquivalentTo(optimalRouteExpected));
        }

        [TestCaseSource(typeof(ComputeRouteData), nameof(ComputeRouteData.ExactTestCases))]
        public void ComputeRouteByRecursiveTest(double maxHourPeriod, Visit[] visits, Route optimalRouteExpected)
        {
            var actual = RouteProblemSolution.ComputeRoute(maxHourPeriod, visits, true);
            Assert.That(actual, Is.EquivalentTo(optimalRouteExpected));
        }
    }

    public class ComputeRouteData
    {
        public static IEnumerable<object[]> ExactTestCases()
        {
            var example1 = new Visit("Русский музей", 5, 8);
            var example2 = new Visit("Екатерининский дворец", 1.5, 5);
            var example3 = new Visit("Петербургский музей кукол", 1, 14);

            Visit[] visitSet1 = new Visit[] { example1, example2 };
            Visit[] visitSet2 = new Visit[] { example1, example2, example3 };

            yield return new object[] { 0, new Visit[] { }, new Route() };
            yield return new object[] { -1, visitSet1, new Route() };
            yield return new object[] { 0, visitSet1, new Route() };
            yield return new object[] { 2, visitSet2, new Route(example3) };
            yield return new object[] { 2, visitSet1, new Route(example2) };
            yield return new object[] { 5, visitSet2, new Route(example2, example3) };
        }
    }
}
