using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using WordPuzzle.Interfaces;
using WordPuzzle.Services;

public class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
                .AddTransient<IManipulatorService, ManipulatorService>()
                .AddTransient<ISolverService, SolverService>()
                .AddTransient<IFileService, FileService>()  
                .BuildServiceProvider();

        var wordPuzzleSolver = serviceProvider.GetService<ISolverService>();

        var fileService = serviceProvider.GetService<IFileService>();

        var lines = fileService.ReadFile(@"D:\Git\TechTest\words-english.txt");

        Console.WriteLine("Welcomme :");

        List<string> solution = wordPuzzleSolver.Solve("same", "case", lines);

        Console.WriteLine("Solution:");
        foreach (var word in solution)
        {
            Console.WriteLine(word);
        }

        Console.ReadLine();
    }
}