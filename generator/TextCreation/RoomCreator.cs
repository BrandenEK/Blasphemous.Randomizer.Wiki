using blas1wikigen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blas1wikigen.TextCreation;

public class RoomCreator
{
    public string Create(Room room, IEnumerable<Door> doors, IEnumerable<ItemLocation> locations)
    {
        Logger.Info($"Creating text for room {room.Name}");
        var sb = new StringBuilder();

        // Front matter
        sb.AppendLine("---");
        sb.AppendLine($"title: {room.Name}");
        sb.AppendLine($"parent: {room.Zone}");
        sb.AppendLine($"last_modified_date: {DateTime.Now.ToString("yyyy-MM-dd")}");
        sb.AppendLine($"generator_version: {Generator.GENERATOR_VERSION}");
        sb.AppendLine($"nav_order: {room.Order}");
        sb.AppendLine("---");
        sb.AppendLine();

        // Header
        sb.AppendLine($"# {room.Name}");
        sb.AppendLine();

        // Image
        sb.AppendLine("![Layout](layout.png)");
        sb.AppendLine();

        // Items
        sb.AppendLine("## Items");
        sb.AppendLine();
        sb.Append(CreateItemTable(locations));
        sb.AppendLine();

        // Doors
        sb.AppendLine("## Doors");
        sb.AppendLine();
        sb.Append(CreateDoorTable(doors));
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
