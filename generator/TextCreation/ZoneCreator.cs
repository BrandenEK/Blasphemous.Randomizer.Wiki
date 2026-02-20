using blas1wikigen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blas1wikigen.TextCreation;

public class ZoneCreator : ITextCreator<Zone>
{
    private readonly IEnumerable<Room> _rooms;

    public ZoneCreator(IEnumerable<Room> rooms)
    {
        _rooms = rooms;
    }

    public string Create(Zone zone)
    {
        Logger.Info($"Creating text for zone {zone.Name}");
        var sb = new StringBuilder();

        // Front matter
        sb.AppendLine("---");
        sb.AppendLine($"title: {zone.Name}");
        sb.AppendLine($"last_modified_date: {DateTime.Now.ToString("yyyy-MM-dd")}");
        sb.AppendLine($"generator_version: {Version.GENERATOR_VERSION}");
        sb.AppendLine($"nav_order: {40 + zone.Order}");
        sb.AppendLine($"has_toc: false");
        sb.AppendLine("---");
        sb.AppendLine();

        // Header
        sb.AppendLine($"# {zone.Name}");
        sb.AppendLine();

        // Divider
        sb.AppendLine("---");
        sb.AppendLine();

        var roomsInZone = _rooms.Where(x => x.Zone == zone.Name);
        int numRooms = roomsInZone.Count();
        int numItems = roomsInZone.Sum(x => x.Items.Length);
        int numDoors = roomsInZone.Sum(x => x.Doors.Length);

        // Stats
        sb.AppendLine("| Number of rooms | Number of items | Number of doors |");
        sb.AppendLine("| :---: | :---: | :---: |");
        sb.AppendLine($"| {numRooms} | {numItems} | {numDoors} |");
        sb.AppendLine();

        return sb.ToString();
    }
}
