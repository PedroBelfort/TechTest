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
                var a = start.Substring(0, index);
                var b = end[index];
                var c = start.Substring(index + 1);

                string replaced = start.Substring(0, index) + end[index] + start.Substring(index + 1);
                return replaced;
            }
            else
            {

                return start;
            }
        }




    }
}
