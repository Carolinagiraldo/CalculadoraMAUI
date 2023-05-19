using Calculatorprueba.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculatorprueba.MVVM.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel calculator;

        private double number1;
        public double Number1
        {
            get { return number1; }
            set
            {
                number1 = value;
                OnPropertyChanged(nameof(Number1));
            }
        }

        private double number2;
        public double Number2
        {
            get { return number2; }
            set
            {
                number2 = value;
                OnPropertyChanged(nameof(Number2));
            }
        }

        private double result;
        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public CalculatorViewModel()
        {
            calculator = new CalculatorModel();
        }

        public void CalculateSum()
        {
            Result = calculator.Sum(Number1, Number2);
        }

        public void CalculateSubtraction()
        {
            Result = calculator.Subtract(Number1, Number2);
        }

        public void CalculateMultiplication()
        {
            Result = calculator.Multiply(Number1, Number2);
        }

        public void CalculateDivision()
        {
            try
            {
                Result = calculator.Divide(Number1, Number2);
            }
            catch (DivideByZeroException ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public void CalculatePower()
        {
            Result = MathOperations.Power(Number1, Number2);
        }

        public void CalculateOnAbsolute()
        {
            try
            {
                Result = MathOperations.SquareRoot(Number1);
            }
            catch (ArgumentException ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        public void CalculateModulo()
        {
            Result = calculator.Modulo(Number1, Number2);
        }


        public void CalculateAbsolute()
        {
            Result = calculator.Absolute(Number1);
        }

        public void CalculateRound()
        {
            Result = calculator.Round(Number1);
        }

        public void CalculateSin()
        {
            Result = calculator.Sin(Number1);
        }

        public void CalculateCos()
        {
            Result = calculator.Cos(Number1);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void CalculateOnRound()
        {
            throw new NotImplementedException();
        }
    }
}
