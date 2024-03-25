using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzle.Interfaces
{
    public interface IValidatorService
    {
        void InvalidLengthWord(string word);
        void WordNotExistOnDictionary(string word, List<string> dictionary);
    }
}
