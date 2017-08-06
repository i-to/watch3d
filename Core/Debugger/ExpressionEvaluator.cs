using System.Linq;

namespace Watch3D.Core.Debugger
{
    public class ExpressionEvaluator
    {
        readonly DebugContext DebugContext;

        public ExpressionEvaluator(DebugContext debugContext)
        {
            DebugContext = debugContext;
        }

        /// <summary>
        /// Evaluates expression that yields string and extracts the string value, removing quotes and prefix.
        /// </summary>
        // TODO: use DebugContext to verify evaluated expression type
        public string EvaluateExpressionWithStringReturnType(string expression)
        {
            var evaluationResult = DebugContext.EvaluateExpression(expression);
            return GetEvaluatedStringContent(evaluationResult.Value);
        }

        public string EvaluateSymbolType(string symbol) =>
            DebugContext.EvaluateExpression(symbol).Type;

        string GetEvaluatedStringContent(string evaluatedString)
        {
            if (evaluatedString.Length < 2)
                throw new EvaluationFailedException($"Evaluated string too short: '{evaluatedString}'");
            if (evaluatedString.Last() != '\"')
                throw new EvaluationFailedException($"Expected evaluated string ending with quote: '{evaluatedString}'");
            int skip;
            if (evaluatedString.Length > 2 && evaluatedString[0] == 'L')
            {
                if (evaluatedString[1] != '\"')
                    throw new EvaluationFailedException($"Expected evaluated string beginning with quote: '{evaluatedString}'");
                skip = 2;
            }
            else
            {
                if (evaluatedString[0] != '\"')
                    throw new EvaluationFailedException($"Expected evaluated string beginning with 'L' and quote: '{evaluatedString}'");
                skip = 1;
            }
            return evaluatedString.Substring(skip, evaluatedString.Length - (skip + 1));
        }
    }
}