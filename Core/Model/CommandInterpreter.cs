using Watch3D.Core.Debugger;
using Watch3D.Core.ViewModel;

namespace Watch3D.Core.Model
{
    public class CommandInterpreter
    {
        public Logger Logger { get; }
        public SceneViewModel Scene { get; }
        public DebuggerState DebuggerState { get; }
        public AddSceneItemFromLiteralCommand AddSceneItemFromLiteralCommand { get; }
        public SymbolInterpreter SymbolInterpreter { get; }

        public CommandInterpreter(
            Logger logger,
            SceneViewModel scene,
            DebuggerState debuggerState,
            AddSceneItemFromLiteralCommand addSceneItemFromLiteralCommand,
            SymbolInterpreter symbolInterpreter)
        {
            SymbolInterpreter = symbolInterpreter;
            Scene = scene;
            AddSceneItemFromLiteralCommand = addSceneItemFromLiteralCommand;
            Logger = logger;
            DebuggerState = debuggerState;
        }

        public void Execute(string command)
        {
            if (AddSceneItemFromLiteralCommand.TryAddFromLiteral(command))
                return;
            TryAddDebugSymbol(command);
        }

        void TryAddDebugSymbol(string command)
        {
            if (!DebuggerState.IsBreakMode)
            {
                Logger.Error($"Not recognized command: '{command}'.\n\t" +
                             "Cannot interpret as a symbol because not in break mode.");
                return;
            }
            var sceneItem = SymbolInterpreter.TryInterpretSymbol(command);
            if (sceneItem != null)
                Scene.AddItem(sceneItem);
        }
    }
}