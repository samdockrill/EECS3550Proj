//written by Edward Keiper

using NutriWeekMAUI.ViewModels;

namespace NutriWeekMAUI;

public partial class DisclaimerPage : ContentPage
{
	public DisclaimerPage(DisclaimerViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}