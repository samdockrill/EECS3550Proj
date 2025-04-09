//to be written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NutriWeekMAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        async Task GoToDisclaimerPage()
        {
            await Shell.Current.GoToAsync(nameof(DisclaimerPage));
        }
    }
}
