using System.Windows;
using System.Windows.Controls;

namespace Lab5
{
    public partial class GasStation : Window
    {
        double fuelPrice = 46.50;
        double fuelAmount = 0;
        double cafeAmount = 0;

        public GasStation()
        {
            InitializeComponent();
            fuelType.SelectionChanged += FuelChanged;
            liters.TextChanged += CalculateAll;
            hotdog.Checked += CafeChanged;
            hotdog.Unchecked += CafeChanged;
            burger.Checked += CafeChanged;
            burger.Unchecked += CafeChanged;
            fries.Checked += CafeChanged;
            fries.Unchecked += CafeChanged;
            hotdogQty.TextChanged += CafeChanged;
            burgerQty.TextChanged += CafeChanged;
            friesQty.TextChanged += CafeChanged;
            
            UpdateAll();
        }

        void FuelChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fuelType.SelectedIndex == 0) fuelPrice = 46.50;
            if (fuelType.SelectedIndex == 1) fuelPrice = 52.30;
            if (fuelType.SelectedIndex == 2) fuelPrice = 48.75;
            
            price.Text = fuelPrice + " грн";
            UpdateAll();
        }

        void CalculateAll(object sender = null, EventArgs e = null)
        {
            UpdateAll();
        }

        void CafeChanged(object sender, RoutedEventArgs e)
        {
            UpdateAll();
        }

        void CafeChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();
        }

        void UpdateAll()
        {
            double litersValue = GetNumber(liters.Text);
            fuelAmount = litersValue * fuelPrice;
            fuelSum.Text = fuelAmount + " грн";
            
            cafeAmount = 0;
            if (hotdog.IsChecked == true) cafeAmount += GetNumber(hotdogQty.Text) * 45;
            if (burger.IsChecked == true) cafeAmount += GetNumber(burgerQty.Text) * 65;
            if (fries.IsChecked == true) cafeAmount += GetNumber(friesQty.Text) * 35;
            cafeSum.Text = cafeAmount + " грн";
            
            double total = fuelAmount + cafeAmount;
            fuelTotal.Text = fuelAmount + " грн";
            cafeTotal.Text = cafeAmount + " грн";
            this.total.Text = total + " грн";
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

        void Calculate(object sender, RoutedEventArgs e)
        {
            double total = fuelAmount + cafeAmount;
            MessageBox.Show("Сплатіть: " + total + " грн");
        }

        void NewOrder(object sender, RoutedEventArgs e)
        {
            liters.Text = "0";
            hotdog.IsChecked = false;
            burger.IsChecked = false;
            fries.IsChecked = false;
            UpdateAll();
        }

        void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}