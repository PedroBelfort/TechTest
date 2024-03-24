using LevenshteinDistance;
using System;
using System.Collections.Generic;

namespace WordPuzzle
{
    public class WordPuzzleSolver
    {
        public string ReplaceCharBySameIndex(string start, string end, List<string> dictionary)
        {
            if (start is null)
            {
                return string.Empty;
            }

            for (int i = 0; i < start.Length; i++)
            {
                string replaced = start.Substring(0, i) + end[i] + start.Substring(i + 1);

                if (replaced == end)
                {
                    return replaced;
                }
            }

            return string.Empty;
        }

        public List<string> ReplaceCharByAlphabetIndex(string start, List<string> dictionary, List<string> solution)
        {
            var validWords = new List<string>();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int i = 0; i < start.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    char[] referenceWord = start.ToCharArray();
                    referenceWord[i] = alphabet[j];
                    string newWord = new string(referenceWord);

                    if (SearchWordInDictionary(newWord, dictionary) && !solution.Contains(newWord))
                    {
                        validWords.Add(newWord);
                    }
                }
            }

            return validWords;
        }

        public bool SearchWordInDictionary(string word, List<string> dictionary)
        {
            return dictionary.Contains(word.ToLower());
        }

        static string FindClosestWord(string reference, List<string> words)
        {
            int minDistance = int.MaxValue;
            string closestWord = null;

            foreach (string word in words)
            {
                int distance = Levenshtein.Distance(reference, word);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestWord = word;
                }
            }

            return closestWord;
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
                var wordList = ReplaceCharByAlphabetIndex(start, dictionary, solution);

                var bestWord = FindClosestWord(end, wordList);

                var wordSameIndex = ReplaceCharBySameIndex(bestWord, end, dictionary);

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
