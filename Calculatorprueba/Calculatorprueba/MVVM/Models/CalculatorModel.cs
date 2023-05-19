using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculatorprueba.MVVM.Models
{
    public class CalculatorModel
    {
        public double Sum(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("No se puede dividir por cero.");
            return a / b;
        }

        public double Modulo(double number1, double number2)
        {
            return number1 % number2;
        }

        public double Absolute(double number)
        {
            return Math.Abs(number);
        }

        public double Round(double number)
        {
            return Math.Round(number);
        }

        public double Sin(double number)
        {
            return Math.Sin(number);
        }

        public double Cos(double number)
        {
            return Math.Cos(number);
        }
    }

    public static class MathOperations
    {
        public static double Power(double number, double exponent)
        {
            return Math.Pow(number, exponent);
        }

        public static double SquareRoot(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Cannot calculate square root of a negative number.");
            }
            return Math.Sqrt(number);
        }


    }
   
}

