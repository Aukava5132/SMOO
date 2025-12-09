using System;
using System.Windows;

namespace Lab4
{
    public partial class Task5Window : Window
    {
        public Task5Window()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(poundsTextBox.Text))
                {
                    kilogramsTextBox.Text = "";
                    return;
                }

                if (double.TryParse(poundsTextBox.Text, out double pounds))
                {
                    double kilograms = pounds * 0.453592;
                    kilogramsTextBox.Text = kilograms.ToString("F2");
                }
                else
                {
                    kilogramsTextBox.Text = "Помилка";
                    MessageBox.Show("Введіть коректне число", "Помилка", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}