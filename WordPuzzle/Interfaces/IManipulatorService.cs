namespace WordPuzzle.Interfaces
{
    public interface IManipulatorService
    {
        string ReplaceCharBySameIndex(string start, string end);
        List<string> ReplaceCharByAlphabetIndex(string start, List<string> dictionary, List<string> solution);
        string FindClosestWord(string reference, List<string> words);
    }
}
