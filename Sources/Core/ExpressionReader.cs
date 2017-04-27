using System.Windows.Media.Media3D;

namespace Watch3D.Core
{
    public interface ExpressionReader
    {
        MeshGeometry3D TryReadMesh(string meshSymbol);
    }
}
