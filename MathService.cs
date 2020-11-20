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
    public static class MathService
    {
        public static double Division(double num1, double num2)
        {
            double result = 0;
            if(num2 != 0)
            {
                result = num1 / num2;
            }
            else
            {
                MessageBox.Show("Divide by Zero Error. Resetting all variables.");
                result = 0;
            }
            return result;
        }
        public static double Multiplication(double num1, double num2)
        {
            double result = 0;
            result = num1 * num2;
            return result;
        }
        public static double Subtraction(double num1, double num2)
        {
            double result = 0;
            result = num1 - num2;
            return result;
        }

        public static double Addition(double num1, double num2)
        {
            double result = 0;
            result = num1 + num2;
            return result;
        }
    }
}
