using Factorin.FileOperation.ConsoleApp.FileOperations;
using Factorin.FileOperation.ConsoleApp.FileParsers;
using Factorin.FileOperation.ConsoleApp.FileParsers.Base;
using Microsoft.Extensions.DependencyInjection;

var provider = ConfigureServices();

var directoryPath = args.FirstOrDefault();

using var watcher = new FileSystemWatcher(directoryPath)
{
    NotifyFilter = NotifyFilters.FileName
};

var resultFilePath = Path.Combine(directoryPath, "_result.txt");

if (!File.Exists(resultFilePath))
    File.Create(resultFilePath);

watcher.Created += (s, e) =>
{
    var fileName = e.Name;
    if (string.Equals(fileName, Path.GetFileName(resultFilePath)))
        return;

    var fileExtension = Path.GetExtension(fileName);

    var parsers = provider.GetServices<IFileParser>();
    var defaultParser = parsers.First(p => p.FileExtension == null);
    var parser = parsers
        .Where(p => p.FileExtension != null)
        .FirstOrDefault(p => p.FileExtension
            .Equals(fileExtension, StringComparison.InvariantCultureIgnoreCase)) 
        ?? defaultParser;

    var results = parser.Parse(e.FullPath);
    foreach (var result in results)
        File.AppendAllText(resultFilePath, $"{result}{Environment.NewLine}");
};

watcher.EnableRaisingEvents = true;

Console.ReadKey();

ServiceProvider ConfigureServices() => new ServiceCollection()
    .AddSingleton<IFileParser, HtmlFileParser>()
    .AddSingleton<IFileParser, CssFileParser>()
    .AddSingleton<IFileParser, DefaultFileParser>()
    .AddSingleton<IFileOperation<HtmlFileParser>, DivCountFileOperation>()
    .AddSingleton<IFileOperation<CssFileParser>, BracketsPairFileOperation>()
    .AddSingleton<IFileOperation<DefaultFileParser>, PunctuationCountFileOperation>()
    .BuildServiceProvider();
