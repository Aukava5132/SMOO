using System.Windows;
using System.Windows.Controls;

namespace Lab4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TaskButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            
            switch (clickedButton.Name)
            {
                case "task1Button":
                    Task1Window task1 = new Task1Window();
                    task1.Show();
                    break;
                case "task2Button":
                    Task2Window task2 = new Task2Window();
                    task2.Show();
                    break;
                case "task3Button":
                    Task3Window task3 = new Task3Window();
                    task3.Show();
                    break;
                case "task4Button":
                    Task4Window task4 = new Task4Window();
                    task4.Show();
                    break;
                case "task5Button":
                    Task5Window task5 = new Task5Window();
                    task5.Show();
                    break;
                case "task6Button":
                    Task6Window task6 = new Task6Window();
                    task6.Show();
                    break;
            }
        }
    }
}