using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzle.Exceptions
{
    public class WordValidationException : Exception
    {
        public WordValidationException(string message) : base(message)
        {
        }
    }
}
