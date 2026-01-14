using System.Collections.Generic;
using System.Threading.Tasks;

namespace blas1wikigen.Import;

public interface IImporter
{
    public Task<IEnumerable<T>> Import<T>(string location);
}
