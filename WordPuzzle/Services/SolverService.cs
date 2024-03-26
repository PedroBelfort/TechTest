using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPuzzle.Interfaces;

namespace WordPuzzle.Services
{
    public class SolverService : ISolverService
    {
        private readonly IManipulatorService wordManipulator;

        public SolverService(IManipulatorService wordManipulator)
        {
            this.wordManipulator = wordManipulator;
        }

        public List<string> Solve(string start, string end, List<string> dictionary)
        {
            int index = 0;
            start = start.ToLower();
            end = end.ToLower();
            List<string> solution = new List<string>();

            solution.Add(start);

            while (start != end && index <= start.Length)
            {
                var wordList = this.wordManipulator.ReplaceCharByAlphabetIndex(start, dictionary, solution);

                var bestWord = this.wordManipulator.FindClosestWord(end, wordList);

                var wordSameIndex = this.wordManipulator.ReplaceCharBySameIndex(bestWord, end);

                if (wordSameIndex != string.Empty)
                {
                    solution.Add(bestWord);
                    solution.Add(wordSameIndex);
                    break;
                }

                if (bestWord == null)
                {
                    solution.Add("No intermediate word found");
                    solution.Add(end);
                    break;
                }

                solution.Add(bestWord);

                start = bestWord;

                index++;

                if (index == start.Length && start != end)
                {
                    start = bestWord;
                    index = 0;
                }
            }

            return solution;
        }
    }
}
