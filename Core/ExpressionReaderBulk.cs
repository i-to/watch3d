using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Watch3D.Core
{
    public class ExpressionReader
    {
        readonly ExpressionFactory ExpressionFactory;
        readonly DebugContext DebugContext;

        public ExpressionReader(
            ExpressionFactory expressionFactory,
            DebugContext debugContext)
        {
            ExpressionFactory = expressionFactory;
            DebugContext = debugContext;
        }

        public MeshGeometry3D TryReadMesh(string meshSymbol)
        {
            try
            {
                return ReadMesh(meshSymbol);
            }
            catch (Exception exception) when(exception is FormatException || exception is OverflowException)
            {
                return null;
            }
        }

        MeshGeometry3D ReadMesh(string meshSymbol) =>
            new MeshGeometry3D
            {
                Positions = ReadVertices(meshSymbol),
                TriangleIndices = ReadTriangles(meshSymbol)
            };

        Point3DCollection ReadVertices(string meshSymbol)
        {
            var expression = ExpressionFactory.CreateMeshVerticesExpression(meshSymbol);
            var result = DebugContext.EvaluateExpression(expression);
            return result.Substring(1, result.Length - 2).ParsePoint3DCollection();
        }

        Int32Collection ReadTriangles(string meshSymbol)
        {
            var expression = ExpressionFactory.CreateMeshIndicesExpression(meshSymbol);
            var str = DebugContext.EvaluateExpression(expression);
            return str.Substring(1, str.Length - 2).ParseInt32Collection();
        }
    }
}