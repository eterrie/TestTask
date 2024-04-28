
using System.Diagnostics;
using TestTask;
using TestTask.RouteProblem;

int maxVisitTime = 32;

Visit[] visits =
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

Route fullRoute = new Route(visits);

Console.WriteLine($"Достопримечательности:\n{fullRoute}\n");

var stopwatch = new Stopwatch();

Console.WriteLine("Решение через цикл: ");

stopwatch.Start();
Route optimalRouteLoop = RouteProblemSolution.ComputeRoute(maxVisitTime, visits, false);
stopwatch.Stop();

Console.WriteLine($"{optimalRouteLoop}\nВремя вычисления: {stopwatch.Elapsed.TotalSeconds:F3} с.\n");


Console.WriteLine("Решение через рекурсию: ");
stopwatch.Reset();
stopwatch.Start();
Route optimalRouteRecursive = RouteProblemSolution.ComputeRoute(maxVisitTime, visits, false);
stopwatch.Stop();

Console.WriteLine($"{optimalRouteRecursive}\nВремя вычисления: {stopwatch.Elapsed.TotalSeconds:F3} с.");