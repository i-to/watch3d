using Watch3D.Core.Model;
using Watch3D.Core.ViewModel;

namespace Watch3D.Test.GuiStandalone
{
    public class SymbolInterpreterStub : SymbolInterpreter
    {
        public Logger Logger { get; }

        public SymbolInterpreterStub(Logger logger)
        {
            Logger = logger;
        }

        public SceneItemViewModel TryInterpretSymbol(string symbol)
        {
            Logger.Info($"Executed interpreter stub for symbol '{symbol}'.");
            return null;
        }
    }
}
