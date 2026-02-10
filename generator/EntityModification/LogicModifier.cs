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
        return logic;
    }
}
