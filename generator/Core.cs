using blas1wikigen.Export;
using blas1wikigen.Import;
using blas1wikigen.TextCreation;
using System;
using System.IO;
using System.Threading.Tasks;

namespace blas1wikigen;

internal class Core
{
    static async Task Main(string[] args)
    {
        Logger.Info("Starting blas1 wiki generator...");

        string baseDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
        string importDir = Path.Combine(baseDir, "data");
        string exportDir = Path.Combine(baseDir, "publish");

        IImporter importer = args.Length == 2
            ? new LocalImporter(args[0], args[1])
            : new GithubImporter("https://raw.githubusercontent.com/BrandenEK/Blasphemous.Randomizer/main/resources/data/Randomizer/doors.json", "https://raw.githubusercontent.com/BrandenEK/Blasphemous.Randomizer/main/resources/data/Randomizer/locations_items.json");
        IExporter exporter = new DocsExporter(Path.Combine(exportDir, "rooms"));
        ITextCreator textCreator = new StandardTextCreator();

        var generator = new Generator(importer, exporter, textCreator);
        await generator.Run(importDir, exportDir);
    }
}
