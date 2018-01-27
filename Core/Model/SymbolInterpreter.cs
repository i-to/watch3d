using Watch3D.Core.ViewModel;

namespace Watch3D.Core.Model
{
    public interface SymbolInterpreter
    {
        SceneItemViewModel TryInterpretSymbol(string symbol);
    }
}