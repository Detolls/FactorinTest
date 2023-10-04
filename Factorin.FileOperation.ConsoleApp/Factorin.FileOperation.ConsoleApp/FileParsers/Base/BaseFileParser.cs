using Factorin.FileOperation.ConsoleApp.FileOperations;
using Factorin.FileOperation.ConsoleApp.Models;

namespace Factorin.FileOperation.ConsoleApp.FileParsers.Base
{
    public abstract class BaseFileParser : IFileParser
    {
        protected readonly IEnumerable<IFileOperation<BaseFileParser>> FileOperations;

        protected BaseFileParser(IEnumerable<IFileOperation<BaseFileParser>> fileOperations)
            => FileOperations = fileOperations;

        public abstract string FileExtension { get; }

        public virtual IReadOnlyCollection<FileParseResult> Parse(string path)
        {
            var result = new List<FileParseResult>();

            var text = File.ReadAllText(path);
            foreach (var fileOperation in FileOperations)
            {
                var value = fileOperation.Execute(text);
                result.Add(new FileParseResult
                {
                    FileName = Path.GetFileName(path),
                    OperationName = fileOperation.OperationName,
                    Value = value
                });
            }

            return result.AsReadOnly();
        }
    }
}
