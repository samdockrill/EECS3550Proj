//written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NutriWeekMAUI.ViewModels
{
    public partial class DisclaimerViewModel : ObservableObject
    {
        //Confirm disclaimer and go to weeks page
        [RelayCommand]
        async Task GoToWeeksPage()
        {
            await Shell.Current.GoToAsync(nameof(WeeksPage));
        }


        //Go back to main page
        [RelayCommand]
        async Task BackToMainPage()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
