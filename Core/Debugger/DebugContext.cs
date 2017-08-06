using System;

namespace Watch3D.Core.Debugger
{
    public class EvaluationFailedException : Exception
    {
        public EvaluationFailedException(string message)
            : base(message)
        {
        }
    }

    public class EvaluatedExpression
    {
        public readonly string Value;
        public readonly string Type;

        public EvaluatedExpression(string value, string type)
        {
            Value = value;
            Type = type;
        }
    }

    public interface DebugContext
    {
        EvaluatedExpression EvaluateExpression(string expression);
    }
}