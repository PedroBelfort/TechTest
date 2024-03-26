using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzle.Interfaces
{
    public interface IValidatorService
    {
        void ValidateLengthWord(string word);
        void ValidateWordExistOnDictionary(string word, List<string> dictionary);
    }
}
