using blas1wikigen.Import;
using blas1wikigen.TextCreation;
using System.Threading.Tasks;

namespace blas1wikigen;

internal class Core
{
    static async Task Main(string[] args)
    {
        Logger.Info("Starting blas1 wiki generator...");

        IImporter importer = args.Length == 2
            ? new LocalImporter(args[0], args[1])
            : new GithubImporter("https://raw.githubusercontent.com/BrandenEK/Blasphemous.Randomizer/main/resources/data/Randomizer/doors.json", "https://raw.githubusercontent.com/BrandenEK/Blasphemous.Randomizer/main/resources/data/Randomizer/locations_items.json");
        ITextCreator textCreator = new StandardTextCreator();

        var generator = new Generator(importer, textCreator);
        await generator.Run();
    }
}
