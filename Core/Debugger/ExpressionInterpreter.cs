using System;
using System.Windows.Media.Media3D;
using Watch3D.Core.Utility;
using Watch3D.Core.ViewModel;

namespace Watch3D.Core.Debugger
{
    public class ExpressionInterpreter
    {
        readonly ExpressionEvaluator ExpressionEvaluator;
        readonly SceneItemFactory SceneItemFactory;
        readonly InteropParser Parser;

        public ExpressionInterpreter(
            ExpressionEvaluator expressionEvaluator,
            SceneItemFactory sceneItemFactory,
            InteropParser parser)
        {
            ExpressionEvaluator = expressionEvaluator;
            SceneItemFactory = sceneItemFactory;
            Parser = parser;
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
                    return ParseMesh(tokens[1], tokens[2]);
                case "polyline":
                    return ParsePolyline(tokens[1]);
                case "point":
                    return ParsePoint(tokens[1]);
            }
            throw new EvaluationFailedException($"Unknown object type: {objectType}");
        }

        MeshSceneItemViewModel ParseMesh(string vertices, string triangles)
        {
            var mesh = new MeshGeometry3D
            {
                Positions = Parser.ParsePoint3DCollection(vertices),
                TriangleIndices = Parser.ParseInt32Collection(triangles)
            };
            var meshSceneItemViewModel = SceneItemFactory.CreateMesh(mesh);
            return meshSceneItemViewModel;
        }

        PolylineSceneItemViewModel ParsePolyline(string data)
        {
            var polyline = Parser.ParsePoint3DCollection(data);
            return SceneItemFactory.CreatePolyline(polyline);
        }

        PointSceneItemViewModel ParsePoint(string data)
        {
            var point = Parser.ParsePoint3D(data);
            return SceneItemFactory.CreatePoint(point);
        }
    }
}