using System.Windows;

namespace Joan.Presentation
{
    public class ClosableWindow:Window
    {
        public ClosableWindow()
        {
            this.DataContextChanged += ClosableWindow_DataContextChanged;
        }

        private void ClosableWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is IRequestViewClose)
            {
                ((IRequestViewClose) e.NewValue).RequestViewClose += (o, args) => this.Close();
            }
        }
    }
}
