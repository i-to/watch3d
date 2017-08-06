using EnvDTE100;
using Watch3D.Core.Debugger;

namespace Watch3D.Package.Debugger
{
    public class DteDebugContext : DebugContext
    {
        public readonly Debugger5 Debugger;

        public DteDebugContext(Debugger5 debugger)
        {
            Debugger = debugger;
        }

        public EvaluatedExpression EvaluateExpression(string expression)
        {
            var result = Debugger.GetExpression(expression, false);
            if (!result.IsValidValue)
                throw new EvaluationFailedException($"Evaluation result: '{result.Value}'");
            return new EvaluatedExpression(result.Value, result.Type);
        }
    }
}