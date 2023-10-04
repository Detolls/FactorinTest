using Factorin.FileOperation.ConsoleApp.FileParsers.Base;

namespace Factorin.FileOperation.ConsoleApp.FileOperations
{
    public interface IFileOperation<out T> where T : IFileParser
    {
        string OperationName { get; }

        object Execute(string text);
    }
}
