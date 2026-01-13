using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace blas1wikigen.Import;

public class GithubImporter(string doorUrl, string locationUrl) : IImporter
{
    public async Task<IEnumerable<Door>> LoadDoors()
    {
        Logger.Info($"Loading door info from {doorUrl}");
        using var client = new HttpClient();

        try
        {
            string json = await client.GetStringAsync(doorUrl);
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
        Logger.Info($"Loading item location info from {locationUrl}");
        using var client = new HttpClient();

        try
        {
            string json = await client.GetStringAsync(locationUrl);
            return JsonConvert.DeserializeObject<ItemLocation[]>(json)!;
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex);
            return [];
        }
    }
}
