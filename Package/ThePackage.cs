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
using Watch3D.VisualizerServices;

namespace Watch3D.Package
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid("8dc410ba-6829-453f-9c37-403af79451fe")]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(TheToolWindowPane))]
    [ProvideService(typeof(VisualizerService))]
    public class ThePackage : Microsoft.VisualStudio.Shell.Package
    {
        readonly Guid CommandSet = new Guid("a174ef4e-4aae-4efe-8b6f-8bd386c2fd6a");
        readonly int ShowToolWindowCommandId = 0x0100;

        MenuCommands MenuCommands;
        ExpressionReader ExpressionReader;
        DebuggerState DebuggerState;
        SceneViewModel SceneViewModel;
        VisualizerService VisualizerService;

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
            MenuCommands = new MenuCommands(commandService);
            MenuCommands.RegisterCommand(CommandSet, ShowToolWindowCommandId, ShowToolWindow);
            var dte = this.GetService<DTE2, DTE>();
            var debugger = (Debugger5) dte.Debugger;
            var debugContext = new DteDebugContext(debugger);
            var expressionFactory = new TestDebuggeeExpressionFactory();
            ExpressionReader = new ExpressionReader(expressionFactory, debugContext);
            DebuggerState = new DteDebuggerState(debugger);
            var sceneItems = new ObservableCollectionWithReplace<SceneItemViewModel>();
            var sceneItemCollectionAdapter = new SceneItemCollectionAdapter(sceneItems);
            SceneViewModel = new SceneViewModel(sceneItems, sceneItemCollectionAdapter);
            VisualizerService = new WatchVisualizerService(SceneViewModel);
        }

        TheToolWindowPane CreateToolWindow() =>
            new TheToolWindowPane
            {
                Caption = "Watch 3D",
                Content = new TheToolWindowControl(SceneViewModel, ExpressionReader, DebuggerState)
            };

        protected override WindowPane InstantiateToolWindow(Type toolWindowType) =>
            toolWindowType == typeof(TheToolWindowPane)
                ? CreateToolWindow()
                : base.InstantiateToolWindow(toolWindowType);

        void ShowToolWindow()
        {
            var window = FindToolWindow(typeof(TheToolWindowPane), 0, true);
            var windowFrame = (IVsWindowFrame) window.Frame;
            windowFrame.Show();
        }
    }
}
