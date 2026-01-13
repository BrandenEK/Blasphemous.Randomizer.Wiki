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

    static void GenerateRoom(string room, IEnumerable<Door> doors, IEnumerable<ItemLocation> locations)
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

        sb.AppendLine("None");
        sb.AppendLine();

        // Doors
        sb.AppendLine("## Doors");
        sb.AppendLine();

        sb.AppendLine("None");
        sb.AppendLine();

        Logger.Error(sb);
    }

    private const int GENERATOR_VERSION = 1;
}
