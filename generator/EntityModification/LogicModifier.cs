using blas1wikigen.Models;
using System.Collections.Generic;

namespace blas1wikigen.EntityModification;

public class LogicModifier
{
    private readonly IEnumerable<Macro> _macros;

    public LogicModifier(IEnumerable<Macro> macros)
    {
        _macros = macros;
    }

    public string ModifyLogic(string logic)
    {
        foreach (var macro in _macros)
        {
            string hintlogic = LogicUtils.ProcessLogic(macro.Hint);
            string result = $"<span class=\"macro\"> {macro.Name} <span class=\"macrohint\"> {hintlogic} </span> </span>";
            logic = logic.Replace(macro.Name, result);
        }

        return logic;
    }
}
