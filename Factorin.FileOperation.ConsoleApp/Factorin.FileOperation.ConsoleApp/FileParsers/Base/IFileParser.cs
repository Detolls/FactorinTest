using Factorin.FileOperation.ConsoleApp.Models;

namespace Factorin.FileOperation.ConsoleApp.FileParsers.Base
{
    public interface IFileParser
    {
        string FileExtension { get; }

        IReadOnlyCollection<FileParseResult> Parse(string path);
    }
}
