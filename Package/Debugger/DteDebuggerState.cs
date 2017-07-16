using EnvDTE;
using EnvDTE100;
using Watch3D.Core.Debugger;

namespace Watch3D.Package.Debugger
{
    public class DteDebuggerState : DebuggerState
    {
        readonly Debugger5 Debugger;

        public DteDebuggerState(Debugger5 debugger)
        {
            Debugger = debugger;
        }

        public bool IsBreakMode => Debugger.CurrentMode == dbgDebugMode.dbgBreakMode;
    }
}
