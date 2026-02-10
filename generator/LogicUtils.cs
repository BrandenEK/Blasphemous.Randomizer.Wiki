
namespace blas1wikigen;

public static class LogicUtils
{
    public static string ProcessLogic(string logic)
    {
        if (string.IsNullOrEmpty(logic))
            return "-";

        logic = logic.Replace("&&", "+");
        logic = logic.Replace("||", "\\|");

        return logic;
    }
}
