//written by Edward Keiper
using NutriWeekMAUI.ViewModels;

namespace NutriWeekMAUI;

public partial class DayPage : ContentPage
{
	public DayPage(DayViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}