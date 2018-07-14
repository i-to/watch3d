using Watch3D.Core.Model;
using Watch3D.Core.Utility;
using Watch3D.Core.ViewModel;

namespace Watch3D.Core
{
    public class SceneModule
    {
        public readonly SceneItemDeserializer SceneItemDeserializer;
        public readonly SceneViewModel SceneViewModel;
        public readonly AddSceneItemFromLiteralCommand AddSceneItemFromLiteralCommand;
        public readonly SceneInitializer SceneInitializer;
        public readonly AddGeometryToScene AddGeometryToScene;

        public SceneModule(Logger logger)
        {
            var sceneItems = new ObservableCollectionWithReplace<SceneItemViewModel>();
            var sceneItemCollectionAdapter = new SceneItemCollectionAdapter(sceneItems);
            var sceneItemsFactory = new SceneItemFactory();
            SceneViewModel = new SceneViewModel(sceneItems, sceneItemCollectionAdapter);
            var interopParser = new InteropParser();
            SceneItemDeserializer = new SceneItemDeserializer(interopParser, sceneItemsFactory);
            AddSceneItemFromLiteralCommand = new AddSceneItemFromLiteralCommand(logger, 
                SceneViewModel, SceneItemDeserializer);
            SceneInitializer = new SceneInitializer(sceneItemsFactory);
            AddGeometryToScene = new AddGeometryToScene(SceneViewModel, sceneItemsFactory);
        }
    }
}