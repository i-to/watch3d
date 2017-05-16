using System.Windows.Media.Media3D;

namespace Watch3D.Core
{
    public class SceneItemVisual : ModelVisual3D
    {
        public string SceneItemName { get; set; }

        public override string ToString() => SceneItemName;
    }
}