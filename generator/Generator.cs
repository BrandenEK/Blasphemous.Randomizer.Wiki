using blas1wikigen.EntityModification;
using blas1wikigen.Export;
using blas1wikigen.Import;
using blas1wikigen.Models;
using blas1wikigen.TextCreation;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace blas1wikigen;

public class Generator()
{
    public async Task Run(string dataDir, string exportDir)
    {
        Stopwatch sw = Stopwatch.StartNew();

        // Import data
        var internetImporter = new InternetImporter();
        IEnumerable<Door> doors = await internetImporter.Import<Door>("https://raw.githubusercontent.com/BrandenEK/Blasphemous.Randomizer/main/resources/data/Randomizer/doors.json");
        IEnumerable<ItemLocation> locations = await internetImporter.Import<ItemLocation>("https://raw.githubusercontent.com/BrandenEK/Blasphemous.Randomizer/main/resources/data/Randomizer/locations_items.json");

        var fileImporter = new FileImporter();
        IEnumerable<Zone> zones = await fileImporter.Import<Zone>(Path.Combine(dataDir, "zones.json"));
        IEnumerable<Room> rooms = await fileImporter.Import<Room>(Path.Combine(dataDir, "rooms.json"));
        IEnumerable<Macro> macros = await fileImporter.Import<Macro>(Path.Combine(dataDir, "macros.json"));

        sw.Stop();
        long loadTime = sw.ElapsedMilliseconds;
        sw.Restart();

        // Setup zone things
        var zoneCreator = new ZoneCreator();
        var zoneExporter = new InfoExporter(Path.Combine(exportDir, "zones"));

        // Create and export zone files
        foreach (Zone zone in zones)
        {
            string text = zoneCreator.Create(zone);
            zoneExporter.Export(zone.Name, text);
        }

        // Setup room things
        var logicModifier = new LogicModifier(macros);
        var roomCreator = new RoomCreator(logicModifier, locations, doors);
        var roomExporter = new InfoExporter(Path.Combine(exportDir, "rooms"));
        var roomLayoutExporter = new LayoutExporter(Path.Combine(dataDir, "roomimages"), Path.Combine(exportDir, "rooms"));

        // Create and export room files
        foreach (Room room in rooms)
        {
            string text = roomCreator.Create(room);
            roomExporter.Export(room.Name, text);
            roomLayoutExporter.Export(room.Name);
        }

        long exportTime = sw.ElapsedMilliseconds;

        Logger.Info($"Time to load data: {loadTime}ms");
        Logger.Info($"Time to generate docs: {exportTime}ms");
        sw.Stop();
    }
}
