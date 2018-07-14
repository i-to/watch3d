using HelixToolkit.Wpf;

namespace Watch3D.Core.Scene
{
    public class LightSceneItem : SceneItem
    {
        public LightSceneItem()
            : base("Directional Head Light", new DirectionalHeadLight())
        {
        }
    }
}