using Watch3D.Core.Debugger;
using Watch3D.Core.Model;
using Watch3D.Core.ViewModel;
using Watch3D.Gui;

namespace Watch3D.Package
{
    public class DebugSymbolInterpreter : SymbolInterpreter
    {
        public ExpressionInterpreter ExpressionInterpreter { get; }
        public DebuggerState DebuggerState { get; }
        public SceneViewModel Scene { get; }

        public DebugSymbolInterpreter(ExpressionInterpreter expressionInterpreter, DebuggerState debuggerState, SceneViewModel scene)
        {
            ExpressionInterpreter = expressionInterpreter;
            DebuggerState = debuggerState;
            Scene = scene;
        }

        public void TryAddItemBySymbolName(string symbol)
        {
            if (!DebuggerState.IsBreakMode)
                return;
            var mesh = ExpressionInterpreter.TryInterpretSymbol(symbol);
            if (mesh == null)
                return;
            Scene.AddItem(mesh);
        }
    }
}