using Newtonsoft.Json;

namespace blas1wikigen.Models;

public class Macro
{
    public string Name { get; }

    public string Hint { get; }

    [JsonConstructor]
    public Macro(string name, string hint)
    {
        Name = name;
        Hint = hint;
    }
}
