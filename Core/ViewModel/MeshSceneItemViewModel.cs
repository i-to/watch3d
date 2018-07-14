using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Watch3D.Core.Scene;
using Watch3D.Core.Utility;

namespace Watch3D.Core.ViewModel
{
    public class MeshSceneItemViewModel : SceneItemViewModel
    {
        public MeshSceneItemViewModel(MeshSceneItem model)
            : base(model)
        {
        }

        new MeshSceneItem Model => base.Model.Cast<MeshSceneItem>();

        MeshGeometry3D Mesh => Model.Mesh;
        public int VertexCount => Mesh.Positions.Count;
        public int TriangleCount => Mesh.TriangleIndices.Count / 3;

        public Color FrontSurfaceColor
        {
            get => Model.FrontSurfaceColor;
            set
            {
                Model.FrontSurfaceColor = value;
                RaiseFrontSurfaceColorChanged();
            }
        }
        public event EventHandler FrontSurfaceColorChanged;
        void RaiseFrontSurfaceColorChanged() => FrontSurfaceColorChanged?.Invoke(this, EventArgs.Empty);

        public Color BackSurfaceColor
        {
            get => Model.BackSurfaceColor;
            set
            {
                Model.BackSurfaceColor = value;
                RaiseBackSurfaceColorChanged();
            }
        }
        public event EventHandler BackSurfaceColorChanged;
        void RaiseBackSurfaceColorChanged() => BackSurfaceColorChanged?.Invoke(this, EventArgs.Empty);
    }
}