using Newtonsoft.Json;

namespace blas1wikigen;

public class Door
{
    public string Id { get; }

    public string Name { get; }

    public string Logic { get; }

    public string Room { get; }

    [JsonConstructor]
    public Door(string id, string logic)
    {
        Id = id;
        Name = string.Empty;
        Logic = LogicUtils.ProcessLogic(logic);
        Room = id.Substring(0, id.IndexOf('['));
    }
}
