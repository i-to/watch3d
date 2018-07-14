using HelixToolkit.Wpf;

namespace Watch3D.Core.Scene
{
    public class GridSceneItem : SceneItem
    {
        public GridSceneItem()
            : base(
                "Grid",
                new GridLinesVisual3D { Width = 8, Length = 8, MinorDistance = 1, Thickness = 0.01 })
        {
        }
    }
}