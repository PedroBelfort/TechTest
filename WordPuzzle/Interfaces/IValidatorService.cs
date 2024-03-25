using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzle.Interfaces
{
    public interface IValidatorService
    {
        void invalidLengthWord(string word);
        void wordNotExistOnDictionary(string word);
    }
}
