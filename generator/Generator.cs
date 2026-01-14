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
    public async Task Run()
    {
        IEnumerable<Door> doors = await importer.LoadDoors();
        IEnumerable<ItemLocation> locations = await importer.LoadItemLocations();
        var rooms = doors.Select(x => x.Room).Concat(locations.Select(x => x.Room)).Distinct().OrderBy(x => x);

        //foreach (string room in rooms.Where(x => x.StartsWith("D01Z01")))
        //{
        //    string text = textCreator.Create(room, doors.Where(x => x.Room == room), locations.Where(x => x.Room == room));
        //    exporter.Export(room, text);
        //}

        string baseDir = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..");
        var zoneImporter = new NewImporter<Zone>(Path.Combine(baseDir, "data", "zones.json"));
        IEnumerable<Zone> zones = zoneImporter.Import();

        var zoneCreator = new ZoneCreator();

        foreach (Zone zone in zones)
        {
            Logger.Warn(zone.Name);
            string text = zoneCreator.Create(zone);
            Logger.Error(text);
        }
    }

    public const int GENERATOR_VERSION = 1;
}
