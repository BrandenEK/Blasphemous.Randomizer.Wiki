using blas1wikigen.Export;
using blas1wikigen.Import;
using blas1wikigen.Models;
using blas1wikigen.TextCreation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace blas1wikigen;

public class Generator(IImporter importer, IExporter exporter, ITextCreator textCreator)
{
    public async Task Run(string importDir, string exportDir)
    {
        //IEnumerable<Door> doors = await importer.LoadDoors();
        //IEnumerable<ItemLocation> locations = await importer.LoadItemLocations();
        //var rooms = doors.Select(x => x.Room).Concat(locations.Select(x => x.Room)).Distinct().OrderBy(x => x);

        //foreach (string room in rooms.Where(x => x.StartsWith("D01Z01")))
        //{
        //    string text = textCreator.Create(room, doors.Where(x => x.Room == room), locations.Where(x => x.Room == room));
        //    exporter.Export(room, text);
        //}

        await NewStuff(importDir, exportDir);
    }

    private async Task NewStuff(string importDir, string exportDir)
    {
        // Import data
        var internetImporter = new InternetImporter();
        IEnumerable<Door> doors = await internetImporter.Import<Door>("https://raw.githubusercontent.com/BrandenEK/Blasphemous.Randomizer/main/resources/data/Randomizer/doors.json");
        IEnumerable<ItemLocation> locations = await internetImporter.Import<ItemLocation>("https://raw.githubusercontent.com/BrandenEK/Blasphemous.Randomizer/main/resources/data/Randomizer/locations_items.json");

        // TODO - Change these to async as well

        var newImporter = new NewImporter();
        IEnumerable<Zone> zones = newImporter.Import<Zone>(Path.Combine(importDir, "zones.json"));
        IEnumerable<Room> rooms = newImporter.Import<Room>(Path.Combine(importDir, "rooms.json"));

        // Setup zone things
        var zoneCreator = new ZoneCreator();
        var zoneExporter = new TextExporter(Path.Combine(exportDir, "zones"));

        // Create and export zone files
        foreach (Zone zone in zones)
        {
            string text = zoneCreator.Create(zone);
            zoneExporter.Export(zone.Name, text);
        }

        // Setup room things
        var roomCreator = new RoomCreator(locations, doors);
        var roomExporter = new TextExporter(Path.Combine(exportDir, "rooms"));
        
        // Create and export room files
        foreach (Room room in rooms)
        {
            string text = roomCreator.Create(room);
            roomExporter.Export(room.Name, text);
        }
    }

    public const int GENERATOR_VERSION = 1;
}
