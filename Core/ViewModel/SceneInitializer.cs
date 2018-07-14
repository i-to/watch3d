namespace Watch3D.Core.ViewModel
{
    public class SceneInitializer
    {
        public readonly SceneItemFactory SceneItemFactory;

        public SceneInitializer(SceneItemFactory sceneItemFactory)
        {
            SceneItemFactory = sceneItemFactory;
        }

        public void InitializeScene(SceneViewModel scene)
        {
            scene.AddItem(SceneItemFactory.CreateLight());
            scene.AddItem(SceneItemFactory.CreateGrid());
        }
    }
}