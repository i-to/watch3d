using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using EnvDTE100;

namespace Watch3D.Package
{
    public class ExpressionReaderDirect : ExpressionReader
    {
        readonly Debugger5 Debugger;

        public ExpressionReaderDirect(Debugger5 debugger)
        {
            Debugger = debugger;
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
            var triangleCount = Debugger.GetExpression(trianglesSymbol + ".Count").Value.ParseInt32();
            var indices = new Int32Collection(triangleCount * 3);
            for (int i = 0; i != triangleCount; ++i)
                AddTriangle(indices, $"{trianglesSymbol}[{i}]");
            return indices;
        }

        void AddTriangle(Int32Collection indices, string triangleSymbol)
        {
            indices.Add(Debugger.GetExpression(triangleSymbol + ".A").Value.ParseInt32());
            indices.Add(Debugger.GetExpression(triangleSymbol + ".B").Value.ParseInt32());
            indices.Add(Debugger.GetExpression(triangleSymbol + ".C").Value.ParseInt32());
        }

        Point3DCollection ReadPoints(string verticesSymbol)
        {
            var vertexCount = Debugger.GetExpression(verticesSymbol + ".Count").Value.ParseInt32();
            var points = new Point3DCollection(vertexCount);
            for (int i = 0; i != vertexCount; ++i)
                points.Add(ReadPoint($"{verticesSymbol}[{i}]"));
            return points;
        }

        Point3D ReadPoint(string vertexSymbol) =>
            new Point3D
            {
                X = Debugger.GetExpression(vertexSymbol + ".X").Value.ParseDouble(),
                Y = Debugger.GetExpression(vertexSymbol + ".Y").Value.ParseDouble(),
                Z = Debugger.GetExpression(vertexSymbol + ".Z").Value.ParseDouble()
            };
    }
}