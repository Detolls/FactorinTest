using Factorin.FileOperation.ConsoleApp.FileParsers;

namespace Factorin.FileOperation.ConsoleApp.FileOperations
{
    public sealed class PunctuationCountFileOperation : IFileOperation<DefaultFileParser>
    {
        public string OperationName => "punctuation_count";

        public object Execute(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            return text.Count(char.IsPunctuation);
        }
    }
}
