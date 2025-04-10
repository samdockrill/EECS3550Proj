//written by Edward Keiper
using NutriWeekMAUI.ViewModels;

namespace NutriWeekMAUI;

public partial class TNTPage : ContentPage
{
    public TNTPage(TNTViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}