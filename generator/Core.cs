using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace blas1wikigen;

internal class Core
{
    static void Main(string[] args)
    {
        Logger.Info("Starting blas1 wiki generator...");

        if (args.Length != 2)
        {
            Logger.Fatal("Invalid number of parameters");
            return;
        }

        string doorsPath = args[0];
        Logger.Info($"Loading doors from {doorsPath}...");
        IEnumerable<Door> doors = LoadDoors(doorsPath);

        string locationsPath = args[1];
        Logger.Info($"Loading item locations from {locationsPath}...");
        IEnumerable<ItemLocation> locations = LoadItemLocations(locationsPath);

        Logger.Info(string.Empty);
        var rooms = doors.Select(x => x.Room).Concat(locations.Select(x => x.Room)).Distinct().OrderBy(x => x);

        foreach (string room in rooms.Where(x => x.StartsWith("D01Z01")))
        {
            Logger.Info($"Generating room {room}...");
            GenerateRoom(room, doors.Where(x => x.Room == room), locations.Where(x => x.Room == room));
        }
    }

    static IEnumerable<Door> LoadDoors(string path)
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<Door[]>(json)!;
    }

    static IEnumerable<ItemLocation> LoadItemLocations(string path)
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<ItemLocation[]>(json)!;
    }

    static string GenerateRoom(string room, IEnumerable<Door> doors, IEnumerable<ItemLocation> locations)
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

    static string GenerateDoorTable(IEnumerable<Door> doors)
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

    static string GenerateItemTable(IEnumerable<ItemLocation> locations)
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
