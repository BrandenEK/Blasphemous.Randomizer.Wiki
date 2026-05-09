using blas1wikigen.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace blas1wikigen.EntityModification;

public class LogicModifier
{
    private readonly IEnumerable<Macro> _macros;
    private readonly Dictionary<Macro, string> _logicCache = [];

    public LogicModifier(IEnumerable<Macro> macros)
    {
        _macros = macros;

        foreach (var macro in macros)
        {
            string hint = LogicUtils.ProcessLogic(macro.Hint);
            string text = $"<span class=\"macro\"> {macro.Name} <span class=\"macrohint\"> {hint} </span> </span>";
            _logicCache.Add(macro, text);
        }
    }

    public string ModifyLogic(string logic)
    {
        foreach (var macro in _macros)
        {
            logic = Regex.Replace(logic, $"\\b{macro.Name}\\b", _logicCache[macro]);
        }

        return logic;
    }
}
