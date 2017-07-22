using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Watch3D.Gui
{
    public partial class ToolView : UserControl
    {
        public ToolViewModel ViewModel { get; }

        public ToolView(ToolViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            ViewModel.Scene.InitializeScene();
        }

        void ExecuteDelete(object sender, ExecutedRoutedEventArgs e)
        {
            var indices = e.GetSource<ListBox>().GetSelectedItemIndices();
            ViewModel.DeleteSceneItems(indices);
        }

        void ExecuteToggleShowHide(object sender, ExecutedRoutedEventArgs e)
        {
            var listBox = e.GetSource<ListBox>();
            var indices = listBox.GetSelectedItemIndices();
            ViewModel.ToggleSceneItemsVisibility(indices);
            listBox.ResetSelection(indices);
        }

        void ExecuteStartEditing(object sender, ExecutedRoutedEventArgs e)
        {
            var listBoxItem = e.GetSource<ListBox>().GetFocusedItemContainer();
            EditableTextBox.FindInParent(listBoxItem).StartEditing();
        }

        void SetStatus(string title, string subtitle)
        {
            Viewport.Title = title;
            Viewport.SubTitle = subtitle;
        }

        void AddBySymbolName(object sender, RoutedEventArgs e)
        {
            var status = ViewModel.TryAddItemBySymbolName(MeshSymbol.Text);
            SetStatus(status.Item1, status.Item2);
        }
    }
}