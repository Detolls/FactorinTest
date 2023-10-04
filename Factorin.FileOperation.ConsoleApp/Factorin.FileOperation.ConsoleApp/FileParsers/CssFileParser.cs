using Factorin.FileOperation.ConsoleApp.FileOperations;
using Factorin.FileOperation.ConsoleApp.FileParsers.Base;

namespace Factorin.FileOperation.ConsoleApp.FileParsers
{
    public sealed class CssFileParser : BaseFileParser
    {
        public CssFileParser(IEnumerable<IFileOperation<CssFileParser>> fileOperations)
            : base(fileOperations) { }

        public override string FileExtension => ".css";
    }
}
