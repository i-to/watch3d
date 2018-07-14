using Watch3D.Core.Utility;

namespace Watch3D.Core.ViewModel
{
    public class SceneViewModel
    {
        public ObservableCollectionWithReplace<SceneItemViewModel> SceneItems { get; }
        public SceneItemCollectionAdapter SceneItemsViewportAdapter { get; }

        public SceneViewModel(
            ObservableCollectionWithReplace<SceneItemViewModel> sceneItems,
            SceneItemCollectionAdapter sceneItemsViewportAdapter)
        {
            SceneItems = sceneItems;
            SceneItemsViewportAdapter = sceneItemsViewportAdapter;
        }

        public void AddItem(SceneItemViewModel item) =>
            SceneItems.Add(item);

        public SceneItemViewModel GetItem(int index) =>
            SceneItems[index];
    }
}