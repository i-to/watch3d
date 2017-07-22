using System;
using Watch3D.Gui;

namespace Watch3D.Test.GuiStandalone
{
    public class SymbolInterpreterStub : SymbolInterpreter
    {
        public Tuple<string, string> TryAddItemBySymbolName(string meshSymbol) =>
            Tuple.Create("STUB", "STUB");
    }
}