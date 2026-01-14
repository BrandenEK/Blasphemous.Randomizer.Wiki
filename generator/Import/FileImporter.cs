using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace blas1wikigen.Import;

public class FileImporter : IImporter
{
    public async Task<IEnumerable<T>> Import<T>(string path)
    {
        Logger.Info($"Loading {typeof(T).Name} info from {path}");

        try
        {
            string json = await File.ReadAllTextAsync(path);
            return JsonConvert.DeserializeObject<T[]>(json)!;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
            return [];
        }
    }
}
