using Newtonsoft.Json;

namespace blas1wikigen.Models;

public class Zone
{
    public string Name { get; }

    public int Order { get; }

    [JsonConstructor]
    public Zone(string name, int order)
    {
        Name = name;
        Order = order;
    }
}
