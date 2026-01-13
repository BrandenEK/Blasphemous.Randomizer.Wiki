using blas1wikigen.DataImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blas1wikigen;

public class Generator(IImporter importer)
{
    public async void Run()
    {
        Logger.Info("Starting blas1 wiki generator...");

        if (args.Length != 2)
        {
            Logger.Fatal("Invalid number of parameters");
            return;
        }

        IImporter importer = new LocalImporter(args[0], args[1]);

        Logger.Info($"Loading door info...");
        IEnumerable<Door> doors = await importer.LoadDoors();

        Logger.Info($"Loading item location info...");
        IEnumerable<ItemLocation> locations = await importer.LoadItemLocations();

        Logger.Info(string.Empty);
        var rooms = doors.Select(x => x.Room).Concat(locations.Select(x => x.Room)).Distinct().OrderBy(x => x);

        foreach (string room in rooms.Where(x => x.StartsWith("D01Z01")))
        {
            Logger.Info($"Generating room {room}...");
            GenerateRoom(room, doors.Where(x => x.Room == room), locations.Where(x => x.Room == room));
        }
    }

    private string GenerateRoom(string room, IEnumerable<Door> doors, IEnumerable<ItemLocation> locations)
    {
        var sb = new StringBuilder();

        // Front matter
        sb.AppendLine("---");
        sb.AppendLine($"id: {room}");
        sb.AppendLine($"title: {room}");
        sb.AppendLine($"parent: The Holy Line");
        sb.AppendLine($"last_modified_date: {DateTime.Now.ToString("yyyy-MM-dd")}");
        sb.AppendLine($"generator_version: {GENERATOR_VERSION}");
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
        sb.AppendLine(GenerateItemTable(locations));
        sb.AppendLine();

        // Doors
        sb.AppendLine("## Doors");
        sb.AppendLine();
        sb.AppendLine(GenerateDoorTable(doors));
        sb.AppendLine();

        Logger.Error(sb);
        return sb.ToString();
    }

    private string GenerateDoorTable(IEnumerable<Door> doors)
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

    private string GenerateItemTable(IEnumerable<ItemLocation> locations)
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

    private const int GENERATOR_VERSION = 1;
}
