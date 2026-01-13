using blas1wikigen.DataImport;

namespace blas1wikigen;

internal class Core
{
    static void Main(string[] args)
    {
        Logger.Info("Starting blas1 wiki generator...");

        if (args.Length != 2)
        {
            Logger.Fatal("Invalid number of parameters");
            return;
        }

        IImporter importer = new LocalImporter(args[0], args[1]);
        var generator = new Generator(importer);

        generator.Run();
    }
}
