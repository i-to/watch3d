using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using EnvDTE;
using EnvDTE100;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Watch3D.Core;
using Watch3D.Core.Debugger;
using Watch3D.Core.Scene;
using Watch3D.Core.Utility;
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
        ExpressionReader ExpressionReader;
        DebuggerState DebuggerState;
        SceneViewModel SceneViewModel;
        VisualizerService VisualizerService;
        SymbolInterpreter SymbolInterpreter;

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
            var expressionFactory = new TestDebuggeeExpressionFactory();
            ExpressionReader = new ExpressionReader(expressionFactory, debugContext);
            DebuggerState = new DteDebuggerState(debugger);
            var sceneItems = new ObservableCollectionWithReplace<SceneItemViewModel>();
            var sceneItemCollectionAdapter = new SceneItemCollectionAdapter(sceneItems);
            SceneViewModel = new SceneViewModel(sceneItems, sceneItemCollectionAdapter);
            SymbolInterpreter = new SymbolInterpreter(ExpressionReader, DebuggerState, SceneViewModel);
            VisualizerService = new WatchVisualizerService(SceneViewModel);
        }

        ThePane CreateToolWindow() =>
            new ThePane
            {
                Caption = "Watch 3D",
                Content = new ToolWindow.TheToolWindowControl(SceneViewModel, SymbolInterpreter)
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
        }
    }
}
