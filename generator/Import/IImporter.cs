using System.Collections.Generic;
using System.Threading.Tasks;

namespace blas1wikigen.Import;

public interface IImporter
{
    public Task<IEnumerable<Door>> LoadDoors();

    public Task<IEnumerable<ItemLocation>> LoadItemLocations();
}
