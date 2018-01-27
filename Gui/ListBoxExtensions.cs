using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Watch3D.Core.Utility;

namespace Watch3D.Gui
{
    static class ListBoxExtensions
    {
        public static IReadOnlyList<int> GetSelectedItemIndices(this ListBox listBox) =>
            listBox
                .SelectedItems
                .Cast<object>()
                .Select(o => listBox.Items.IndexOf(o))
                .ToArray();

        public static IEnumerable<ListBoxItem> GetItemContainers(this ListBox listBox) =>
            listBox
                .Items
                .Cast<object>()
                .Select(obj => (ListBoxItem) listBox.ItemContainerGenerator.ContainerFromItem(obj));

        public static ListBoxItem GetFocusedItemContainer(this ListBox listBox) =>
            listBox
                .GetItemContainers()
                .FirstOrDefault(item => item.IsFocused);

        public static int GetFocusedItemIndex(this ListBox listBox) =>
            listBox
                .GetItemContainers()
                .Select(Tuple.Create<ListBoxItem, int>)
                .First(tuple => tuple.Item1.IsFocused)
                .Item2;

        public static void ResetSelection(this ListBox listBox, IReadOnlyList<int> selectedIndices)
        {
            listBox.SelectedItems.Clear();
            selectedIndices
                .Select(index => listBox.Items[index])
                .ForEach(item => listBox.SelectedItems.Add(item));
        }
    }
}
