using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace blas1wikigen.Import;

public class LocalImporter(string doorPath, string locationPath) : IImporter
{
    public async Task<IEnumerable<Door>> LoadDoors()
    {
        try
        {
            string json = await File.ReadAllTextAsync(doorPath);
            return JsonConvert.DeserializeObject<Door[]>(json)!;
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex);
            return [];
        }
    }

    public async Task<IEnumerable<ItemLocation>> LoadItemLocations()
    {
        try
        {
            string json = await File.ReadAllTextAsync(locationPath);
            return JsonConvert.DeserializeObject<ItemLocation[]>(json)!;
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex);
            return [];
        }
    }
}
