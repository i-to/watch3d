using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Watch3D.Gui
{
    public partial class EditableTextBox : UserControl
    {
        enum Mode { Display, Edit }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditableTextBox), new UIPropertyMetadata());

        Mode CurrentMode = Mode.Display;
        string StashBeforeEditing;

        public EditableTextBox()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public void StartEditing() => SwitchMode(Mode.Edit);

        public void FinishEditing() => SwitchMode(Mode.Display);

        public void AbortEditing()
        {
            Text = StashBeforeEditing;
            FinishEditing();
        }

        void SwitchMode(Mode mode)
        {
            if (CurrentMode == mode)
                return;
            CurrentMode = mode;
            UpdateControls(mode);
            if (mode == Mode.Display)
            {
                StashBeforeEditing = null;
            }
            else
            {
                StashBeforeEditing = Text;
                Dispatcher.BeginInvoke((Action)(() => Keyboard.Focus(EditControl)), DispatcherPriority.Render);
            }
        }

        void UpdateControls(Mode mode)
        {
            if (mode == Mode.Edit)
            {
                DisplayControl.Visibility = Visibility.Collapsed;
                EditControl.Visibility = Visibility.Visible;
            }
            else
            {
                DisplayControl.Visibility = Visibility.Visible;
                EditControl.Visibility = Visibility.Collapsed;
            }
        }

        public static EditableTextBox FindInParent(ListBoxItem listBoxItem)
        {
            DependencyObject item = listBoxItem;
            while (item != null && VisualTreeHelper.GetChildrenCount(item) == 1)
            {
                var result = item as EditableTextBox;
                if (result != null)
                    return result;
                item = VisualTreeHelper.GetChild(item, 0);
            }
            return null;
        }

        void ExecuteStartEditing(object sender, ExecutedRoutedEventArgs e) => StartEditing();
        void TextBoxLostFocus(object sender, RoutedEventArgs e) => FinishEditing();
        void ExecuteStop(object sender, ExecutedRoutedEventArgs e) => AbortEditing();

        void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                FinishEditing();
        }
    }
}
