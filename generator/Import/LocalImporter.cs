using blas1wikigen.Models;
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
        Logger.Info($"Loading door info from {doorPath}");

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
        Logger.Info($"Loading item location info from {locationPath}");

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
