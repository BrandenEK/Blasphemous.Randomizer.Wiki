using System.IO;

namespace blas1wikigen.Export;

public class DocsExporter(string docsDir) : IExporter
{
    public void Export(string room, string text)
    {
        string path = Path.Combine(docsDir, room, "info.md");
        Logger.Info($"Exporting text to {path}");


    }
}
