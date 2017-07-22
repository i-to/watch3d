using System;
using System.Windows.Media;
using Watch3D.Core.Model;
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

        public Color FrontSurfaceColor
        {
            get { return Model.FrontSurfaceColor; }
            set
            {
                RaiseFrontSurfaceColorChanged();
                Model.FrontSurfaceColor = value;
            }
        }
        public event EventHandler FrontSurfaceColorChanged;
        void RaiseFrontSurfaceColorChanged() => FrontSurfaceColorChanged?.Invoke(this, EventArgs.Empty);

        public Color BackSurfaceColor
        {
            get { return Model.BackSurfaceColor; }
            set
            {
                RaiseBackSurfaceColorChanged();
                Model.BackSurfaceColor = value;
            }
        }
        public event EventHandler BackSurfaceColorChanged;
        void RaiseBackSurfaceColorChanged() => BackSurfaceColorChanged?.Invoke(this, EventArgs.Empty);
    }
}