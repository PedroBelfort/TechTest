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

        public string ReplaceCharbyAlphabetIndex(string start, int index, List<string> dictionary, List<string> solution)
        {

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();


            for (int j = 0; j < alphabet.Length; j++)
            {

                char[] referenceWord = start.ToCharArray();
                referenceWord[index] = alphabet[j];
                string newWord = new string(referenceWord);


                if (SearchWordOnDictionary(newWord, dictionary) && !solution.Contains(newWord))
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
            int index = 0;
            start = start.ToLower();
            end = end.ToLower();
            List<string> solution = new List<string>();

            string reference = string.Empty;
            bool searchOnAlphabet = true;

            solution.Add(start);

            while (start != end && index <= start.Length)
            {
                if (start[index] != end[index])
                {
                    reference = ReplaceCharBySameIndex(start, end, index);

                    if (SearchWordOnDictionary(reference, dictionary) && reference != start)
                    {
                        if (!solution.Contains(reference))
                        {
                            solution.Add(reference);
                            start = reference;
                            searchOnAlphabet = false;
                        }
                    }

                    if (searchOnAlphabet && reference != start)
                    {
                        reference = ReplaceCharbyAlphabetIndex(start, index, dictionary, solution);

                        if (!solution.Contains(reference))
                        {
                            solution.Add(reference);
                            start = reference;
                        }
                    }

                    searchOnAlphabet = true;
                }

                index++;

                if (index == start.Length && start != end)
                {
                    start = reference;
                    index = 0;
                }
            }
            return solution;
        }
    }
}