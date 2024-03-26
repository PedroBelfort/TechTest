using LevenshteinDistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPuzzle.Interfaces;

namespace WordPuzzle.Services
{
    public class ManipulatorService : IManipulatorService
    {
        public string FindClosestWord(string reference, List<string> words)
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

        public List<string> ReplaceCharByAlphabetIndex(string start, List<string> dictionary, List<string> solution)
        {
            var validWords = new List<string>();
            char[] alphabet = dictionary.SelectMany(s => s).Distinct().ToArray();

            for (int i = 0; i < start.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    char[] referenceWord = start.ToCharArray();
                    referenceWord[i] = alphabet[j];
                    string newWord = new string(referenceWord);

                    if (dictionary.Contains(newWord) && !solution.Contains(newWord))
                    {
                        validWords.Add(newWord);
                    }
                }
            }

            return validWords;
        }

        public string ReplaceCharBySameIndex(string start, string end)
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
    }
}
