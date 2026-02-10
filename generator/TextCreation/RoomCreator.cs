using blas1wikigen.EntityModification;
using blas1wikigen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blas1wikigen.TextCreation;

public class RoomCreator : ITextCreator<Room>
{
    private readonly LogicModifier _logicModifier;
    private readonly Dictionary<string, ItemLocation> _locationMap;
    private readonly Dictionary<string, Door> _doorMap;

    public RoomCreator(LogicModifier logicModifier, IEnumerable<ItemLocation> locations, IEnumerable<Door> doors)
    {
        _logicModifier = logicModifier;
        _locationMap = locations.ToDictionary(x => x.Id, x => x);
        _doorMap = doors.ToDictionary(x => x.Id, x => x);
    }

    public string Create(Room room)
    {
        Logger.Info($"Creating text for room {room.Name}");
        var sb = new StringBuilder();

        // Front matter
        sb.AppendLine("---");
        sb.AppendLine($"title: {room.Name}");
        sb.AppendLine($"parent: {room.Zone}");
        sb.AppendLine($"last_modified_date: {DateTime.Now.ToString("yyyy-MM-dd")}");
        sb.AppendLine($"generator_version: {Version.GENERATOR_VERSION}");
        sb.AppendLine($"nav_order: {room.Order}");
        sb.AppendLine("---");
        sb.AppendLine();

        // Header
        sb.AppendLine($"# {room.Name}");
        sb.AppendLine();

        // Image
        sb.AppendLine($"<div style=\"display: inline-block; max-height: {MAX_HEIGHT_PIXELS}px; overflow: auto\">");
        sb.AppendLine($"<img src=\"layout.png\" style=\"min-width: max-content; min-height: max-content; zoom: {ZOOM_PERCENT}%\" />");
        sb.AppendLine("</div>");
        sb.AppendLine();

        // Items
        sb.AppendLine("## Items");
        sb.AppendLine();
        sb.Append(CreateItemTable(room.Items.Select(x => _locationMap[x])));
        sb.AppendLine();

        // Doors
        sb.AppendLine("## Doors");
        sb.AppendLine();
        sb.Append(CreateDoorTable(room.Doors.Select(x => _doorMap[x])));
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

    private const int MAX_HEIGHT_PIXELS = 500;
    private const int ZOOM_PERCENT = 60;
}
