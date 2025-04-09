//written by Edward Keiper

using NutriWeekMAUI.ViewModels;

namespace NutriWeekMAUI;

public partial class CurrentWeekPage : ContentPage
{
	public CurrentWeekPage(CurrentWeekViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}