using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPuzzle.Exceptions;
using WordPuzzle.Interfaces;

namespace WordPuzzle.Services
{
    public class ValidatorService : IValidatorService
    {
        public void InvalidLengthWord(string word)
        {
            word = word.ToLower();
            if(word.Length > 4)
            {
                throw new WordValidationException($"The word '{word}' does not have the required length of 4 characters.");
            }
        }

        public void WordNotExistOnDictionary(string word, List<string> dictionary)
        {
            word = word.ToLower();
            if (!dictionary.Contains(word))
            {
                throw new WordValidationException($"The word '{word}' does not exist in the dictionary.");
            }
        }
    }
}
