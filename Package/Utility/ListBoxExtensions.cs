using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Watch3D.Package.Utility
{
    static class ListBoxExtensions
    {
        public static IReadOnlyList<int> GetSelectedItemIndices(this ListBox listBox) =>
            listBox
                .SelectedItems
                .Cast<object>()
                .Select(o => listBox.Items.IndexOf(o))
                .ToArray();

        public static void ResetSelection(this ListBox listBox, IReadOnlyList<int> selectedIndices)
        {
            listBox.SelectedItems.Clear();
            selectedIndices
                .Select(index => listBox.Items[index])
                .ForEach(item => listBox.SelectedItems.Add(item));
        }
    }
}
