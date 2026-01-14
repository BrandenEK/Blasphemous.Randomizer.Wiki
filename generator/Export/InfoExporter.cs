using System.IO;

namespace blas1wikigen.Export;

public class InfoExporter(string baseDir) : IInfoExporter
{
    public void Export(string name, string text)
    {
        string path = Path.Combine(baseDir, name, "info.md");
        Logger.Info($"Exporting text to {path}");

        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, text);
    }
}
