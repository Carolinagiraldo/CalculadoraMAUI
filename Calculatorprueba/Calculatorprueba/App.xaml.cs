using Microsoft.Maui.Controls;

namespace Calculatorprueba;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var mainPage = new MainPage();
        return new Window(mainPage);
    }
}
