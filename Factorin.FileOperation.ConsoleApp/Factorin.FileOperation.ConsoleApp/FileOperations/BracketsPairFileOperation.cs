using Factorin.FileOperation.ConsoleApp.FileParsers;

namespace Factorin.FileOperation.ConsoleApp.FileOperations
{
    public sealed class BracketsPairFileOperation : IFileOperation<CssFileParser>
    {
        public string OperationName => "brackets_pair";

        public object Execute(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            var stack = new Stack<char>();
            foreach (var symbol in text)
            {
                if (symbol == '{') 
                    stack.Push(symbol);
                else if (symbol != '}') 
                    continue;
                else if (stack.Count == 0) 
                    return false;
                else 
                    stack.Pop();
            }

            return stack.Count == 0;
        }
    }
}
