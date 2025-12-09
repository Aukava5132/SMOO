using System.Windows;

namespace Lab4
{
    public partial class Task2Window : Window
    {
        public Task2Window()
        {
            InitializeComponent();
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            infoTextBlock.Visibility = Visibility.Hidden;
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            infoTextBlock.Visibility = Visibility.Visible;
        }
    }
}