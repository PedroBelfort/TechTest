using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzle.Interfaces
{
    public interface IFileService
    {
        List<string> ReadFile(string path);
        void ExportFile(List<string> result, string path);
        string GetFilePath();


    }
}
