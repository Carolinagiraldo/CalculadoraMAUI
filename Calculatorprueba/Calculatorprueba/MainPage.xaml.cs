using Calculatorprueba.MVVM.ViewModels;

namespace Calculatorprueba;

public partial class MainPage : ContentPage
{
    private CalculatorViewModel calculatorViewModel;

    public MainPage()
    {
        InitializeComponent();
        calculatorViewModel = new CalculatorViewModel();
        BindingContext = calculatorViewModel;
    }

    private void SumButton_Clicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculateSum();
    }

    private void SubtractButton_Clicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculateSubtraction();
    }

    private void MultiplyButton_Clicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculateMultiplication();
    }

    private void DivideButton_Clicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculateDivision();
    }

    private void PowerButton_Clicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculatePower();
    }

    private void SquareRootButton_Clicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculateOnAbsolute();
    }

    private void OnModuloClicked(object sender, EventArgs e)
    {

        calculatorViewModel.CalculateOnAbsolute();
    }

    private void OnAbsoluteClicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculateOnAbsolute();
    }

    private void OnRoundClicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculateRound();
    }

    private void OnSinClicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculateSin();
    }

    private void OnCosClicked(object sender, EventArgs e)
    {
        calculatorViewModel.CalculateCos();
    }
}


