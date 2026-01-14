using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace blas1wikigen.Import;

public class NewImporter
{
    public IEnumerable<T> Import<T>(string path)
    {
        Logger.Info($"Loading {typeof(T).Name} info from {path}");

        try
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T[]>(json)!;
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex);
            return [];
        }
    }
}
