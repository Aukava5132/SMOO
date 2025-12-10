using System.Windows;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenCalculator(object sender, RoutedEventArgs e)
        {
            new CalculatorWindow().Show();
        }

        private void OpenBestOil(object sender, RoutedEventArgs e)
        {
            new GasStation().Show();
        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}