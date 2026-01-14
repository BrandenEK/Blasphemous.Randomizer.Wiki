using System;
using System.IO;
using System.Threading.Tasks;

namespace blas1wikigen;

internal class Core
{
    static async Task Main(string[] args)
    {
        Logger.Info("Starting blas1 wiki generator...");

        if (args.Length < 1)
        {
            Logger.Fatal("Failed to pass output directory as argument");
            return;
        }

        string baseDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
        string dataDir = Path.Combine(baseDir, "data");
        string exportDir = Path.Combine(baseDir, args[0]);

        var generator = new Generator();
        await generator.Run(dataDir, exportDir);
    }
}
