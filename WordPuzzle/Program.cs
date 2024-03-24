using Microsoft.Extensions.DependencyInjection;
using WordPuzzle.Interfaces;
using WordPuzzle.Services;

public class Program
{
    static void Main()
    {
        string completePath = @"D:\Git\TechTest\words-english.txt";
        List<string> lines = new List<string>();

        lines = File.ReadLines(completePath).ToList();

        var serviceProvider = new ServiceCollection()
                .AddTransient<IManipulatorService, ManipulatorService>()
                .AddTransient<ISolverService, SolverService>()
                .BuildServiceProvider();

        var wordPuzzleSolver = serviceProvider.GetService<ISolverService>();

        List<string> solution = wordPuzzleSolver.Solve("same", "case", lines);

        Console.WriteLine("Solution:");
        foreach (var word in solution)
        {
            Console.WriteLine(word);
        }

        Console.ReadLine();
    }
}