using System;
using System.ComponentModel.Design;
using EnvDTE100;
using EnvDTE80;
using Microsoft.VisualStudio.Shell.Interop;
using Watch3D.Core;
using Watch3D.Core.Debugger;
using Watch3D.Core.Model;
using Watch3D.Core.Utility;
using Watch3D.Core.ViewModel;
using Watch3D.Gui;
using Watch3D.VisualizerServices;

namespace Watch3D.Package
{
    public class Root
    {
        public readonly Logger Logger;
        public readonly CommandsRegistrar CommandsRegistrar;
        public readonly SymbolInterpreter SymbolInterpreter;
        public readonly DebuggerState DebuggerState;
        public readonly SceneViewModel SceneViewModel;
        public readonly VisualizerService VisualizerService;
        public readonly CommandInterpreter CommandInterpreter;
        public readonly CurrentSymbolProvider CurrentSymbolProvider;
        public readonly ToolViewModel ToolViewModel;

        public Root(
            IVsOutputWindow outputWindowService,
            IMenuCommandService commandService,
            DTE2 dte,
            Debugger5 debugger,
            Action showToolWindowCallback)
        {
            Logger = new OutputWindowLogger(outputWindowService);
            
            CommandsRegistrar = new CommandsRegistrar(commandService);
            CommandsRegistrar.RegisterCommand(
                CommandIds.Watch3DCommandSet, CommandIds.ShowToolWindowCommandId, showToolWindowCallback);
            CommandsRegistrar.RegisterCommand(
                CommandIds.Watch3DCommandSet, CommandIds.AddSymbolFromEditorCommandId, ExecuteCommandFromEditorCallback);
            
            var debugContext = new DteDebugContext(debugger);
            var expressionEvaluator = new ExpressionEvaluator(debugContext);
            var sceneItemsFactory = new SceneItemFactory();
            var interopParser = new InteropParser();
            var sceneItemDeserializer = new SceneItemDeserializer(interopParser, sceneItemsFactory);
            SymbolInterpreter = new DebuggeeSymbolInterpreter(Logger, expressionEvaluator, sceneItemDeserializer);
            DebuggerState = new DteDebuggerState(debugger);
            var sceneItems = new ObservableCollectionWithReplace<SceneItemViewModel>();
            var sceneItemCollectionAdapter = new SceneItemCollectionAdapter(sceneItems);
            SceneViewModel = new SceneViewModel(sceneItems, sceneItemCollectionAdapter);
            var visualizerAddItems = new AddGeometryToScene(SceneViewModel, sceneItemsFactory);
            var addSceneItemFromLiteralCommand =
                new AddSceneItemFromLiteralCommand(Logger, SceneViewModel, sceneItemDeserializer);
            CommandInterpreter = new CommandInterpreter(Logger, SceneViewModel, DebuggerState, addSceneItemFromLiteralCommand, SymbolInterpreter);
            var sceneInitializer = new SceneInitializer(sceneItemsFactory);
            var stlWriter = new VisualStlSerializer();
            var debugInteropWriter = new DebugInteropSerializer();
            var exporter = new Exporter(Logger, stlWriter, debugInteropWriter);
            ToolViewModel = new ToolViewModel(SceneViewModel, CommandInterpreter, sceneInitializer, exporter);
            VisualizerService = new WatchVisualizerService(visualizerAddItems);
            CurrentSymbolProvider = new CurrentSymbolProvider(dte);
        }

        void ExecuteCommandFromEditorCallback()
        {
            var symbol = CurrentSymbolProvider.GetSelectedSymbol();
            CommandInterpreter.Execute(symbol);
        }

        public ThePane CreateToolWindow() =>
            new ThePane
            {
                Caption = "Watch 3D",
                Content = new ToolView(ToolViewModel)
            };

        public VisualizerService CreateVisualizerServiceCallback(IServiceContainer container, Type servicetype)
        {
            if (container != this || !typeof(VisualizerService).IsEquivalentTo(servicetype))
                throw new ArgumentException();
            return VisualizerService;
        }
    }
}