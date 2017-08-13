using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using EnvDTE;
using EnvDTE100;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Watch3D.Core;
using Watch3D.Core.Debugger;
using Watch3D.Core.Model;
using Watch3D.Core.Utility;
using Watch3D.Core.ViewModel;
using Watch3D.Gui;
using Watch3D.Package.Debugger;
using Watch3D.Package.ToolWindow;
using Watch3D.VisualizerServices;

namespace Watch3D.Package
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid("8dc410ba-6829-453f-9c37-403af79451fe")] // Package GUID, duplicated in VSCT file.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ThePane))]
    [ProvideService(typeof(VisualizerService))]
    public class ThePackage : Microsoft.VisualStudio.Shell.Package
    {
        CommandsRegistrar CommandsRegistrar;
        ExpressionInterpreter ExpressionInterpreter;
        DebuggerState DebuggerState;
        SceneViewModel SceneViewModel;
        VisualizerService VisualizerService;
        DebugSymbolInterpreter SymbolInterpreter;
        CurrentSymbolProvider CurrentSymbolProvider;
        ToolViewModel ToolViewModel;

        public ThePackage()
        {
            IServiceContainer serviceContainer = this;
            serviceContainer.AddService(typeof(VisualizerService), CreateVisualizerServiceCallback, true);
        }

        VisualizerService CreateVisualizerServiceCallback(IServiceContainer container, Type servicetype)
        {
            if (container != this || !typeof(VisualizerService).IsEquivalentTo(servicetype))
                throw new ArgumentException();
            return VisualizerService;
        }

        protected override void Initialize()
        {
            base.Initialize();
            var commandService = this.GetService<IMenuCommandService>();
            CommandsRegistrar = new CommandsRegistrar(commandService);
            CommandsRegistrar.RegisterCommand(
                CommandIds.Watch3DCommandSet, CommandIds.ShowToolWindowCommandId, ExecuteShowToolWindow);
            CommandsRegistrar.RegisterCommand(
                CommandIds.Watch3DCommandSet, CommandIds.AddSymbolFromEditorCommandId, ExecuteAddSymbolFromEditor);
            var dte = this.GetService<DTE2, DTE>();
            var debugger = (Debugger5) dte.Debugger;
            var debugContext = new DteDebugContext(debugger);
            var expressionEvaluator = new ExpressionEvaluator(debugContext);
            var sceneItemsFactory = new SceneItemFactory();
            var interopParser = new InteropParser();
            ExpressionInterpreter = new ExpressionInterpreter(expressionEvaluator, sceneItemsFactory, interopParser);
            DebuggerState = new DteDebuggerState(debugger);
            var sceneItems = new ObservableCollectionWithReplace<SceneItemViewModel>();
            var sceneItemCollectionAdapter = new SceneItemCollectionAdapter(sceneItems);
            SceneViewModel = new SceneViewModel(sceneItems, sceneItemCollectionAdapter);
            var visualizerAddItems = new AddGeometryToScene(SceneViewModel, sceneItemsFactory);
            SymbolInterpreter = new DebugSymbolInterpreter(ExpressionInterpreter, DebuggerState, SceneViewModel);
            var sceneInitializer = new SceneInitializer(sceneItemsFactory);
            ToolViewModel = new ToolViewModel(SceneViewModel, SymbolInterpreter, sceneInitializer);
            VisualizerService = new WatchVisualizerService(visualizerAddItems);
            CurrentSymbolProvider = new CurrentSymbolProvider(dte);
        }

        ThePane CreateToolWindow() =>
            new ThePane
            {
                Caption = "Watch 3D",
                Content = new ToolView(ToolViewModel)
            };

        protected override WindowPane InstantiateToolWindow(Type toolWindowType) =>
            toolWindowType == typeof(ThePane)
                ? CreateToolWindow()
                : base.InstantiateToolWindow(toolWindowType);

        void ExecuteShowToolWindow()
        {
            var window = FindToolWindow(typeof(ThePane), 0, true);
            var windowFrame = (IVsWindowFrame) window.Frame;
            windowFrame.Show();
        }

        void ExecuteAddSymbolFromEditor()
        {
            var symbol = CurrentSymbolProvider.GetSelectedSymbol();
            SymbolInterpreter.TryAddItemBySymbolName(symbol);
        }
    }
}
