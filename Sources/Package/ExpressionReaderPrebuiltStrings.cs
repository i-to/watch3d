using System.Windows.Media;
using System.Windows.Media.Media3D;
using EnvDTE100;

namespace Watch3D.Package
{
    public class ExpressionReaderPrebuiltStrings : ExpressionReader
    {
        readonly Debugger5 Debugger;

        public ExpressionReaderPrebuiltStrings(Debugger5 debugger)
        {
            Debugger = debugger;
        }

        public MeshGeometry3D TryReadMesh(string meshSymbol) =>
            ReadMesh(meshSymbol);

        MeshGeometry3D ReadMesh(string meshSymbol) =>
            new MeshGeometry3D
            {
                Positions = ReadVertices(meshSymbol),
                TriangleIndices = ReadTriangles(meshSymbol)
            };

        Point3DCollection ReadVertices(string meshSymbol)
        {
            var str = Debugger.GetExpression($"MeshStringBuilder.GetVerticesString({meshSymbol})").Value;
            return str.Substring(1, str.Length - 2).ParsePoint3DCollection();
        }

        Int32Collection ReadTriangles(string meshSymbol)
        {
            var str = Debugger.GetExpression($"MeshStringBuilder.GetIndicesString({meshSymbol})").Value;
            return str.Substring(1, str.Length - 2).ParseInt32Collection();
        }
    }
}