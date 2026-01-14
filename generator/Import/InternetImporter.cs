using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace blas1wikigen.Import;

public class InternetImporter
{
    public async Task<IEnumerable<T>> Import<T>(string url)
    {
        Logger.Info($"Loading {typeof(T).Name} info from {url}");

        using var client = new HttpClient();

        try
        {
            string json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T[]>(json)!;
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex);
            return [];
        }
    }
}
