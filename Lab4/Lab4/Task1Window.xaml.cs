using System.Windows;

namespace Lab4
{
    public partial class Task1Window : Window
    {
        public Task1Window()
        {
            InitializeComponent();
        }

        private void HelloButton_Click(object sender, RoutedEventArgs e)
        {
            statusLabel.Content = "Привіт";
        }

        private void GoodbyeButton_Click(object sender, RoutedEventArgs e)
        {
            statusLabel.Content = "До побачення";
        }
    }
}