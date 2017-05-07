using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using EnvDTE;
using EnvDTE100;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Watch3D.Core;

namespace Watch3D.Package
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(ThePackage.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(TheToolWindowPane))]
    public class ThePackage : Microsoft.VisualStudio.Shell.Package
    {
        public const string PackageGuidString = "8dc410ba-6829-453f-9c37-403af79451fe";

        readonly Guid CommandSet = new Guid("a174ef4e-4aae-4efe-8b6f-8bd386c2fd6a");
        readonly int ShowToolWindowCommandId = 0x0100;

        MenuCommands MenuCommands;
        ExpressionReader ExpressionReader;
        DebuggerState DebuggerState;
        Scene Scene;

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
            Scene = new Scene(ExpressionReader, DebuggerState);
        }

        TheToolWindowPane CreateToolWindow()
        {
            var pane = new TheToolWindowPane {Caption = "Watch 3D"};
            var dte = this.GetService<DTE2, DTE>();
            pane.Content = new TheToolWindowControl(Scene);
            return pane;
        }

        protected override WindowPane InstantiateToolWindow(Type toolWindowType)
        {
            if (toolWindowType == typeof(TheToolWindowPane))
                return CreateToolWindow();
            return base.InstantiateToolWindow(toolWindowType);
        }

        void ShowToolWindow()
        {
            var window = FindToolWindow(typeof(TheToolWindowPane), 0, true);
            var windowFrame = (IVsWindowFrame) window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }
    }
}
