using System.Windows;

namespace Lab4
{
    public partial class Task3Window : Window
    {
        public Task3Window()
        {
            InitializeComponent();
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Visibility = Visibility.Collapsed;
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Visibility = Visibility.Visible;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = "";
        }
    }
}