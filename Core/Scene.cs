using System.Windows.Media.Media3D;

namespace Watch3D.Core
{
    public interface Scene
    {
        void AddMesh(MeshGeometry3D mesh);
    }
}