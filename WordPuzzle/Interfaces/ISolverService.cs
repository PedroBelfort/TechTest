namespace WordPuzzle.Interfaces
{
    public interface ISolverService
    {
        List<string> Solve(string start, string end, List<string> dictionary);
    }
}
