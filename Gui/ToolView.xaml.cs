using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Watch3D.Core.ViewModel;

namespace Watch3D.Gui
{
    public partial class ToolView : UserControl
    {
        public ToolViewModel ViewModel { get; }

        public ToolView(ToolViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            ViewModel.InitializeScene();
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

        void ExecuteExportItem(object sender, ExecutedRoutedEventArgs e)
        {
            var index = e.GetSource<ListBox>().GetFocusedItemIndex();
            ViewModel.ExportItem(index);
        }

        void ExecuteExportItemAsSTL(object sender, ExecutedRoutedEventArgs e)
        {
            var index = e.GetSource<ListBox>().GetFocusedItemIndex();
            ViewModel.ExportItemAsSTL(index);
        }

        void ExecuteTextCommand(object sender, RoutedEventArgs e) =>
            ViewModel.ExecuteTextCommand(CommandText.Text);

        void ExecuteAddPoint(object sender, ExecutedRoutedEventArgs e) => 
            ViewModel.ExecuteAddPoint();

        void CanExecuteAddPoint(object sender, CanExecuteRoutedEventArgs e) => 
            e.CanExecute = true;
    }
}