using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab5
{
    public partial class CalculatorWindow : Window
    {
        double num1 = 0;
        string op = "";
        bool newNum = true;

        public CalculatorWindow()
        {
            InitializeComponent();
        }

        void Number(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string digit = btn.Content.ToString();
            
            if (display.Text == "0" || newNum)
            {
                display.Text = digit;
                newNum = false;
            }
            else
            {
                display.Text = display.Text + digit;
            }
        }

        void Dot(object sender, RoutedEventArgs e)
        {
            if (display.Text.Contains(".") == false)
                display.Text = display.Text + ".";
        }

        void Operation(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            op = btn.Content.ToString();
            num1 = GetNumber(display.Text);
            newNum = true;
        }

        void Equals(object sender, RoutedEventArgs e)
        {
            if (op != "")
            {
                double num2 = GetNumber(display.Text);
                double result = 0;
                
                if (op == "+") result = num1 + num2;
                if (op == "-") result = num1 - num2;
                if (op == "×") result = num1 * num2;
                if (op == "/")
                {
                    if (num2 != 0) 
                        result = num1 / num2;
                    else
                        MessageBox.Show("На 0 ділити е можна");
                }
                
                display.Text = result.ToString();
                op = "";
                newNum = true;
            }
        }

        void Clear(object sender, RoutedEventArgs e)
        {
            display.Text = "0";
            num1 = 0;
            op = "";
            newNum = true;
        }

        void ClearEntry(object sender, RoutedEventArgs e)
        {
            display.Text = "0";
            newNum = true;
        }

        void Backspace(object sender, RoutedEventArgs e)
        {
            if (display.Text.Length > 1)
                display.Text = display.Text.Remove(display.Text.Length - 1);
            else
                display.Text = "0";
        }

        void ChangeSign(object sender, RoutedEventArgs e)
        {
            if (display.Text != "0")
            {
                double value = GetNumber(display.Text);
                display.Text = (-value).ToString();
            }
        }

        double GetNumber(string text)
        {
            if (double.TryParse(text, out double result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}