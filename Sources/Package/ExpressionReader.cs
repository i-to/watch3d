using System.Windows.Media.Media3D;

namespace Watch3D.Package
{
    public interface ExpressionReader
    {
        MeshGeometry3D TryReadMesh(string meshSymbol);
    }
}
