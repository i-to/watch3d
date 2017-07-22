using System;
using Watch3D.Core.Debugger;
using Watch3D.Core.Model;
using Watch3D.Gui;

namespace Watch3D.Package
{
    public class DebugSymbolInterpreter : SymbolInterpreter
    {
        public ExpressionReader ExpressionReader { get; }
        public DebuggerState DebuggerState { get; }
        public Scene Scene { get; }

        public DebugSymbolInterpreter(ExpressionReader expressionReader, DebuggerState debuggerState, Scene scene)
        {
            ExpressionReader = expressionReader;
            DebuggerState = debuggerState;
            Scene = scene;
        }

        public Tuple<string, string> TryAddItemBySymbolName(string meshSymbol)
        {
            if (!DebuggerState.IsBreakMode)
                return Tuple.Create("ERROR", "Cannot evaluate expression while not in break mode.");
            var mesh = ExpressionReader.TryReadMesh(meshSymbol);
            if (mesh == null)
                return Tuple.Create("ERROR", $"Failed to evaluate mesh symbol: '{meshSymbol}'.");
            Scene.AddMesh(mesh);
            return Tuple.Create("Success", $"Evaluated mesh symbol: '{meshSymbol}'.");
        }
    }
}