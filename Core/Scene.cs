using System;
using System.Windows.Media.Media3D;

namespace Watch3D.Core
{
    public class Scene
    {
        MeshGeometry3D MeshField;
        public MeshGeometry3D Mesh
        {
            get { return MeshField; }
            set { MeshField = value; OnMeshChanged(); }
        }

        public event EventHandler MeshChanged;
        void OnMeshChanged() => MeshChanged?.Invoke(this, EventArgs.Empty);
    }
}