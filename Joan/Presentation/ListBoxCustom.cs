using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Joan.Presentation
{
    public class ListBoxCustom : ListBox
    {
        public ListBoxCustom()
        {
            SelectionChanged += (s, e) => SelectedItemsList = SelectedItems;
        }

        public IList SelectedItemsList
        {
            get => (IList) GetValue(SelectedItemsListProperty);
            set => SetValue(SelectedItemsListProperty, value);
        }

        public static readonly DependencyProperty SelectedItemsListProperty =
            DependencyProperty.Register("SelectedItemsList", typeof(IList), typeof(ListBoxCustom),
                new PropertyMetadata(null));

    }
}
