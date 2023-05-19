using Calculator.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace Calculator.MVVM.ViewModels;


    public class CalculatorViewModel : INotifyPropertyChanged
{
     private string display;
    private double previousNumber;
    private string currentNumber;
    private string currentOperator;

    private StringBuilder inputBuilder;
    private double privateResult;

    public CalculatorViewModel()
    {
        AppendNumberCommand = new Command<string>(AppendNumberCommandExecute);
        AppendDecimalCommand = new Command(AppendDecimalCommandExecute);
        SetOperatorCommand = new Command<string>(SetOperatorCommandExecute);
        CalculateCommand = new Command(CalculateCommandExecute);
        ClearCommand = new Command(ClearCommandExecute);
        AbsoluteCommand = new Command(AbsoluteCommandExecute);
        RoundCommand = new Command(RoundCommandExecute);
        SinCommand = new Command(SinCommandExecute);
        CosCommand = new Command(CosCommandExecute);
        ModuloCommand = new Command(ModuloCommandExecute);
        PowerCommand = new Command(PowerCommandExecute);

        inputBuilder = new StringBuilder();
        privateResult = 0;
    }

    
    public event PropertyChangedEventHandler PropertyChanged;

    public string Display
    {
        get { return display; }
        set
        {
            if (display != value)
            {
                display = value;
                OnPropertyChanged("Display");
            }
        }
    }

    public ICommand AppendNumberCommand { get; }
    public ICommand AppendDecimalCommand { get; }
    public ICommand SetOperatorCommand { get; }
    public ICommand CalculateCommand { get; }
    public ICommand ClearCommand { get; }
    public ICommand AbsoluteCommand { get; }
    public ICommand RoundCommand { get; }
    public ICommand SinCommand { get; }
    public ICommand CosCommand { get; }
    public ICommand ModuloCommand { get; }
    public ICommand PowerCommand { get; }
   
    public ICommand OperationCommand => new Command<string>(PerformOperation);

    public ICommand NumberCommand => new Command<string>(AppendNumber);


    public ICommand ClearlCommand => new Command(Clearl);

    private void AppendNumber(string number)
    {
        inputBuilder.Append(number);
        OnPropertyChanged(nameof(Input));
    }

    private void PerformOperation(string operation)
    {
        double inputNumber;
        if (double.TryParse(inputBuilder.ToString(), out inputNumber))
        {
            switch (operation)
            {
                case "+":
                    privateResult += inputNumber;
                    break;
                case "-":
                    privateResult -= inputNumber;
                    break;
                case "*":
                    privateResult *= inputNumber;
                    break;
                case "/":
                    if (inputNumber != 0)
                    {
                        privateResult /= inputNumber;
                    }
                    else
                    {
                      
                    }
                    break;
                
            }

            inputBuilder.Clear();
            inputBuilder.Append(privateResult);
            OnPropertyChanged(nameof(Input));
        }
        else
        {
            
        }
    }

    private void Clearl()
    {
        inputBuilder.Clear();
        privateResult = 0;
        OnPropertyChanged(nameof(Input));
    }

    public string Input
    {
        get { return inputBuilder.ToString(); }
        set
        {
            inputBuilder.Clear();
            inputBuilder.Append(value);
            OnPropertyChanged(nameof(Input));
        }
    }

    public double Result
    {
        get { return privateResult; }
        set
        {
            privateResult = value;
            OnPropertyChanged(nameof(privateResult));
        }
    }

    

   
        private void AppendNumberCommandExecute(string number)
    {
        currentNumber += number;
        Display = currentNumber;
    }

    private void AppendDecimalCommandExecute()
    {
        if (!currentNumber.Contains("."))
        {
            currentNumber += ".";
            Display = currentNumber;
        }
    }

    private void SetOperatorCommandExecute(string operatorSymbol)
    {
        if (!string.IsNullOrEmpty(currentNumber))
        {
            previousNumber = double.Parse(currentNumber);
            currentNumber = "";
            currentOperator = operatorSymbol;
        }
    }

    private void CalculateCommandExecute()
    {
        if (!string.IsNullOrEmpty(currentNumber) && !string.IsNullOrEmpty(currentOperator))
        {
            double number = double.Parse(currentNumber);
            switch (currentOperator)
            {
                case "+":
                    previousNumber += number;
                    break;
                case "-":
                    previousNumber -= number;
                    break;
                case "*":
                    previousNumber *= number;
                    break;
                case "/":
                    previousNumber /= number;
                    break;
            }
            currentNumber = "";
            currentOperator = "";
            Display = previousNumber.ToString();
        }
    }

    private void ClearCommandExecute()
    {
        previousNumber = 0;
        currentNumber = "";
        currentOperator = "";
        Display = "0";
    }

    private void AbsoluteCommandExecute()
    {
        if (!string.IsNullOrEmpty(currentNumber))
        {
            double number = double.Parse(currentNumber);
            previousNumber = System.Math.Abs(number);
            currentNumber = "";
            currentOperator = "";
            Display = previousNumber.ToString();
        }
    }

    private void RoundCommandExecute()
    {
        if (!string.IsNullOrEmpty(currentNumber))
        {
            double number = double.Parse(currentNumber);
            previousNumber = System.Math.Round(number);
            currentNumber = "";
            currentOperator = "";
            Display = previousNumber.ToString();
        }
    }

    private void SinCommandExecute()
    {
        if (!string.IsNullOrEmpty(currentNumber))
        {
            double number = double.Parse(currentNumber);
            previousNumber = System.Math.Sin(number);
            currentNumber = "";
            currentOperator = "";
            Display = previousNumber.ToString();
        }
    }

    private void CosCommandExecute()
    {
        if (!string.IsNullOrEmpty(currentNumber))
        {
            double number = double.Parse(currentNumber);
            previousNumber = System.Math.Cos(number);
            currentNumber = "";
            currentOperator = "";
            Display = previousNumber.ToString();
        }
    }

    private void ModuloCommandExecute()
    {
        if (!string.IsNullOrEmpty(currentNumber))
        {
            double number = double.Parse(currentNumber);
            previousNumber %= number;
            currentNumber = "";
            currentOperator = "";
            Display = previousNumber.ToString();
        }
    }

    private void PowerCommandExecute()
    {
        if (!string.IsNullOrEmpty(currentNumber))
        {
            double number = double.Parse(currentNumber);
            previousNumber = System.Math.Pow(previousNumber, number);
            currentNumber = "";
            currentOperator = "";
            Display = previousNumber.ToString();
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

