using System;
using System.Windows.Media.Media3D;
using Watch3D.Core.Model;
using Watch3D.Core.ViewModel;

namespace Watch3D.Core.Debugger
{
    public class ExpressionInterpreter
    {
        readonly Logger Logger;
        readonly ExpressionEvaluator ExpressionEvaluator;
        readonly SceneItemFactory SceneItemFactory;
        readonly InteropParser Parser;

        public ExpressionInterpreter(
            Logger logger,
            ExpressionEvaluator expressionEvaluator,
            SceneItemFactory sceneItemFactory,
            InteropParser parser)
        {
            ExpressionEvaluator = expressionEvaluator;
            SceneItemFactory = sceneItemFactory;
            Parser = parser;
            Logger = logger;
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
            var tokens = evaluationResult.Split('|');
            if (tokens.Length < 2)
                throw new FormatException(
                    "Expected object in the following format: '<type>|<object data>|<optional data>|...'");
            var objectType = tokens[0];
            switch (objectType)
            {
                case "mesh":
                    if (tokens.Length < 3)
                        throw new FormatException("Expected object in the following format: 'mesh|<vertex data>|<triangles data>'");
                    var mesh = new MeshGeometry3D
                    {
                        Positions = Parser.ParsePoint3DCollection(tokens[1]),
                        TriangleIndices = Parser.ParseInt32Collection(tokens[2])
                    };
                    return SceneItemFactory.CreateMesh(symbol, mesh);
                case "polyline":
                    var polyline = Parser.ParsePoint3DCollection(tokens[1]);
                    return SceneItemFactory.CreatePolyline(symbol, polyline);
                case "point":
                    var point = Parser.ParsePoint3D(tokens[1]);
                    return SceneItemFactory.CreatePoint(symbol, point);
            }
            throw new EvaluationFailedException($"Unknown object type: {objectType}");
        }
    }
}