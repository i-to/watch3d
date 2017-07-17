using System;

namespace Watch3D.Gui
{
    public interface SymbolInterpreter
    {
        Tuple<string, string> TryAddSceneItemFromSymbol(string meshSymbol);
    }
}