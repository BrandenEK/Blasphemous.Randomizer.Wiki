using blas1wikigen.Models;
using System.IO;

namespace blas1wikigen.Export;

public class ZoneExporter(string baseDir) : IExporterNew<Zone>
{
    public void Export(Zone obj, string text)
    {
        string path = Path.Combine(baseDir, obj.Name, "info.md");
        Logger.Info($"Exporting text to {path}");

        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, text);
    }
}
