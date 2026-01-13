using Newtonsoft.Json;

namespace blas1wikigen;

public class ItemLocation
{
    public string Id { get; }

    public string Name { get; }

    public string Logic { get; }

    public string Room { get; }

    [JsonConstructor]
    public ItemLocation(string id, string name, string logic, string room)
    {
        Id = id;
        Name = name;
        Logic = logic;
        Room = room;
    }
}
