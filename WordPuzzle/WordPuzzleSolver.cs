using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzle
{
    public class WordPuzzleSolver
    {
        public string ReplaceCharBySameIndex(string start, string end, int index)
        {
            if (index >= 0 && index < start.Length && index < end.Length)
            {
                string replaced = start.Substring(0, index) + end[index] + start.Substring(index + 1);
                return replaced;
            }
            else
            {

                return start;
            }
        }

        public string ReplaceCharbyAlphabetIndex(string start, int index, List<string> dictionary)
        {

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();


            for (int j = 0; j < alphabet.Length; j++)
            {
                
                char[] referenceWord = start.ToCharArray();
                referenceWord[index] = alphabet[j];
                string newWord = new string(referenceWord);

               
                if (SearchWordOnDictionary(newWord, dictionary))
                {
                    return newWord;
                }
            }

            return string.Empty;
        }

        public bool SearchWordOnDictionary(string word, List<string> dictionary)
        {
            return dictionary.Contains(word.ToLower());
        }


        public List<string> Solve(string start, string end, List<string> dictionary)
        {
           
            start = start.ToLower();
            end = end.ToLower();

            List<string> solution = new List<string>();

            var index = 0;
            bool checkAlphabet = true;

            var reference = string.Empty;
            var reference2 = string.Empty;

            solution.Add(start);

            while (start != end && index <= start.Length)
            {
                if (start[index] != end[index])
                {
                    reference = ReplaceCharBySameIndex(start, end, index);
                }

                if (SearchWordOnDictionary(reference, dictionary) && reference != start)
                {
                    solution.Add(reference);
                    start = reference;
                    checkAlphabet = false;
                }

                if (checkAlphabet)
                {
                    reference2 = ReplaceCharbyAlphabetIndex(start, index, dictionary);

                        if (reference2 != string.Empty && reference2 != start)
                        {
                            solution.Add(reference2);
                            start = reference2;
                        }
                }


               

                //checkAlphabet = true;
                index++;


                if (index == start.Length && start != end)
                {
                    if (checkAlphabet)
                    {
                        start = reference2;
                        index = 0;
                    } else
                    {
                        start = reference;
                        index = 0;
                    }
                       
                }

                if(start == end)
                {
                    solution.Add(end);
                }
            }

            return solution;
        }


      
    }

}