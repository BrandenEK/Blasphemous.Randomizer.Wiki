using Newtonsoft.Json;

namespace blas1wikigen.Models;

public class Room
{
    public string Name { get; }

    public string Zone { get; }

    public int Order { get; }

    public string[] Items { get; }

    public string[] Doors { get; }

    [JsonConstructor]
    public Room(string name, string zone, int order, string[] items, string[] doors)
    {
        Name = name;
        Zone = zone;
        Order = order;
        Items = items;
        Doors = doors;
    }
}
