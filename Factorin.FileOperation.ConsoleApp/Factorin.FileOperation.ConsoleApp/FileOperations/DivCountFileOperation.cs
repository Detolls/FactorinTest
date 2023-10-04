using Factorin.FileOperation.ConsoleApp.FileParsers;
using System.Text.RegularExpressions;

namespace Factorin.FileOperation.ConsoleApp.FileOperations
{
    public sealed class DivCountFileOperation : IFileOperation<HtmlFileParser>
    {
        private readonly Regex divRegex = new Regex(@"<\s*div[^>]*>(.*?)<\s*/\s*div>");

        public string OperationName => "div_count";

        public object Execute(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            return divRegex.Matches(text).Count;
        }
    }
}
