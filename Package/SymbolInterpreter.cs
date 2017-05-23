using System;
using Watch3D.Core.Debugger;
using Watch3D.Core.Scene;

namespace Watch3D.Package
{
    public class SymbolInterpreter
    {
        public ExpressionReader ExpressionReader { get; }
        public DebuggerState DebuggerState { get; }
        public Scene Scene { get; }

        public SymbolInterpreter(ExpressionReader expressionReader, DebuggerState debuggerState, Scene scene)
        {
            ExpressionReader = expressionReader;
            DebuggerState = debuggerState;
            Scene = scene;
        }

        public Tuple<string, string> TryAddSceneItemFromSymbol(string meshSymbol)
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