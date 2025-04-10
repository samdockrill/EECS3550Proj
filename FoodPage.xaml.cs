//written by Edward Keiper
using NutriWeekMAUI.ViewModels;

namespace NutriWeekMAUI;

public partial class FoodPage : ContentPage
{
    public FoodPage(FoodViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}