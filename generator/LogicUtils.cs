
namespace blas1wikigen;

public static class LogicUtils
{
    public static string ProcessLogic(string logic)
    {
        if (string.IsNullOrEmpty(logic))
            return "-";

        return logic.Replace("|", "\\|");
    }
}
