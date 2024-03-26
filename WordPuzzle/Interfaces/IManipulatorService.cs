using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzle.Interfaces
{
    public interface IManipulatorService
    {
        string ReplaceCharBySameIndex(string start, string end);
        List<string> ReplaceCharByAlphabetIndex(string start, List<string> dictionary, List<string> solution);
        string FindClosestWord(string reference, List<string> words);
    }
}
