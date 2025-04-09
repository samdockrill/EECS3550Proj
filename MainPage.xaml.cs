//written by Edward Keiper

using NutriWeekMAUI.ViewModels;

namespace NutriWeekMAUI;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

