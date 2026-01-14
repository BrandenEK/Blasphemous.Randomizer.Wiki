using System.IO;

namespace blas1wikigen.Export;

public class LayoutExporter(string sourceDir, string exportDir) : ILayoutExporter
{
    public void Export(string name)
    {
        string sourcePath = Path.Combine(sourceDir, $"{name}.png");
        string exportPath = Path.Combine(exportDir, name, "layout.png");
        Logger.Info($"Exporting image to {exportPath}");

        Directory.CreateDirectory(Path.GetDirectoryName(exportPath)!);
        File.Copy(sourcePath, exportPath, true);
    }
}
