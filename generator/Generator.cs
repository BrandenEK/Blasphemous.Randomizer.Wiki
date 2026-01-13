using blas1wikigen.Export;
using blas1wikigen.Import;
using blas1wikigen.TextCreation;
using System.Collections.Generic;
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

        foreach (string room in rooms.Where(x => x.StartsWith("D01Z01")))
        {
            string text = textCreator.Create(room, doors.Where(x => x.Room == room), locations.Where(x => x.Room == room));
            exporter.Export(room, text);
        }
    }

    public const int GENERATOR_VERSION = 1;
}
