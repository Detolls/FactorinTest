using Factorin.FileOperation.ConsoleApp.FileOperations;
using Factorin.FileOperation.ConsoleApp.FileParsers.Base;

namespace Factorin.FileOperation.ConsoleApp.FileParsers
{
    public sealed class DefaultFileParser : BaseFileParser
    {
        public DefaultFileParser(IEnumerable<IFileOperation<DefaultFileParser>> fileOperations)
            : base(fileOperations) { }

        public override string FileExtension => null!;
    }
}
