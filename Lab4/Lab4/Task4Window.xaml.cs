using System.Windows;
using System.Windows.Controls;

namespace Lab4
{
    public partial class Task4Window : Window
    {
        public Task4Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            
            if (clickedButton.Visibility == Visibility.Visible)
            {
                clickedButton.Visibility = Visibility.Hidden;
            }
            else
            {
                clickedButton.Visibility = Visibility.Visible;
            }
            

            CheckGameStatus();
        }

        private void CheckGameStatus()
        {
            Button[] buttons = { button1, button2, button3, button4, button5 };
    
            int visibleCount = buttons.Count(b => b.Visibility == Visibility.Visible);
    
            if (visibleCount == 0)
            {
                gameStatus.Content = "Ти переміг!";
                gameStatus.Foreground = System.Windows.Media.Brushes.Green;
            }
            else
            {
                gameStatus.Content = $"Залишилось сховати кнопок: {visibleCount}";
                gameStatus.Foreground = System.Windows.Media.Brushes.Black;
            }
        }
    }
}