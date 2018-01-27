using System;
using Watch3D.Core.Model;
using Watch3D.Core.ViewModel;

namespace Watch3D.Core.Debugger
{
    public class DebuggeeSymbolInterpreter : SymbolInterpreter
    {
        public Logger Logger { get; }
        public ExpressionEvaluator ExpressionEvaluator { get; }
        public SceneItemDeserializer SceneItemDeserializer { get; }

        public DebuggeeSymbolInterpreter(
            Logger logger,
            ExpressionEvaluator expressionEvaluator,
            SceneItemDeserializer sceneItemDeserializer)
        {
            Logger = logger;
            ExpressionEvaluator = expressionEvaluator;
            SceneItemDeserializer = sceneItemDeserializer;
        }

        public SceneItemViewModel TryInterpretSymbol(string symbol)
        {
            try
            {
                return InterpretSymbol(symbol);
            }
            catch (Exception exception)
            when (exception is FormatException
               || exception is OverflowException
               || exception is EvaluationFailedException)
            {
                Logger.Error($"Failed to interpret symbol: '{symbol}'.\nError details: '{exception}'.");
                return null;
            }
        }

        SceneItemViewModel InterpretSymbol(string symbol)
        {
            var expression = $"DebuggerInterop.EvaluateObject({symbol})";
            var evaluationResult = ExpressionEvaluator.EvaluateExpressionWithStringReturnType(expression);
            return SceneItemDeserializer.Deserialize(symbol, evaluationResult);
        }
    }
}