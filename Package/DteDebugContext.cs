using EnvDTE100;
using Watch3D.Core;
using Watch3D.Core.Debugger;

namespace Watch3D.Package
{
    public class DteDebugContext : DebugContext
    {
        public readonly Debugger5 Debugger;

        public DteDebugContext(Debugger5 debugger)
        {
            Debugger = debugger;
        }

        public string EvaluateExpression(string expression) => 
            Debugger.GetExpression(expression).Value;
    }
}