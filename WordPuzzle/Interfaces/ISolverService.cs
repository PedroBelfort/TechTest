using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzle.Interfaces
{
    public interface ISolverService
    {
        List<string> Solve(string start, string end, List<string> dictionary);
    }
}
