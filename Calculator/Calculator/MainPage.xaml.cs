using Calculator.MVVM.ViewModels;

namespace Calculator;

public partial class MainPage : ContentPage
{
    private CalculatorViewModel calculatorViewModel;


    public MainPage()
    {
        InitializeComponent();

        calculatorViewModel = new CalculatorViewModel();
        BindingContext = calculatorViewModel;
    }

    private void OnNumberClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string number = button.Text;
        calculatorViewModel.AppendNumberCommand.Execute(number);
    }

    private void OnOperatorClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string operation = button.Text;
        calculatorViewModel.SetOperatorCommand.Execute(operation);
    }

    private void OnDecimalClicked(object sender, EventArgs e)
    {
        calculatorViewModel.AppendDecimalCommand.Execute(null);
    }

    private void OnEqualClicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculateCommand.Execute(null);
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        calculatorViewModel.ClearCommand.Execute(null);
    }
}

