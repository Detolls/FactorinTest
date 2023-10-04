using Factorin.FileOperation.ConsoleApp.FileOperations;
using Factorin.FileOperation.ConsoleApp.FileParsers.Base;

namespace Factorin.FileOperation.ConsoleApp.FileParsers
{
    public sealed class HtmlFileParser : BaseFileParser
    {
        public HtmlFileParser(IEnumerable<IFileOperation<HtmlFileParser>> fileOperations)
            : base(fileOperations) { }

        public override string FileExtension => ".html";
    }
}
