﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Watch3D.Core.Utility;

namespace Watch3D.Package.ToolWindow
{
    static class ListBoxExtensions
    {
        public static IReadOnlyList<int> GetSelectedItemIndices(this ListBox listBox) =>
            listBox
                .SelectedItems
                .Cast<object>()
                .Select(o => listBox.Items.IndexOf(o))
                .ToArray();

        public static ListBoxItem GetFocusedItemContainer(this ListBox listBox) =>
            listBox
                .Items
                .Cast<object>()
                .Select(obj => (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromItem(obj))
                .FirstOrDefault(item => item.IsFocused);

        public static void ResetSelection(this ListBox listBox, IReadOnlyList<int> selectedIndices)
        {
            listBox.SelectedItems.Clear();
            selectedIndices
                .Select(index => listBox.Items[index])
                .ForEach(item => listBox.SelectedItems.Add(item));
        }
    }
}