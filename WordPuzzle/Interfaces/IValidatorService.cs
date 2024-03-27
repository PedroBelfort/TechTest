namespace WordPuzzle.Interfaces
{
    public interface IValidatorService
    {
        void ValidateLengthWord(string word);
        void ValidateWordExistOnDictionary(string word, List<string> dictionary);
    }
}
