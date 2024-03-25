using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using WordPuzzle.Exceptions;
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
                .AddTransient<IValidatorService, ValidatorService>()
                .BuildServiceProvider();

        var wordPuzzleSolver = serviceProvider.GetService<ISolverService>();
        var fileService = serviceProvider.GetService<IFileService>();
        var validatorSerivce = serviceProvider.GetService<IValidatorService>();

        var lines = fileService.ReadFile(@"D:\Git\TechTest\words-english.txt");

        Console.WriteLine("Welcome!");

        while (true)
        {
            Console.WriteLine("Enter the start word (or type 'exit' to quit):");
            string startWord = Console.ReadLine();

            if (startWord.ToLower() == "exit")
                break;

            try
            {
                validatorSerivce.InvalidLengthWord(startWord);
                validatorSerivce.WordNotExistOnDictionary(startWord, lines);

                Console.WriteLine("Enter the end word:");
                string endWord = Console.ReadLine();

                validatorSerivce.InvalidLengthWord(endWord);
                validatorSerivce.WordNotExistOnDictionary(endWord, lines);

                List<string> solution = wordPuzzleSolver.Solve(startWord, endWord, lines);

                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                fileService.ExportFile(solution, $"{path}/{startWord}-{endWord}.txt");

                Console.WriteLine($"Solution exported to: {path}/{startWord}-{endWord}.txt");

                foreach (var word in solution)
                {
                    Console.WriteLine(word);
                }
            }
            catch (WordValidationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        Console.WriteLine("Exiting the program...");
    }
}
