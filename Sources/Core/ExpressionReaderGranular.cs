using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Watch3D.Core
{
    public class ExpressionReaderGranular : ExpressionReader
    {
        readonly DebugContext DebugContext;

        public ExpressionReaderGranular(DebugContext debugContext)
        {
            DebugContext = debugContext;
        }

        public MeshGeometry3D TryReadMesh(string meshSymbol)
        {
            try
            {
                return ReadMesh(meshSymbol);
            }
            catch (Exception exception) when (exception is FormatException || exception is OverflowException)
            {
                return null;
            }
        }

        MeshGeometry3D ReadMesh(string meshSymbol) =>
            new MeshGeometry3D
            {
                Positions = ReadPoints(meshSymbol + ".Vertices"),
                TriangleIndices = ReadTriangleIndices(meshSymbol + ".Triangles")
            };

        Int32Collection ReadTriangleIndices(string trianglesSymbol)
        {
            var triangleCount = DebugContext.EvaluateExpression(trianglesSymbol + ".Count").ParseInt32();
            var indices = new Int32Collection(triangleCount * 3);
            for (int i = 0; i != triangleCount; ++i)
                AddTriangle(indices, $"{trianglesSymbol}[{i}]");
            return indices;
        }

        void AddTriangle(Int32Collection indices, string triangleSymbol)
        {
            indices.Add(DebugContext.EvaluateExpression(triangleSymbol + ".A").ParseInt32());
            indices.Add(DebugContext.EvaluateExpression(triangleSymbol + ".B").ParseInt32());
            indices.Add(DebugContext.EvaluateExpression(triangleSymbol + ".C").ParseInt32());
        }

        Point3DCollection ReadPoints(string verticesSymbol)
        {
            var vertexCount = DebugContext.EvaluateExpression(verticesSymbol + ".Count").ParseInt32();
            var points = new Point3DCollection(vertexCount);
            for (int i = 0; i != vertexCount; ++i)
                points.Add(ReadPoint($"{verticesSymbol}[{i}]"));
            return points;
        }

        Point3D ReadPoint(string vertexSymbol) =>
            new Point3D
            {
                X = DebugContext.EvaluateExpression(vertexSymbol + ".X").ParseDouble(),
                Y = DebugContext.EvaluateExpression(vertexSymbol + ".Y").ParseDouble(),
                Z = DebugContext.EvaluateExpression(vertexSymbol + ".Z").ParseDouble()
            };
    }
}