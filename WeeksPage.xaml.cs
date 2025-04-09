//written by Edward Keiper

using NutriWeekMAUI.ViewModels;

namespace NutriWeekMAUI
{
    public partial class WeeksPage : ContentPage
    {
        public WeeksPage(WeeksViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}

