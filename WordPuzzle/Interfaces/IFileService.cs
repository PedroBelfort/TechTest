namespace WordPuzzle.Interfaces
{
    public interface IFileService
    {
        List<string> ReadFile(string path);
        void ExportFile(List<string> result, string path);
        string GetFilePath();


    }
}
