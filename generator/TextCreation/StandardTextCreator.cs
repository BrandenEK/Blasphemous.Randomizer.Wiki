using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blas1wikigen.TextCreation;

public class StandardTextCreator : ITextCreator
{
    public string Create(string room, IEnumerable<Door> doors, IEnumerable<ItemLocation> locations)
    {
        Logger.Info($"Creating text for room {room}");
        var sb = new StringBuilder();

        // Front matter
        sb.AppendLine("---");
        sb.AppendLine($"id: {room}");
        sb.AppendLine($"title: {room}");
        sb.AppendLine($"parent: The Holy Line");
        sb.AppendLine($"last_modified_date: {DateTime.Now.ToString("yyyy-MM-dd")}");
        sb.AppendLine($"generator_version: {Generator.GENERATOR_VERSION}");
        sb.AppendLine("---");
        sb.AppendLine();

        // Heading
        sb.AppendLine($"# {room}");
        sb.AppendLine();

        // Image
        sb.AppendLine("![Layout](layout.png)");
        sb.AppendLine();

        // Items
        sb.AppendLine("## Items");
        sb.AppendLine();
        sb.AppendLine(CreateItemTable(locations));
        sb.AppendLine();

        // Doors
        sb.AppendLine("## Doors");
        sb.AppendLine();
        sb.AppendLine(CreateDoorTable(doors));
        sb.AppendLine();

        return sb.ToString();
    }

    private string CreateDoorTable(IEnumerable<Door> doors)
    {
        if (!doors.Any())
            return "None";

        var sb = new StringBuilder();

        sb.AppendLine("| ID | Logic |");
        sb.AppendLine("| --- | --- |");

        foreach (Door door in doors)
            sb.AppendLine($"| {door.Id} | {door.Logic} |");

        return sb.ToString();
    }

    private string CreateItemTable(IEnumerable<ItemLocation> locations)
    {
        if (!locations.Any())
            return "None";

        var sb = new StringBuilder();

        sb.AppendLine("| ID | Name | Logic |");
        sb.AppendLine("| --- | --- | --- |");

        foreach (ItemLocation location in locations)
            sb.AppendLine($"| {location.Id} | {location.Name} | {location.Logic} |");

        return sb.ToString();
    }
}
