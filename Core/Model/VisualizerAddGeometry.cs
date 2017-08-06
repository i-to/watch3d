using System.Windows.Media.Media3D;

namespace Watch3D.Core.Model
{
    public interface VisualizerAddGeometry
    {
        void AddMesh(MeshGeometry3D mesh);
        void AddPolyline(Point3DCollection points);
        void AddPoint(Point3D point);
    }
}