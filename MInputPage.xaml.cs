//written by Edward Keiper
using NutriWeekMAUI.ViewModels;

namespace NutriWeekMAUI;

public partial class MInputPage : ContentPage
{
    public MInputPage(MInputViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}