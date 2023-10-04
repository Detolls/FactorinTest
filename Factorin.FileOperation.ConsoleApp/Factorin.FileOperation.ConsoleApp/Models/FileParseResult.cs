namespace Factorin.FileOperation.ConsoleApp.Models
{
    public class FileParseResult
    {
        public required string FileName { get; set; }

        public required string OperationName { get; set; }

        public object? Value { get; set; }

        public override string ToString() => $"{FileName}-{OperationName}-{Value}";
    }
}
