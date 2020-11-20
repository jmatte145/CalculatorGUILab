using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorGUILab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Global Variables // 
        double currentNumber = 0;
        double lastNumber = 0;
        double result = 0;
        String number = "";
        SelectedOperator selectedOperator;

        enum SelectedOperator
        {
            DivisionOperator,
            MultiplyOperator,
            SubtractOperator,
            AdditionOperator
        }

        public MainWindow()
        {
            InitializeComponent();

            AC.Click += new RoutedEventHandler(AC_Click);
            PlusMinus.Click += new RoutedEventHandler(PlusMinus_Click);
            Decimal.Click += new RoutedEventHandler(Decimal_Click);
            Percentage.Click += new RoutedEventHandler(Percentage_Click);

        }

        // Method to detect which number is being pressed and add it to lastNumber // 
        private void Numbers_Click(object sender, RoutedEventArgs e)
        {
            Button n = (Button)sender;

            number += n.Content;
            Double.TryParse(number, out currentNumber);

            WindowLabel.Content = currentNumber;
        }

        private void Operators_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Content)
            {
                case "/":
                    selectedOperator = SelectedOperator.DivisionOperator;
                    break;
                case "*":
                    selectedOperator = SelectedOperator.MultiplyOperator;
                    break;
                case "-":
                    selectedOperator = SelectedOperator.SubtractOperator;
                    break;
                case "+":
                    selectedOperator = SelectedOperator.AdditionOperator;
                    break;
            }
            lastNumber = currentNumber;
            currentNumber = 0;
            number = "";
            WindowLabel.Content = "";
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            switch (selectedOperator)
            {
                case SelectedOperator.DivisionOperator:
                    result = MathService.Division(lastNumber, currentNumber);
                    WindowLabel.Content = result;
                    break;
                case SelectedOperator.MultiplyOperator:
                    result = MathService.Multiplication(lastNumber, currentNumber);
                    WindowLabel.Content = result;
                    break;
                case SelectedOperator.SubtractOperator:
                    result = MathService.Subtraction(lastNumber, currentNumber);
                    WindowLabel.Content = result;
                    break;
                case SelectedOperator.AdditionOperator:
                    result = MathService.Addition(lastNumber, currentNumber);
                    WindowLabel.Content = result;
                    break;
                default:
                    WindowLabel.Content = currentNumber;
                    break;
            }
        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            // Clears all global variables as well as calculator display // 
            currentNumber = 0;
            lastNumber = 0;
            result = 0;
            number = "";

            WindowLabel.Content = "";
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e) // Finish Debugging - Justin. M
        {
            currentNumber = currentNumber * -1;

            WindowLabel.Content = currentNumber;
        }

      

        private void Percentage_Click(object sender, RoutedEventArgs e)
        {
            if(lastNumber != 0)
            {
                currentNumber = currentNumber / 100;
                currentNumber = currentNumber * lastNumber;
            }
            else
            {
                currentNumber = currentNumber / 100;
            }

            WindowLabel.Content = currentNumber;
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!(number.Contains("."))){
                number = currentNumber + ".";
            }
            WindowLabel.Content = number;
        }
    }
}
