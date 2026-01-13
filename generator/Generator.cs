using blas1wikigen.DataImport;
using blas1wikigen.TextCreation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blas1wikigen;

public class Generator(IImporter importer, ITextCreator textCreator)
{
    public async Task Run()
    {
        Logger.Info($"Loading door info...");
        IEnumerable<Door> doors = await importer.LoadDoors();

        Logger.Info($"Loading item location info...");
        IEnumerable<ItemLocation> locations = await importer.LoadItemLocations();

        Logger.Info(string.Empty);
        var rooms = doors.Select(x => x.Room).Concat(locations.Select(x => x.Room)).Distinct().OrderBy(x => x);

        foreach (string room in rooms.Where(x => x.StartsWith("D01Z01")))
        {
            Logger.Info($"Generating room {room}...");
            string text = textCreator.Create(room, doors.Where(x => x.Room == room), locations.Where(x => x.Room == room));

            Logger.Error(text);
        }
    }

    public const int GENERATOR_VERSION = 1;
}
