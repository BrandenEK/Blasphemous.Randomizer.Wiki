
namespace blas1wikigen.Export;

public interface IExporterNew<T>
{
    public void Export(T obj, string text);
}
