//to be written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace NutriWeekMAUI.ViewModels
{
    [QueryProperty("Text", "Text")]

    public partial class CurrentWeekViewModel : ObservableObject
    {

        public CurrentWeekViewModel()
        {
            Days = new ObservableCollection<string>
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
        }

        [ObservableProperty]
        ObservableCollection<string> days;

        [ObservableProperty]
        string text;

        [RelayCommand]
        async Task GoToDay(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DayPage)}?Text={s}");
        }

        [RelayCommand]
        async Task BackToWeeks()
        {
            await Shell.Current.GoToAsync(nameof(WeeksPage));
        }
    }
}
