//to be written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NutriWeekMAUI.ViewModels
{
    public partial class DisclaimerViewModel : ObservableObject
    {
        [RelayCommand]
        async Task GoToWeeksPage()
        {
            await Shell.Current.GoToAsync(nameof(WeeksPage));
        }

        [RelayCommand]
        async Task BackToMainPage()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
