using blas1wikigen.Models;
using System;
using System.Text;

namespace blas1wikigen.TextCreation;

public class ZoneCreator
{
    public string Create(Zone zone)
    {
        Logger.Info($"Creating text for zone {zone.Name}");
        var sb = new StringBuilder();

        // Front matter
        sb.AppendLine("---");
        sb.AppendLine($"title: {zone.Name}");
        sb.AppendLine($"last_modified_date: {DateTime.Now.ToString("yyyy-MM-dd")}");
        sb.AppendLine($"generator_version: {Generator.GENERATOR_VERSION}");
        sb.AppendLine($"nav_order: {40 + zone.Order}");
        sb.AppendLine("---");
        sb.AppendLine();

        // Header
        sb.AppendLine($"# {zone.Name}");
        sb.AppendLine();

        return sb.ToString();
    }
}
