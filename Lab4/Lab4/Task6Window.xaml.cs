using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab4
{
    public partial class Task6Window : Window
    {
        private readonly string[] colors = {
            "Red", "Blue", "Green", "Yellow", "Purple",
            "Orange", "Pink", "Brown", "Gray", "Cyan",
            "Magenta", "Lime"
        };

        public Task6Window()
        {
            InitializeComponent();
            CreateColorButtons();
        }

        private void CreateColorButtons()
        {
            foreach (string colorName in colors)
            {
                Button button = new Button
                {
                    Content = colorName,
                    Margin = new Thickness(2),
                    Height = 40,
                    Background = (SolidColorBrush)new BrushConverter().ConvertFromString(colorName),
                    Foreground = Brushes.White,
                    FontWeight = FontWeights.Bold
                };

                button.Click += ColorButton_Click;
                buttonsPanel.Children.Add(button);
            }
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string colorName = clickedButton.Content.ToString();
            
            infoTextBlock.Text = $"Вибрано колір: {colorName}";
            
            MessageBox.Show($"Колір: {colorName}", "Інформація про колір");
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double buttonWidth = (ActualWidth * 2 / 3) / 3 - 6; 
            
            foreach (Button button in buttonsPanel.Children)
            {
                button.Width = buttonWidth;
            }
        }
    }
}