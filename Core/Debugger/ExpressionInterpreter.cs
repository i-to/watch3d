using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Watch3D.Core.Utility;
using Watch3D.Core.ViewModel;

namespace Watch3D.Core.Debugger
{
    public class ExpressionInterpreter
    {
        readonly DebuggeeSymbols DebuggeeSymbols;
        readonly ExpressionEvaluator ExpressionEvaluator;
        readonly SceneItemFactory SceneItemFactory;

        public ExpressionInterpreter(
            DebuggeeSymbols debuggeeSymbols,
            ExpressionEvaluator expressionEvaluator,
            SceneItemFactory sceneItemFactory)
        {
            DebuggeeSymbols = debuggeeSymbols;
            ExpressionEvaluator = expressionEvaluator;
            SceneItemFactory = sceneItemFactory;
        }

        public SceneItemViewModel TryInterpretSymbol(string symbol)
        {
            try
            {
                var type = ExpressionEvaluator.EvaluateSymbolType(symbol);
                var objectType = DebuggeeSymbols.MapObjectType(type);
                switch (objectType)
                {
                    case DebuggeeObjectType.Mesh:
                        var mesh = ReadMesh(symbol);
                        return SceneItemFactory.CreateMesh(mesh);
                    case DebuggeeObjectType.Polyline:
                        var polyline = ReadPolyline(symbol);
                        return SceneItemFactory.CreatePolyline(polyline);
                    case DebuggeeObjectType.Point:
                        var point = ReadPoint(symbol);
                        return SceneItemFactory.CreatePoint(point);
                }
                throw new EvaluationFailedException($"Unknown object type: {objectType}");
            }
            catch (Exception exception)
            when (exception is FormatException
               || exception is OverflowException
               || exception is EvaluationFailedException)
            {
                return null;
            }
        }

        Point3D ReadPoint(string symbol)
        {
            var expression = DebuggeeSymbols.CreatePointExpression(symbol);
            var evaluationResult = ExpressionEvaluator.EvaluateExpressionWithStringReturnType(expression);
            return evaluationResult.ParsePoint3D();
        }

        Point3DCollection ReadPolyline(string symbol)
        {
            var expression = DebuggeeSymbols.CreatePolylinePointsExpression(symbol);
            var evaluationResult = ExpressionEvaluator.EvaluateExpressionWithStringReturnType(expression);
            return evaluationResult.ParsePoint3DCollection();
        }

        MeshGeometry3D ReadMesh(string meshSymbol) =>
            new MeshGeometry3D
            {
                Positions = ReadVertices(meshSymbol),
                TriangleIndices = ReadTriangles(meshSymbol)
            };

        Point3DCollection ReadVertices(string meshSymbol)
        {
            var expression = DebuggeeSymbols.CreateMeshVerticesExpression(meshSymbol);
            var evaluationResult = ExpressionEvaluator.EvaluateExpressionWithStringReturnType(expression);
            return evaluationResult.ParsePoint3DCollection();
        }

        Int32Collection ReadTriangles(string meshSymbol)
        {
            var expression = DebuggeeSymbols.CreateMeshIndicesExpression(meshSymbol);
            var evaluationResult = ExpressionEvaluator.EvaluateExpressionWithStringReturnType(expression);
            return evaluationResult.ParseInt32Collection();
        }
    }
}