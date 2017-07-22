using System;

namespace Watch3D.Gui
{
    public interface SymbolInterpreter
    {
        Tuple<string, string> TryAddItemBySymbolName(string meshSymbol);
    }
}