using System.Collections.Generic;

namespace blas1wikigen.TextCreation;

public interface ITextCreator
{
    public string Create(string room, IEnumerable<Door> doors, IEnumerable<ItemLocation> locations);
}
