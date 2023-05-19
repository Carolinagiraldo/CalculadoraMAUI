using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

using Calculator.MVVM.Views;

namespace Calculator;

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


